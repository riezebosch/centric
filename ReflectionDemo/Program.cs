using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            if (!args.Any())
            {
                Console.WriteLine("Specify test assembly is parameter");
                return;
            }


            foreach (var location in args)
            {
                Console.WriteLine(location);
                var setup = new AppDomainSetup();
                setup.ConfigurationFile = location + ".config";
                setup.ApplicationBase = Path.GetDirectoryName(location);

                Environment.CurrentDirectory = Path.GetDirectoryName(location);
                var appdomain = AppDomain.CreateDomain("test", AppDomain.CurrentDomain.Evidence, setup);
                appdomain.Load(Path.GetFileName(location));
                
                    

                var ai = new AssemblyInspector(location);
                var classes = ai.GetClasses();
                int apassed = 0, afailed = 0;

                foreach (var c in classes)
                {
                    var runner = (TestRunner)appdomain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(TestRunner).FullName, new object[] { c });
                    Console.WriteLine(c.Name);

                    var ci = new ClassInspector(c);

                    if (!ExecuteIfExists(runner, ci.GetClassInitialize()))
                    {
                        break;
                    }

                    var testinit = ci.GetTestInitialize();
                    var testclean = ci.GetTestCleanUp();
                    var methods = ci.GetMethods();
                    int cpassed = 0, cfailed = 0;

                    foreach (var m in methods)
                    {
                        if (!ExecuteIfExists(runner, testinit))
                        {
                            break;
                        }

                        ExecuteTest(ref apassed, ref afailed, runner, ref cpassed, ref cfailed, m);
                        ExecuteIfExists(runner, testclean);
                    }

                    ExecuteIfExists(runner, ci.GetClassCleanUp());
                    Console.WriteLine("  [{0}] Tests passed: {1}, tests failed: {2}", c.Name, cpassed, cfailed);
                }
                Console.WriteLine("Tests passed: {0}, tests failed: {1}", apassed, afailed);
            }
        }

        private static bool ExecuteIfExists(TestRunner runner, MethodInfo m)
        {
            if (m != null)
            {
                Write(string.Format("  Executing: {0}", m.Name), ConsoleColor.DarkGray);
                if (!runner.Execute(m))
                {
                    WriteLine("  Failed", ConsoleColor.Red);
                    return false; 
                }

                Console.WriteLine();
            }

            return true;
        }

        private static void Write(string text, ConsoleColor color)
        {
            ExecuteWithColor(() => Console.Write(text), color);
        }

       

        private static void ExecuteTest(ref int apassed, ref int afailed, TestRunner runner, ref int cpassed, ref int cfailed, System.Reflection.MethodInfo m)
        {
            Console.Write("  {0}: ", m.Name);
            var result = runner.Execute(m);
            if (result)
            {
                WriteLine("Passed", ConsoleColor.Green);
                cpassed++;
                apassed++;
            }
            else
            {
                WriteLine("Failed", ConsoleColor.Red);
                cfailed++;
                afailed++;
            }
        }

        private static void WriteLine(string text, ConsoleColor color)
        {
            ExecuteWithColor(() => Console.WriteLine(text), color);
        }

        private static void ExecuteWithColor(Action action, ConsoleColor color)
        {
            var original = Console.ForegroundColor;
            Console.ForegroundColor = color;
            action();
            Console.ForegroundColor = original;
        }
    }
}

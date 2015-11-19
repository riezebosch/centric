using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CancellationTokenSource cts;

        private async void button1_Click(object sender, EventArgs e)
        {
            SetState(false);
            cts = new CancellationTokenSource();

            int n = int.Parse(textBox1.Text);
            try
            {
                int result = await FibAsync(n, cts.Token);
                label1.Text = result.ToString();
            }
            catch (OperationCanceledException)
            {
                label1.Text = "Operation aborted";
            }

            SetState(true);
        }

        private void SetState(bool enabled)
        {
            Cursor = enabled ? Cursors.Default : Cursors.WaitCursor;
            textBox1.Enabled = 
                button1.Enabled = enabled;
        }

        private Task<int> FibAsync(int n, CancellationToken token)
        {
            return Task<int>.Run(() => Fib(n, token));
        }

        private int Fib(int n, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            if (n <= 1)
                return n;

            return Fib(n - 1, token) + Fib(n - 2, token);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
    }
}

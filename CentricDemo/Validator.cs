using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentricDemo
{
    public class Validator
    {
        public bool IsValidName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (name == "marc")
            {
                return false;
            }

            return true;
        }
    }
}

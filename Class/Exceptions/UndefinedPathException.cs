using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting
{
    public class UndefinedPathException:Exception
    {
        public UndefinedPathException(string message) : base(message)
        {

        }
    }
}

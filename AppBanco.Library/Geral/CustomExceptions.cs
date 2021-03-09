using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanco.Library.Geral
{
    public class NrContasExceptions : Exception
    {
        public NrContasExceptions()
        {
        }

        public NrContasExceptions(string message) : base(message)
        {
        }

        public NrContasExceptions(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

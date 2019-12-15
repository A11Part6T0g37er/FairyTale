using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale
{
   public class EmptyPitException : Exception
    {
        public EmptyPitException(string exeption) : base(exeption)
        {

        }
        public EmptyPitException() { }

        public EmptyPitException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopSimEngine
{
    /// <summary>
    /// The base exception thrown by the engine
    /// </summary>
    public class SimException : Exception {
        public SimException(string message, Exception innerException = null)
            : base(message, innerException) { }      
    }

    /// <summary>
    /// An exception that occures during registration of a 
    /// group/idol
    /// </summary>
    public class RegistrationException : SimException {
        public RegistrationException(string message, Exception innerException = null)
            : base(message, innerException) { }       
    }
      
}

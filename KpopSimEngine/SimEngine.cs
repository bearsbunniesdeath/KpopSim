using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KpopSimEngine
{
    public class SimEngine
    {

        private static SimEngine _instance;
        private static readonly object _instanceLock = new Object();

        #region "Singleton boilerplate"

        public static SimEngine Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SimEngine();
                    }

                    return _instance;
                }
            }
        }

        #endregion

    }
}

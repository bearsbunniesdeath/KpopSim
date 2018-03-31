using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopSimEngine.Helpers
{
    class RandomHelper
    {

        private static Random randomizer;

        static RandomHelper()
        {
            randomizer = new Random();
        }        
    }
}

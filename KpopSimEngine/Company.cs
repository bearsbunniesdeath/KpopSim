using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopSimEngine
{
    public class Company
    {

        private List<IPromotablePersonnel> _promotablepersonnel;

        /// <summary>
        /// Personnel entities that can be promoted by the company
        /// This includes idols and idol groups
        /// </summary>
        public IReadOnlyList<IPromotablePersonnel> PromotablePersonnel
        {
            get
            {
                return _promotablepersonnel;
            }
        }


    }
}

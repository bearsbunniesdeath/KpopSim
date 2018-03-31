using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopSimEngine
{
    public class Group: IPromotablePersonnel
    {       
        private HashSet<Idol> _members;

        internal Group(Company company, string name)
        {
            Company = company;
            Name = name;

            _members = new HashSet<Idol>();           
        }

        public Company Company { get;}
        public string Name { get;}
        public DateTime DebutDate { get; private set; }

        public ICollection<Idol> Members
        {
            get
            {
                return _members;
            }
        }

        public int MemberCount
        {
            get
            {
                return _members.Count;
            }
        }

    }
}

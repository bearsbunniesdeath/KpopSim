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

        internal Group(Company company, GroupType type, string name)
        {
            Company = company;
            Type = type;
            Name = name;

            _members = new HashSet<Idol>();           
        }

        public Company Company { get;}
        public string Name { get;}
        public DateTime DebutDate { get; private set; }

        public GroupStatus Status { get; internal set; }

        public GroupType Type { get; internal set; }

        public IReadOnlyCollection<Idol> Members
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

        #region "Stats"


        public IdolPotential? AveragePotential
        {
            get
            {
                if (_members.Count != 0)
                    return (IdolPotential) Enum.Parse(typeof(IdolPotential), Math.Floor(_members.Average(m => (int) m.Potential)).ToString());
                return null;
            }
        }

        //Primary stats

        public Rating AverageVisualRating
        {
            get
            {
                if (_members.Count != 0)
                    return _members.Average(m => m.VisualRating);
                return null;
            }
        }


        public Rating AverageSingingRating
        {
            get
            {
                if (_members.Count != 0)
                    return _members.Average(m => m.SingingRating);
                return null;
            }
        }


        public Rating AverageDancingRating
        {
            get
            {
                if (_members.Count != 0)
                    return _members.Average(m => m.DancingRating);
                return null;
            }
        }


        public Rating AverageSocialRating
        {
            get
            {
                if (_members.Count != 0)
                    return _members.Average(m => m.SocialRating);
                return null;
            }
        }

        //Secondary stats
        public Rating AverageCharismaRating
        {
            get
            {
                if (_members.Count != 0)
                    return _members.Average(m => m.CharismaRating);
                return null;
            }
        }

        #endregion

        /// <summary>
        /// Add an idol to the group
        /// </summary>
        /// <param name="idol">An idol to add</param>
        internal void AddMember(Idol idol)
        {
            //Make sure the gender is correct for the group
            if ((Type == GroupType.Boyband && idol.Gender != Gender.Male) || 
               (Type == GroupType.Girlgroup && idol.Gender != Gender.Female))
                throw new SimException("Idol gender does not match group type.");

            //Make sure the member doesn't already exist
            if (_members.Contains(idol))
                throw new SimException("Idol already exists in the group");
                      
            _members.Add(idol);
        }

        /// <summary>
        /// Remove an idol from the group
        /// </summary>
        /// <param name="idol">An idol to remove</param>
        internal void RemoveMember(Idol idol)
        {
            if (_members.Contains(idol))
                _members.Remove(idol);
            else
                throw new SimException("Cannot find idol to remove.");
        }

    }

    public enum GroupType
    {
        Boyband,
        Girlgroup,
        Coed
    }

    public enum GroupStatus
    {
        Active,
        Hiatus,
        Disbanded
    }

}

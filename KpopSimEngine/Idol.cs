using Newtonsoft.Json;
using System;

namespace KpopSimEngine
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Idol : IPromotablePersonnel
    {
        /// <remarks>
        /// Initialize read-only auto-properties in the constructor
        /// </remarks>       
        [JsonConstructor]       
        internal Idol(string name, string fullName, Gender gender, DateTime dob)
        {
            Name = name;
            FullName = fullName;
            Gender = gender;
            DOB = dob;
        }

        /// <summary>
        /// Stage name
        /// </summary>
        [JsonProperty]
        public string Name { get; }

        /// <summary>
        /// Full given name
        /// </summary>
        [JsonProperty]
        public string FullName { get; }

        /// <summary>
        /// Male or female?
        /// </summary>
        [JsonProperty]
        public Gender Gender { get; }

        /// <summary>
        /// Date of birth
        /// </summary>
        [JsonProperty]
        public DateTime DOB { get; }

        /// <summary>
        /// Status of the idol
        /// </summary>
        
        public IdolStatus Status { get; internal set; }

        #region "Stats"

        
        public IdolPotential Potential { get; internal set; }

        //Primary stats
        
        public Rating VisualRating { get; internal set; }

        
        public Rating SingingRating { get; internal set; }

        
        public Rating DancingRating { get; internal set; }

        
        public Rating SocialRating { get; internal set; }

        //Secondary stats
        public Rating CharismaRating
        {
            get
            {
                return (Rating)(SocialRating + VisualRating) / 2.0;
            }
        }
        #endregion

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public enum IdolStatus
    {
        Active,
        Trainee,
        Hiatus,
        Retired,
        Injured
    }

    public struct IdolPotential
    {
        public const double A = 2;
        public const double B = 1.5;
        public const double C = 1;
        public const double D = 0.75;
    }

    public enum Gender
    {
        Male,
        Female
    }

    public struct IdolRegistration
    {
        public string Name;
        public string FullName;
        public Gender Gender;
        public DateTime DOB;
    }

    public struct IdolReportCard
    {
        public IdolPotential Potential;
        public Rating VisualRating;
        public Rating SingingRating;
        public Rating DancingRating;
        public Rating SocialRating;
    }
}

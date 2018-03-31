using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopSimEngine
{
    /// <summary>
    /// Represents a value between 0-100
    /// </summary>
    public class Rating
    {
        private static readonly Random randomGenerator = new Random();
        private static readonly object syncLock = new object();
        
        public double RealValue { get; private set; }
        
        /// <summary>
        /// Creates a random rating between 1-100
        /// </summary>
        public Rating()
        {
            lock (syncLock)
            {
                RealValue = randomGenerator.NextDouble() * 100;
            }
        }

        public Rating(double value)
        {
            RealValue = value;
        }
        
        /// <summary>
        /// Boosts the current rating
        /// </summary>
        /// <param name="percent">A number between 0 and 1 that indicates a boost percentage</param>
        /// <param name="growthModifier">A secondary attribute that can affect the growth of the rating</param>
        public void Boost(double percent, double growthModifier = 1)
        {
            RealValue += RealValue * percent * growthModifier;
        }

        public void Lower(double percent)
        {
            RealValue -= RealValue * percent;
        }
      
        public static implicit operator double(Rating r)
        {
            return r.RealValue;
        }

        public static implicit operator Rating(double d)
        {
            return new Rating(d);
        }

        public static explicit operator int(Rating r)
        {
            return (int)r.RealValue;
        }
               
        public static implicit operator Rating(int i)
        {
            return new Rating(i);
        }

        public override string ToString()
        {
            return ((int)RealValue).ToString();
        }
    }
}

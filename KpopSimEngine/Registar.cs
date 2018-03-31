using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopSimEngine
{
    class Registar
    {

        public static void Validate(IdolRegistration registration)
        {
            AssertIsNotNullOrWhitespace(registration.Name);
            AssertIsNotNullOrWhitespace(registration.FullName);
            AssertIsInThePast(registration.DOB);
        }

        #region "Registar assertions"

        #region "General assertions"

        private static void AssertIsNotNullOrWhitespace(string field)
        {
            if (string.IsNullOrWhiteSpace(field)) {
                throw new RegistrationException($"{field} cannot be null or whitespace.",
                                                new ArgumentException());                  
            }
        }

        private static void AssertIsInThePast(DateTime dt)
        {
            if (dt > DateTime.Now)
            {
                throw new RegistrationException($"{dt} is in the future.",
                                                new ArgumentException());
            }
        }

        #endregion

        #endregion
    }
}

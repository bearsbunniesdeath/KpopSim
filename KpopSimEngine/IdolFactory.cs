using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopSimEngine
{
    public class IdolFactory
    {
        public static Idol CreateIdol(IdolRegistration registration)
        {
            Idol newIdol = CreateIdolSkeleton(registration);

            newIdol.VisualRating = new Rating();
            newIdol.SingingRating = new Rating();
            newIdol.DancingRating = new Rating();
            newIdol.SocialRating = new Rating();

            return newIdol;
        }

        public static Idol CreateIdol(IdolRegistration registration, IdolReportCard reportCard)
        {         
            Idol newIdol = CreateIdolSkeleton(registration);

            //Verify the report card
            //TODO

            newIdol.Potential = reportCard.Potential;

            newIdol.VisualRating = reportCard.VisualRating;
            newIdol.SingingRating = reportCard.SingingRating;
            newIdol.DancingRating = reportCard.DancingRating;
            newIdol.SocialRating = reportCard.SocialRating;

            return newIdol;
        }

        private static Idol CreateIdolSkeleton(IdolRegistration registration)
        {
            //Verify the registration
            Registar.Validate(registration);

            Idol skeleton = new Idol(registration.Name, registration.FullName, registration.Gender, registration.DOB);

            skeleton.Status = IdolStatus.Trainee;

            return skeleton;
        }

        public static Idol CreateIdol(string jsonString)
        {          
            return JsonConvert.DeserializeObject<Idol>(jsonString);
        }

        public static Idol CreateDummyIdol()
        {
            IdolRegistration taeyeon = new IdolRegistration();
            taeyeon.Name = "Taeyeon";
            taeyeon.FullName = "Kim Taeyeon";
            taeyeon.Gender = Gender.Female;
            taeyeon.DOB = new DateTime(1989, 3, 9);

            return CreateIdol(taeyeon);
        }

    }
}

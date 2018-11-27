using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace KpopSimEngine.Helpers.Generators
{
    public static class NameGenerator
    {
        const string FEMALE_GIVEN_NAMES_RESOURCE = "KpopSimEngine.Data.Names.FemaleGivenNames.txt";

        private static bool _isInitialized = false;

        private static List<string> _surnames;
        private static List<string> _surnameProbabilities;

        private static List<string> _femaleGivenNames;
        private static List<string> _maleGivenNames;
        private static List<string> _stageNames;     

        public static IReadOnlyList<string> FemaleGivenNames
        {
            get
            {
                return _femaleGivenNames.AsReadOnly();
            }
        }

        public static IReadOnlyList<string> MaleGivenNames
        {
            get
            {
                return _maleGivenNames.AsReadOnly();
            }
        }

        public static void Initialize()
        {
            _femaleGivenNames = GetNames(FEMALE_GIVEN_NAMES_RESOURCE);
        }

        public static string GenerateFemaleName()
        {
            throw new NotImplementedException();
        }

        #region "Helpers"

        private static List<string> GetNames(string resource)
        {
            List<string> names = new List<string>();

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
            {
                TextReader reader = new StreamReader(stream);
                string name;
                while((name = reader.ReadLine()) != null)
                {
                    names.Add(name);
                }
            }
            return names;
        }

        #endregion
    }
}

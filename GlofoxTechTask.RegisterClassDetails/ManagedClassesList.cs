using GlofoxTechTask.RegisterClassDetails.Models;
using System.Collections.Generic;


namespace GlofoxTechTask.RegisterClassDetails
{
    static public class ManagedClassesList
    {
        static List<ClassDetails> _classList;

        static ManagedClassesList()
        {
            _classList = new List<ClassDetails>();
        }

        public static void Record(ClassDetails value)
        {
            _classList.Add(value);
        }

        public static List<ClassDetails> GetCurrentList()
        {
            return _classList;
        }

    }
}

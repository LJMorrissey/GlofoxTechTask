using GlofoxTechTask.Extensions;
using GlofoxTechTask.RegisterClassDetails.Models;

namespace GlofoxTechTask.RegisterClassDetails
{
    public class ClassRegistrationClient
    {
        public ClassRegistrationClient(){}

        public bool RegisterClass(ClassRegistrationDetails details)
        {
            // current limitations with static list approach will not handle multpl;e requests at the same time correcly, there will be concurency issues
            // possible resolution include identifier to group classes
            var listBeforeRegistration = ManagedClassesList.GetCurrentList().Count;
            AddClassDetailsToListOfManagedClasses(details);
            var listAfterRegistration = ManagedClassesList.GetCurrentList();
            return listAfterRegistration.Count > listBeforeRegistration;
        }
        public void AddClassDetailsToListOfManagedClasses(ClassRegistrationDetails details)
        {
            if (details == null) return;
            var classToAdd = MapRegistrationDetails(details);
            if (classToAdd == null) return;
            ManagedClassesList.Record(classToAdd);
        }

        public ClassDetails MapRegistrationDetails(ClassRegistrationDetails details)
        {
            // should never be null but add check jsut to be safe
            // seems like oa lot of checking prob a better way to do this
            if (details == null) return default;
            if (details.ClassName.IsNullOrWhiteSpace()) return default;
            if (details.StartDate.ToString().IsNullOrWhiteSpace()) return default;
            if (details.StartDate == default) return default;
            if (details.EndDate.ToString().IsNullOrWhiteSpace()) return default;
            if (details.EndDate == default) return default;
            if (details.Capacity.ToString().IsNullOrWhiteSpace()) return default;
            if (details.Capacity == 0) return default;

            return new ClassDetails()
            {
                // could use auto mapper however for this simple small class felt it more effort than was nessecary to set it up than to just do it manually
                ClassName = details.ClassName,
                StartDate = details.StartDate,
                EndDate = details.EndDate,
                Capacity = details.Capacity
            };
        }
    }
}

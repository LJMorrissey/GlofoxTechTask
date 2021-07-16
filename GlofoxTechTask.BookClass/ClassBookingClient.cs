using GlofoxTechTask.BookClass.Models;
using GlofoxTechTask.Extensions;
using System;

namespace GlofoxTechTask.BookClass
{
    public class ClassBookingClient
    {
        public ClassBookingClient() { }
        /*
        book class
        

        add booked class object to managed list

        map booking request to booked class object
        */

        public bool BookClass(ClassBookingDetails details)
        {
            // current limitations with static list approach will not handle multpl;e requests at the same time correcly, there will be concurency issues
            // possible resolution include identifier to group classes
            var listBeforeRegistration = ManagedBookingsList.GetCurrentList().Count;
            AddBookingDetailsToListOfManagedBookings(details);
            var listAfterRegistration = ManagedBookingsList.GetCurrentList();
            return listAfterRegistration.Count > listBeforeRegistration;
        }
        public void AddBookingDetailsToListOfManagedBookings(ClassBookingDetails details)
        {
            if (details == null) return;
            var classToBook = MapBookingDetails(details);
            if (classToBook == null) return;
            ManagedBookingsList.Record(classToBook);
        }

        public BookingDetails MapBookingDetails(ClassBookingDetails details)
        {
            // should never be null but add check jsut to be safe
            // seems like oa lot of checking prob a better way to do this
            if (details == null) return default;
            if (details.ClassName.IsNullOrWhiteSpace()) return default;
            if (details.ClientName.IsNullOrWhiteSpace()) return default;
            if (details.ClassDate.ToString().IsNullOrWhiteSpace()) return default;
            if (details.ClassDate == default) return default;

            return new BookingDetails()
            {
                // could use auto mapper however for this simple small class felt it more effort than was nessecary to set it up than to just do it manually
                ClassName = details.ClassName,
                ClassDate = details.ClassDate,
                ClientName = details.ClientName
            };
        }
    }
}

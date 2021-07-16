using GlofoxTechTask.BookClass.Models;
using System.Collections.Generic;


namespace GlofoxTechTask.BookClass
{
    static public class ManagedBookingsList
    {
        static List<BookingDetails> _bookingsList;

        static ManagedBookingsList()
        {
            _bookingsList = new List<BookingDetails>();
        }

        public static void Record(BookingDetails value)
        {
            _bookingsList.Add(value);
        }

        public static List<BookingDetails> GetCurrentList()
        {
            return _bookingsList;
        }

    }
}

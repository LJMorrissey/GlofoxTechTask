using GlofoxTechTask.BookClass;
using GlofoxTechTask.BookClass.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GlofoxTechTask.Testing.Unit
{
    [TestClass]
    public class TestClassBookingClient
    {
        [TestMethod]
        public void NullInputDoesNotGetAddedToList()
        {
            var sut = new ClassBookingClient();
            var expectedCount = ManagedBookingsList.GetCurrentList().Count;
            sut.AddBookingDetailsToListOfManagedBookings(null);
            var countAfterCall = ManagedBookingsList.GetCurrentList().Count;
            Assert.AreEqual(expectedCount, countAfterCall);
        }

        [TestMethod]
        public void nullInputToMapperReturnsNull()
        {
            var sut = new ClassBookingClient();
            var mappedResponse = sut.MapBookingDetails(null);
            Assert.IsNull(mappedResponse);
        }

        [DataTestMethod]
        [DataRow("", "", "")]
        [DataRow(null, null, null)]
        [DataRow("ValidClassName", null, null)]

        public void badInputDataforMappingReturnsNull(string testClassName, string testClientName, string testClassDate)
        {


            var sut = new ClassBookingClient();
            DateTime startDateTime;
            DateTime endDateTime;
            int capacity;
            var badTestInput = new ClassBookingDetails()
            {
                ClassName = testClassName,
                ClientName = testClientName,
                ClassDate = DateTime.TryParse(testClassDate, out startDateTime) ? startDateTime : default,              
            };
            var mappedResponse = sut.MapBookingDetails(badTestInput);
            Assert.IsNull(mappedResponse);
        }


        [TestMethod]
        public void goodInputDataForMappingReturnsCorrectMapping()
        {
            var sut = new ClassBookingClient();
            var goodTestInput = new ClassBookingDetails()
            {
                ClassName = "ValidClassName",
                ClassDate = DateTime.UtcNow,
                ClientName = "ValidClientName"
            };
            var mappedResponse = sut.MapBookingDetails(goodTestInput);
            Assert.IsNotNull(mappedResponse);
            Assert.AreEqual(goodTestInput.ClassName, mappedResponse.ClassName);
            Assert.AreEqual(goodTestInput.ClassDate, mappedResponse.ClassDate);
            Assert.AreEqual(goodTestInput.ClientName, mappedResponse.ClientName);
        }

        [DataTestMethod]
        [DataRow("", "", "")]
        [DataRow(null, null, null)]
        [DataRow("ValidClassName", null, null)]

        public void badInputDataforRegisteringReturnsNull(string testClassName, string testClientName, string testClassDate)
        {

            var expectedCount = ManagedBookingsList.GetCurrentList().Count;
            var sut = new ClassBookingClient();
            DateTime classDateTime;
           
            var badTestInput = new ClassBookingDetails()
            {
                ClassName = testClassName,
                ClientName = testClientName,
                ClassDate = DateTime.TryParse(testClassDate, out classDateTime) ? classDateTime : default
               
            };
            sut.AddBookingDetailsToListOfManagedBookings(badTestInput);
            var countAfterCall = ManagedBookingsList.GetCurrentList().Count;
            Assert.AreEqual(expectedCount, countAfterCall);
        }

        [TestMethod]
        public void goodInputDataForRegisteringReturnsCorrectMapping()
        {
            var expectedCount = ManagedBookingsList.GetCurrentList().Count + 1;
            var sut = new ClassBookingClient();
            var goodTestInput = new ClassBookingDetails()
            {
                ClassName = "ValidClassName",
                ClassDate = DateTime.UtcNow,
                ClientName = "ValidClientName"
            };
            sut.AddBookingDetailsToListOfManagedBookings(goodTestInput);
            var countAfterCall = ManagedBookingsList.GetCurrentList().Count;
            Assert.AreEqual(expectedCount, countAfterCall);
        }

        [TestMethod]
        // come back and tidy this test up 
        public void MultipleGoodInputDataForRegisteringReturnsCorrectCount()
        {
            var expectedCount = ManagedBookingsList.GetCurrentList().Count + 2;
            var sut = new ClassBookingClient();
            var goodTestInput = new ClassBookingDetails()
            {
                ClassName = "ValidClassName",
                ClassDate = DateTime.UtcNow,
                ClientName = "ValidClientName"
            };
            sut.AddBookingDetailsToListOfManagedBookings(goodTestInput);

            goodTestInput = new ClassBookingDetails()
            {
                ClassName = "ValidClassName",
                ClassDate = DateTime.UtcNow,
                ClientName = "ValidClientName"
            };
            sut.AddBookingDetailsToListOfManagedBookings(goodTestInput);

            var countAfterCall = ManagedBookingsList.GetCurrentList().Count;
            Assert.AreEqual(expectedCount, countAfterCall);
        }


        [DataTestMethod]
        [DataRow("", "", "")]
        [DataRow(null, null, null)]
        [DataRow("ValidClassName", null, null)]

        public void badInputWhenRegisteringReturnsFalse(string testClassName,string testClientName, string testClassDate)
        {
            var sut = new ClassBookingClient();
            DateTime classDateTime;

            var badTestInput = new ClassBookingDetails()
            {
                ClassName = testClassName,
                ClientName = testClientName,
                ClassDate = DateTime.TryParse(testClassDate, out classDateTime) ? classDateTime : default             
            };
            var response = sut.BookClass(badTestInput);
            Assert.IsFalse(response);
        }


        [TestMethod]
        public void goodInputWhenRegisteringReturnsTrue()
        {
            var sut = new ClassBookingClient();
            var goodTestInput = new ClassBookingDetails()
            {
                ClassName = "ValidClassName",
                ClassDate = DateTime.UtcNow,
                ClientName = "ValidClientName"
            };
            var response = sut.BookClass(goodTestInput);
            Assert.IsTrue(response);
        }
    }
}

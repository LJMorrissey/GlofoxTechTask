using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlofoxTechTask.RegisterClassDetails;
using GlofoxTechTask.RegisterClassDetails.Models;
using System;

namespace GlofoxTechTask.Testing.Unit
{
    [TestClass]
    public class TestClassRegistrationClient
    {
        [TestMethod]
        public void NullInputDoesNotGetAddedToList()
        {
            var sut = new ClassRegistrationClient();
            var expectedCount = ManagedClassesList.GetCurrentList().Count;
            sut.AddClassDetailsToListOfManagedClasses(null);
            var countAfterCall = ManagedClassesList.GetCurrentList().Count;
            Assert.AreEqual(expectedCount, countAfterCall);
        }

        [TestMethod]
        public void nullInputToMapperReturnsNull()
        {
            var sut = new ClassRegistrationClient();
            var mappedResponse = sut.MapRegistrationDetails(null);
            Assert.IsNull(mappedResponse);
        }

        [DataTestMethod]
        [DataRow("", "", "", "")]
        [DataRow(null, null, null, null)]
        [DataRow("ValidClassName", null, null, "inValidCapacity")]

        public void badInputDataforMappingReturnsNull(string testClassName, string testClassStartDate, string testClassEndDate, string testClasscapacity)
        {


            var sut = new ClassRegistrationClient();
            DateTime startDateTime;
            DateTime endDateTime;
            int capacity;
            var badTestInput = new ClassRegistrationDetails()
            {
                ClassName = testClassName,
                StartDate = DateTime.TryParse(testClassStartDate, out startDateTime) ? startDateTime : default,
                EndDate = DateTime.TryParse(testClassEndDate, out endDateTime) ? endDateTime : default,
                Capacity = int.TryParse(testClasscapacity, out capacity) ? capacity : default
            };
            var mappedResponse = sut.MapRegistrationDetails(badTestInput);
            Assert.IsNull(mappedResponse);
        }


        [TestMethod]
        public void goodInputDataForMappingReturnsCorrectMapping()
        {
            var sut = new ClassRegistrationClient();
            var goodTestInput = new ClassRegistrationDetails()
            {
                ClassName = "ValidClassName",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Capacity = 10
            };
            var mappedResponse = sut.MapRegistrationDetails(goodTestInput);
            Assert.IsNotNull(mappedResponse);
            Assert.AreEqual(goodTestInput.ClassName, mappedResponse.ClassName);
            Assert.AreEqual(goodTestInput.StartDate, mappedResponse.StartDate);
            Assert.AreEqual(goodTestInput.EndDate, mappedResponse.EndDate);
            Assert.AreEqual(goodTestInput.Capacity, mappedResponse.Capacity);
        }

        [DataTestMethod]
        [DataRow("", "", "", "")]
        [DataRow(null, null, null, null)]
        [DataRow("ValidClassName", null, null, "inValidCapacity")]

        public void badInputDataforRegisteringReturnsNull(string testClassName, string testClassStartDate, string testClassEndDate, string testClasscapacity)
        {

            var expectedCount = ManagedClassesList.GetCurrentList().Count;
            var sut = new ClassRegistrationClient();
            DateTime startDateTime;
            DateTime endDateTime;
            int capacity;
            var badTestInput = new ClassRegistrationDetails()
            {
                ClassName = testClassName,
                StartDate = DateTime.TryParse(testClassStartDate, out startDateTime) ? startDateTime : default,
                EndDate = DateTime.TryParse(testClassEndDate, out endDateTime) ? endDateTime : default,
                Capacity = int.TryParse(testClasscapacity, out capacity) ? capacity : default
            };
            sut.AddClassDetailsToListOfManagedClasses(badTestInput);
            var countAfterCall = ManagedClassesList.GetCurrentList().Count;
            Assert.AreEqual(expectedCount, countAfterCall);
        }


        [TestMethod]
        public void goodInputDataForRegisteringReturnsCorrectMapping()
        {
            var expectedCount = ManagedClassesList.GetCurrentList().Count + 1;
            var sut = new ClassRegistrationClient();
            var goodTestInput = new ClassRegistrationDetails()
            {
                ClassName = "ValidClassName",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Capacity = 10
            };
            sut.AddClassDetailsToListOfManagedClasses(goodTestInput);
            var countAfterCall = ManagedClassesList.GetCurrentList().Count;
            Assert.AreEqual(expectedCount, countAfterCall);
        }

        [TestMethod]
        // come back and tidy this test up 
        public void MultipleGoodInputDataForRegisteringReturnsCorrectCount()
        {
            var expectedCount = ManagedClassesList.GetCurrentList().Count + 2;
            var sut = new ClassRegistrationClient();
            var goodTestInput = new ClassRegistrationDetails()
            {
                ClassName = "ValidClassName",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Capacity = 10
            };
            sut.AddClassDetailsToListOfManagedClasses(goodTestInput);

            goodTestInput = new ClassRegistrationDetails()
            {
                ClassName = "ValidClassName2",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Capacity = 10
            };
            sut.AddClassDetailsToListOfManagedClasses(goodTestInput);
            var countAfterCall = ManagedClassesList.GetCurrentList().Count;
            Assert.AreEqual(expectedCount, countAfterCall);
        }


        [DataTestMethod]
        [DataRow("", "", "", "")]
        [DataRow(null, null, null, null)]
        [DataRow("ValidClassName", null, null, "inValidCapacity")]

        public void badInputWhenRegisteringReturnsFalse(string testClassName, string testClassStartDate, string testClassEndDate, string testClasscapacity)
        {
            var sut = new ClassRegistrationClient();
            DateTime startDateTime;
            DateTime endDateTime;
            int capacity;
            var badTestInput = new ClassRegistrationDetails()
            {
                ClassName = testClassName,
                StartDate = DateTime.TryParse(testClassStartDate, out startDateTime) ? startDateTime : default,
                EndDate = DateTime.TryParse(testClassEndDate, out endDateTime) ? endDateTime : default,
                Capacity = int.TryParse(testClasscapacity, out capacity) ? capacity : default
            };
            var response = sut.RegisterClass(badTestInput);
            Assert.IsFalse(response);
        }


        [TestMethod]
        public void goodInputWhenRegisteringReturnsTrue()
        {
            var sut = new ClassRegistrationClient();
            var goodTestInput = new ClassRegistrationDetails()
            {
                ClassName = "ValidClassName",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Capacity = 10
            };
            var response = sut.RegisterClass(goodTestInput);
            Assert.IsTrue(response);
        }
    }
}

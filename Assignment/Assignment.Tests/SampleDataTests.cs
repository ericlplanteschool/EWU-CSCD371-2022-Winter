using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {

        readonly SampleData sampleData = new();

        [TestMethod]
        public void CsvRows_Read_Success()
        {
            Assert.IsNotNull(sampleData.CsvRows);
            Assert.AreEqual<int>(50, sampleData.CsvRows.Count());
        }

        [TestMethod]
        public void CsvRows_Read_FirstRowSkipped()
        {
            // Arrange
            IEnumerable<string> csvRows = sampleData.CsvRows;

            // Act.

            // Assert.
            Assert.AreEqual<string>("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577", csvRows.First());
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HardCoded()
        {
            List<IAddress> addresses = new();
            addresses.Add(new Address("53 Grim Point", "Spokane", "WA", "99022"));
            addresses.Add(new Address("1 Rutledge Point", "Spokane", "WA", "99021"));
            addresses.Add(new Address("6487 Pepper Wood Court", "Spokane", "WA", "99021"));

            IEnumerable<string> spokaneAddressStates = addresses.Select(address => address.State).Distinct();
            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().Select(state => "WA").Distinct();

            string statesInSpokane = string.Join(", ", spokaneAddressStates.ToArray());
            string allStatesWAOnly = string.Join(", ", states.ToArray());

            Assert.AreEqual<string>(statesInSpokane, allStatesWAOnly);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_isSorted()
        {
            // Arrange.
            List<string> list = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
            IEnumerable<string> temp = sampleData.CsvRows.Select(line => line.Split(',')).Select(column => column[6]).OrderBy(state => state).Distinct();

            // Act.

            // Assert.
            Assert.IsTrue(list.SequenceEqual(temp));
        }


        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_Read_Success()
        {
            // Arrange.
            string states = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            // Assert.
            Assert.AreEqual<string>("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", states);
        }

        [TestMethod]
        public void People_Read_Success()
        {
            // Arrange.
            IEnumerable<string> csvRows = sampleData.CsvRows;
            IEnumerable<IPerson> people = sampleData.People;

            // Assert.
            Assert.AreEqual<int>(csvRows.Count(), people.Count());
        }

        [TestMethod]
        public void FilterByEmail_filtersCorrectly()
        {
            // Arrange.
            Predicate<string> filter = email;
            static bool email(string email) => email.Contains("pjenyns0@state.gov");
            IEnumerable<(string, string)> result = sampleData.FilterByEmailAddress(filter);

            // Act.
            var expected = ("Priscilla", "Jenyns");

            // Assert.
            Assert.AreEqual(expected, (result.First().Item1, result.First().Item2));
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_Read_Success()
        {
            // Arrange.
            string uniqueRows = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string uniquePeople = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);

            // Act.


            // Assert.
            Assert.AreEqual(uniqueRows, uniquePeople);
        }

    }
}

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;

namespace Assignment.Tests
{
    [TestClass]
    public class AssignmentTests
    {
        IEnumerator<string>? stringEnumerator;

        SampleData data = new();


        [TestMethod]
        public void CsvRows_GetData_Success()
        {
            // Arrange.
            stringEnumerator = data.CsvRows.GetEnumerator();
            string getData;

            // Act.
            while (stringEnumerator.MoveNext())
            {
                getData = stringEnumerator.Current;

                // Assert.
                Assert.IsNotNull(getData);
            }
        }

        [TestMethod]
        public void AssignmentSampleData_1stRowSkipped_Success()
        {
            // Arrange
            IEnumerable<string> csvRows = data.CsvRows;

            // Act.

            // Assert.
            Assert.IsFalse(csvRows.First().Contains("Id"));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_isSorted()
        {
            // Arrange.
            List<string> list = data.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
            IEnumerable<string> temp = data.CsvRows.Select(line => line.Split(',')).Select(x => x[6]).OrderBy(x => x).Distinct();

            // Act.

            // Assert.
            Assert.IsTrue(list.SequenceEqual(temp));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HardCoded()
        {
            //not sure what we are supposed to be testing with the hard coded list
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_OutputsUniqueandSorted()
        {
            // Arrange.
            string states = data.GetAggregateSortedListOfStatesUsingCsvRows();

            // Assert.
            Assert.AreEqual<string>("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", states);
        }

        [TestMethod]
        public void People_populatesCorrectly()
        {
            // Arrange.
            IEnumerable<string> csvRows = data.CsvRows;
            IEnumerable<IPerson> people = data.People;

            // Assert.
            Assert.IsTrue(csvRows.Count() == people.Count());
        }

        [TestMethod]
        public void FilterByEmail_filtersCorrectly()
        {
            // Arrange.
            Predicate<string> filter = email;
            static bool email(string email) => email.Contains("pjenyns0@state.gov");
            IEnumerable<(string, string)> result = data.FilterByEmailAddress(filter);

            // Act.
            var expected = ("Priscilla", "Jenyns");

            // Assert.
            Assert.AreEqual(expected, (result.First().Item1, result.First().Item2));
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_isUnique()
        {
            // Arrange.
            string uniqueRows = data.GetAggregateSortedListOfStatesUsingCsvRows();
            string uniquePeople = data.GetAggregateListOfStatesGivenPeopleCollection(data.People);

            // Act.


            // Assert.
            Assert.AreEqual(uniqueRows, uniquePeople);
        }

    }
}
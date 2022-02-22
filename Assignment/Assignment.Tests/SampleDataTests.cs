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
        [TestMethod]
        public void CsvRows_Read_Success()
        {
            SampleData sampleData = new();
            Assert.IsNotNull(sampleData.CsvRows);
            Assert.AreEqual<int>(50, sampleData.CsvRows.Count());
            Assert.AreEqual<string>("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577", sampleData.CsvRows.First());
        }

        [TestMethod]
        public void People_Read_Success()
        {
            SampleData sampleData = new();
            Assert.IsNotNull(sampleData.People);
            Assert.AreEqual<int>(50, sampleData.People.Count());
            Assert.AreEqual<string>("Priscilla", sampleData.People.First().FirstName);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_Read_Success()
        {
            SampleData sampleData = new();
            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.AreEqual("AL", states.First());
            Assert.AreEqual("WV", states.Last());
        }
    }
}

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
            Assert.AreEqual(sampleData.CsvRows.Count(), 50);
            Assert.AreEqual(sampleData.CsvRows.First(), "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577");
        }
    }
}

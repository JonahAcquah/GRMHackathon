using System.Linq;
using GRM.DataService;
using NUnit.Framework;

namespace GRM.Tests
{
    [TestFixture]
    public class DataStoreTests
    {
        private DataStore _dataStore;

        [SetUp]
        public void SetUp()
        {
            _dataStore = new DataStore();
        }

        [Test]
        public void Should_Read_Music_Contract_Data_From_File()
        {
            //Act
            var results = _dataStore.GetMusicContracts();

            //
            Assert.AreEqual(results.Count(), 7);
        }

        [Test]
        public void Should_Read_Partner_Contract_Data_From_File()
        {
            //Act
            var results = _dataStore.GetPartnerContracts();

            //Assert
            Assert.AreEqual(results.Count(), 2);
        }
    }
}

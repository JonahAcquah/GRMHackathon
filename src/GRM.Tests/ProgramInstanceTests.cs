using System;
using System.Collections.Generic;
using System.IO;
using GRM.DataService;
using GRM.Response;
using Moq;
using NUnit.Framework;

namespace GRM.Tests
{
    [TestFixture]
    public class ProgramInstanceTests
    {
        private Mock<IDataStore> _dataStoreMock;
        private Program _program;

        [SetUp]
        public void SetUp()
        {
            _dataStoreMock = new Mock<IDataStore>();
            _program = new Program(_dataStoreMock.Object);
        }

        [Test]
        public void Should_Return_Products_For_A_Partner_And_A_Given_Date()
        {
            //Arrange
            _dataStoreMock.Setup(store => store.GetMusicContracts())
                .Returns(new List<MusicContract>
                {
                    new MusicContract
                    {
                        Artist = "Tinie",
                        Title = "Frisky",
                        Usages = "digital download",
                        StartDate = "1st Feb 2012",
                        EndDate = ""
                    }
                });

            _dataStoreMock.Setup(store => store.GetPartnerContracts())
                .Returns(new List<PartnerContract>
                {
                    new PartnerContract
                    {
                        Partner = "ITunes",
                        Usage = "digital download"
                    }
                });

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Act
                _program.Start(new[] { "-p ITunes", "-d 1st Mar 2012" }); //Date in American format here

                //Assert
                var lines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                Assert.AreEqual(lines.Length, 3);
                Assert.AreEqual(lines[0], "Artist|Title|Usage|StartDate|EndDate");
                Assert.AreEqual(lines[1], "Tinie|Frisky|digital download|1st Feb 2012|");
            }
        }
    }
}

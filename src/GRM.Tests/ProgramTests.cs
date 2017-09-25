using System;
using System.IO;
using NUnit.Framework;

namespace GRM.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test, Description("Scenario 1")]
        public void Should_Return_Correct_Products_For_ITunes_01032012()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Act
                Program.Main(new[] { "-p ITunes", "-d 1st Mar 2012" });

                //Assert
                var lines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                Assert.AreEqual(lines.Length, 6);
                Assert.AreEqual(lines[0], "Artist|Title|Usage|StartDate|EndDate");
                Assert.AreEqual(lines[1], "Tinie Tempah|Frisky (Live from SoHo)|digital download, streaming|1st Feb 2012|");
                Assert.AreEqual(lines[2], "Tinie Tempah|Miami 2 Ibiza|digital download|1st Feb 2012|");
                Assert.AreEqual(lines[3], "Monkey Claw|Black Mountain|digital download|1st Feb 2012|");
                Assert.AreEqual(lines[4], "Monkey Claw|Motor Mouth|digital download, streaming|1st Mar 2011|");
                
                
            }
        }

        [Test, Description("Scenario 2")]
        public void Should_Return_Correct_Products_For_YouTube_01042012()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Act
                Program.Main(new[] { "-p YouTube", "-d 1st Apr 2012" });

                //Assert
                var lines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                Assert.AreEqual(lines.Length, 4);
                Assert.AreEqual(lines[0], "Artist|Title|Usage|StartDate|EndDate");
                Assert.AreEqual(lines[1], "Tinie Tempah|Frisky (Live from SoHo)|digital download, streaming|1st Feb 2012|");
                Assert.AreEqual(lines[2], "Monkey Claw|Motor Mouth|digital download, streaming|1st Mar 2011|");
            }
        }

        [Test, Description("Scenario 3")]
        public void Should_Return_Correct_Products_For_YouTube_27122012()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Act
                Program.Main(new[] { "-p YouTube", "-d 27th Dec 2012" });

                //Assert
                var lines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                Assert.AreEqual(lines.Length, 6);
                Assert.AreEqual(lines[0], "Artist|Title|Usage|StartDate|EndDate");
                Assert.AreEqual(lines[1], "Tinie Tempah|Frisky (Live from SoHo)|digital download, streaming|1st Feb 2012|");
                Assert.AreEqual(lines[2], "Monkey Claw|Iron Horse|digital download, streaming|1st Jun 2012|");
                Assert.AreEqual(lines[3], "Monkey Claw|Motor Mouth|digital download, streaming|1st Mar 2011|");
                Assert.AreEqual(lines[4], "Monkey Claw|Christmas Special|streaming|25st Dec 2012|31st Dec 2012");
            }
        }
    }
}

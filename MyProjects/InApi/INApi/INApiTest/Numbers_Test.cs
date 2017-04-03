using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using INApi.Util;

namespace INApiTest
{
    [TestFixture]
    public class Numbers_Test
    {
        [Test]
        public void IsRegonNumerValid_ReturnTrue()
        {
            NumberBase number = new RegonNumber();
            string n = "410083230";
            Assert.IsTrue(number.IsValid(n));
            n = "05902358700129";
            Assert.IsTrue(number.IsValid(n));
        }

        [Test]
        public void IsNIPNumberValid_ReturnTrue()
        {
            NumberBase number = new NIPNumber();
            string n = "9250654977";
            Assert.IsTrue(number.IsValid(n));
        }

        [Test]
        public void IsKRSNumberValid_ReturnTrue()
        {
            NumberBase number = new KRSNumber();
            Assert.IsTrue(number.IsValid(string.Empty));
        }
    }
}

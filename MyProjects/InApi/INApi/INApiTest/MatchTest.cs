using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using INApi.Helpers;
using INApi.Util;

namespace INApiTest
{
    [TestFixture]
    public class MatchTest
    {
        private MatchFactory MakeMatchClass()
        {
            return new MatchFactory();
        }

        [Test]
        public void MatchNumber_ReturnInstanceOfRegonClass()
        {
            IList<IMatchNumber> numbersType = new List<IMatchNumber>();
            numbersType.Add(new MatchRegonNumber());
            numbersType.Add(new MatchNIPNumber());

            MatchFactory match = MakeMatchClass();

            NumberBase number = match.MatchNumber(numbersType, "432522830");

            Assert.IsInstanceOf(typeof(RegonNumber), number);
        }
        [Test]
        public void MatchNumber_ReturnInstanceOfNIPClass()
        {
            IList<IMatchNumber> numbersType = new List<IMatchNumber>();
            numbersType.Add(new MatchNIPNumber());
            numbersType.Add(new MatchRegonNumber());

            MatchFactory match = MakeMatchClass();

            NumberBase number = match.MatchNumber(numbersType, "6834322313");

            Assert.IsInstanceOf(typeof(NIPNumber), number);
        }

        [Test]
        public void MatchNumber_InValidNumber_ReturnNull()
        {
            IList<IMatchNumber> numbersType = new List<IMatchNumber>();
            numbersType.Add(new MatchNIPNumber());
            numbersType.Add(new MatchRegonNumber());

            MatchFactory match = MakeMatchClass();

            NumberBase number = match.MatchNumber(numbersType, "683432");

            Assert.AreSame(null, number);
        }

        [Test]
        public void MatchNumber_NIPNumber_RemoveDashInNumber()
        {
            IList<IMatchNumber> numbersType = new List<IMatchNumber>();
            numbersType.Add(new MatchNIPNumber());
            numbersType.Add(new MatchRegonNumber());

            MatchFactory match = MakeMatchClass();

            NumberBase number = match.MatchNumber(numbersType, "683-432-23-13");

            Assert.IsInstanceOf(typeof(NIPNumber), number);
        }

        [Test]
        public void MatchNumber_NIPNumber_UEFormatNumber()
        {
            IList<IMatchNumber> numbersType = new List<IMatchNumber>();
            numbersType.Add(new MatchNIPNumber());
            numbersType.Add(new MatchRegonNumber());

            MatchFactory match = MakeMatchClass();

            NumberBase number = match.MatchNumber(numbersType, "PL6834322313");

            Assert.IsInstanceOf(typeof(NIPNumber), number);
        }
    }
}

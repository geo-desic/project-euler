using NUnit.Framework;
using ProjectEuler;
using ProjectEuler.Problems;

namespace ProjectEulerTests
{
    public class ProblemTests
    {
        [Test]
        public void Problem001()
        {
            var problem = new Problem001() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(233168, problem.Answer());
        }

        [Test]
        public void Problem002()
        {
            var problem = new Problem002() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(4613732, problem.Answer());
        }

        [Test]
        public void Problem003()
        {
            var problem = new Problem003() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(6857L, problem.Answer());
        }

        [Test]
        public void Problem004()
        {
            var problem = new Problem004() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(906609, problem.Answer());
        }

        [Test]
        public void Problem005()
        {
            var problem = new Problem005() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(232792560L, problem.Answer());
        }

        [Test]
        public void Problem006()
        {
            var problem = new Problem006() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(25164150L, problem.Answer());
        }

        [Test]
        public void Problem007()
        {
            var problem = new Problem007() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(104743L, problem.Answer());
        }

        [Test]
        public void Problem008()
        {
            var problem = new Problem008() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(23514624000L, problem.Answer());
        }

        [Test]
        public void Problem009()
        {
            var problem = new Problem009() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(31875000L, problem.Answer());
        }

        [Test]
        public void Problem010()
        {
            var problem = new Problem010() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(142913828922L, problem.Answer());
        }

        [Test]
        public void Problem011()
        {
            var problem = new Problem011() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(70600674L, problem.Answer());
        }

        [Test]
        public void Problem012()
        {
            var problem = new Problem012() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(76576500L, problem.Answer());
        }

        [Test]
        public void Problem013()
        {
            var problem = new Problem013() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual("5537376230", problem.Answer());
        }

        // slow; ~3.7s
        [Test]
        public void Problem014()
        {
            var problem = new Problem014() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(837799L, problem.Answer());
        }

        [Test]
        public void Problem015()
        {
            var problem = new Problem015() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(137846528820L, problem.Answer());
        }

        [Test]
        public void Problem016()
        {
            var problem = new Problem016() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(1366, problem.Answer());
        }

        [Test]
        public void Problem017()
        {
            var problem = new Problem017() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(21124, problem.Answer());
        }

        [Test]
        public void Problem018()
        {
            var problem = new Problem018() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(1074L, problem.Answer());
        }

        [Test]
        public void Problem019()
        {
            var problem = new Problem019() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(171, problem.Answer());
        }

        [Test]
        public void Problem020()
        {
            var problem = new Problem020() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(648, problem.Answer());
        }

        [Test]
        public void Problem021()
        {
            var problem = new Problem021() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(31626L, problem.Answer());
        }

        [Test]
        public void Problem022()
        {
            var problem = new Problem022() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(871198282L, problem.Answer());
        }

        [Test]
        public void Problem023()
        {
            var problem = new Problem023() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(4179871L, problem.Answer());
        }

        [Test]
        public void Problem024()
        {
            var problem = new Problem024() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual("2783915460", problem.Answer());
        }

        [Test]
        public void Problem025()
        {
            var problem = new Problem025() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(4782, problem.Answer());
        }

        [Test]
        public void Problem026()
        {
            var problem = new Problem026() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(983, problem.Answer());
        }

        [Test]
        public void Problem027()
        {
            var problem = new Problem027() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(-59231L, problem.Answer());
        }

        [Test]
        public void Problem028()
        {
            var problem = new Problem028() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(669171001L, problem.Answer());
        }

        // slow; ~3.9s
        [Test]
        public void Problem029()
        {
            var problem = new Problem029() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(9183L, problem.Answer());
        }

        [Test]
        public void Problem030()
        {
            var problem = new Problem030() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(443839L, problem.Answer());
        }

        [Test]
        public void Problem031()
        {
            var problem = new Problem031() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(73682, problem.Answer());
        }

        [Test]
        public void Problem032()
        {
            var problem = new Problem032() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(45228, problem.Answer());
        }

        [Test]
        public void Problem033()
        {
            var problem = new Problem033() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(100, problem.Answer());
        }

        [Test]
        public void Problem034()
        {
            var problem = new Problem034() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(40730, problem.Answer());
        }

        [Test]
        public void Problem035()
        {
            var problem = new Problem035() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(55, problem.Answer());
        }

        [Test]
        public void Problem036()
        {
            var problem = new Problem036() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(872187L, problem.Answer());
        }

        [Test]
        public void Problem037()
        {
            var problem = new Problem037() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(748317L, problem.Answer());
        }

        [Test]
        public void Problem038()
        {
            var problem = new Problem038() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(932718654L, problem.Answer());
        }

        [Test]
        public void Problem039()
        {
            var problem = new Problem039() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(840, problem.Answer());
        }

        [Test]
        public void Problem040()
        {
            var problem = new Problem040() { ConsoleOutput = false, DetailedOutput = false };
            Assert.AreEqual(210L, problem.Answer());
        }
    }
}

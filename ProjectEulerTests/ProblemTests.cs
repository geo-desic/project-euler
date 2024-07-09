using NUnit.Framework;
using ProjectEuler.Problems;

namespace ProjectEulerTests
{
    public class ProblemTests
    {
        [Test]
        public void Problem001()
        {
            var problem = new Problem001() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(233168, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem002()
        {
            var problem = new Problem002() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(4613732, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem003()
        {
            var problem = new Problem003() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(6857L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem004()
        {
            var problem = new Problem004() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(906609, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem005()
        {
            var problem = new Problem005() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(232792560L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem006()
        {
            var problem = new Problem006() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(25164150L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem007()
        {
            var problem = new Problem007() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(104743L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem008()
        {
            var problem = new Problem008() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(23514624000L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem009()
        {
            var problem = new Problem009() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(31875000L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem010()
        {
            var problem = new Problem010() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(142913828922L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem011()
        {
            var problem = new Problem011() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(70600674L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem012()
        {
            var problem = new Problem012() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(76576500L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem013()
        {
            var problem = new Problem013() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That("5537376230", Is.EqualTo(problem.Answer()));
        }

        // slow; ~3.7s
        [Test]
        public void Problem014()
        {
            var problem = new Problem014() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(837799L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem015()
        {
            var problem = new Problem015() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(137846528820L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem016()
        {
            var problem = new Problem016() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(1366, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem017()
        {
            var problem = new Problem017() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(21124, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem018()
        {
            var problem = new Problem018() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(1074L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem019()
        {
            var problem = new Problem019() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(171, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem020()
        {
            var problem = new Problem020() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(648, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem021()
        {
            var problem = new Problem021() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(31626L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem022()
        {
            var problem = new Problem022() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(871198282L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem023()
        {
            var problem = new Problem023() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(4179871L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem024()
        {
            var problem = new Problem024() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That("2783915460", Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem025()
        {
            var problem = new Problem025() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(4782, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem026()
        {
            var problem = new Problem026() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(983, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem027()
        {
            var problem = new Problem027() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(-59231L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem028()
        {
            var problem = new Problem028() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(669171001L, Is.EqualTo(problem.Answer()));
        }

        // slow; ~3.9s
        [Test]
        public void Problem029()
        {
            var problem = new Problem029() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(9183L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem030()
        {
            var problem = new Problem030() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(443839L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem031()
        {
            var problem = new Problem031() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(73682, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem032()
        {
            var problem = new Problem032() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(45228, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem033()
        {
            var problem = new Problem033() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(100, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem034()
        {
            var problem = new Problem034() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(40730, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem035()
        {
            var problem = new Problem035() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(55, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem036()
        {
            var problem = new Problem036() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(872187L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem037()
        {
            var problem = new Problem037() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(748317L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem038()
        {
            var problem = new Problem038() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(932718654L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem039()
        {
            var problem = new Problem039() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(840, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Problem040()
        {
            var problem = new Problem040() { ConsoleOutput = false, DetailedOutput = false };
            Assert.That(210L, Is.EqualTo(problem.Answer()));
        }
    }
}

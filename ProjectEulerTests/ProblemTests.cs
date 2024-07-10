using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using ProjectEuler.Problems;

namespace ProjectEulerTests
{
    public class ProblemTests
    {
        [Test]
        public void Answer_Problem001_IsCorrect()
        {
            var problem = new Problem001(NullLogger< Problem001>.Instance);
            Assert.That(233168, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem002_IsCorrect()
        {
            var problem = new Problem002(NullLogger<Problem002>.Instance);
            Assert.That(4613732, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem003_IsCorrect()
        {
            var problem = new Problem003(NullLogger<Problem003>.Instance);
            Assert.That(6857L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem004_IsCorrect()
        {
            var problem = new Problem004(NullLogger<Problem004>.Instance);
            Assert.That(906609, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem005_IsCorrect()
        {
            var problem = new Problem005(NullLogger<Problem005>.Instance);
            Assert.That(232792560L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem006_IsCorrect()
        {
            var problem = new Problem006(NullLogger<Problem006>.Instance);
            Assert.That(25164150L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem007_IsCorrect()
        {
            var problem = new Problem007(NullLogger<Problem007>.Instance);
            Assert.That(104743L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem008_IsCorrect()
        {
            var problem = new Problem008(NullLogger<Problem008>.Instance);
            Assert.That(23514624000L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem009_IsCorrect()
        {
            var problem = new Problem009(NullLogger<Problem009>.Instance);
            Assert.That(31875000L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem010_IsCorrect()
        {
            var problem = new Problem010(NullLogger<Problem010>.Instance);
            Assert.That(142913828922L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem011_IsCorrect()
        {
            var problem = new Problem011(NullLogger<Problem011>.Instance);
            Assert.That(70600674L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem012_IsCorrect()
        {
            var problem = new Problem012(NullLogger<Problem012>.Instance);
            Assert.That(76576500L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem013_IsCorrect()
        {
            var problem = new Problem013(NullLogger<Problem013>.Instance);
            Assert.That("5537376230", Is.EqualTo(problem.Answer()));
        }

        // slow; ~3.7s
        [Test]
        public void Answer_Problem014_IsCorrect()
        {
            var problem = new Problem014(NullLogger<Problem014>.Instance);
            Assert.That(837799L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem015_IsCorrect()
        {
            var problem = new Problem015(NullLogger<Problem015>.Instance);
            Assert.That(137846528820L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem016_IsCorrect()
        {
            var problem = new Problem016(NullLogger<Problem016>.Instance);
            Assert.That(1366, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem017_IsCorrect()
        {
            var problem = new Problem017(NullLogger<Problem017>.Instance);
            Assert.That(21124, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem018_IsCorrect()
        {
            var problem = new Problem018(NullLogger<Problem018>.Instance);
            Assert.That(1074L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem019_IsCorrect()
        {
            var problem = new Problem019(NullLogger<Problem019>.Instance);
            Assert.That(171, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem020_IsCorrect()
        {
            var problem = new Problem020(NullLogger<Problem020>.Instance);
            Assert.That(648, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem021_IsCorrect()
        {
            var problem = new Problem021(NullLogger<Problem021>.Instance);
            Assert.That(31626L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem022_IsCorrect()
        {
            var problem = new Problem022(NullLogger<Problem022>.Instance);
            Assert.That(871198282L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem023_IsCorrect()
        {
            var problem = new Problem023(NullLogger<Problem023>.Instance);
            Assert.That(4179871L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem024_IsCorrect()
        {
            var problem = new Problem024(NullLogger<Problem024>.Instance);
            Assert.That("2783915460", Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem025_IsCorrect()
        {
            var problem = new Problem025(NullLogger<Problem025>.Instance);
            Assert.That(4782, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem026_IsCorrect()
        {
            var problem = new Problem026(NullLogger<Problem026>.Instance);
            Assert.That(983, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem027_IsCorrect()
        {
            var problem = new Problem027(NullLogger<Problem027>.Instance);
            Assert.That(-59231L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem028_IsCorrect()
        {
            var problem = new Problem028(NullLogger<Problem028>.Instance);
            Assert.That(669171001L, Is.EqualTo(problem.Answer()));
        }

        // slow; ~3.9s
        [Test]
        public void Answer_Problem029_IsCorrect()
        {
            var problem = new Problem029(NullLogger<Problem029>.Instance);
            Assert.That(9183L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem030_IsCorrect()
        {
            var problem = new Problem030(NullLogger<Problem030>.Instance);
            Assert.That(443839L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem031_IsCorrect()
        {
            var problem = new Problem031(NullLogger<Problem031>.Instance);
            Assert.That(73682, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem032_IsCorrect()
        {
            var problem = new Problem032(NullLogger<Problem032>.Instance);
            Assert.That(45228, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem033_IsCorrect()
        {
            var problem = new Problem033(NullLogger<Problem033>.Instance);
            Assert.That(100, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem034_IsCorrect()
        {
            var problem = new Problem034(NullLogger<Problem034>.Instance);
            Assert.That(40730, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem035_IsCorrect()
        {
            var problem = new Problem035(NullLogger<Problem035>.Instance);
            Assert.That(55, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem036_IsCorrect()
        {
            var problem = new Problem036(NullLogger<Problem036>.Instance);
            Assert.That(872187L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem037_IsCorrect()
        {
            var problem = new Problem037(NullLogger<Problem037>.Instance);
            Assert.That(748317L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem038_IsCorrect()
        {
            var problem = new Problem038(NullLogger<Problem038>.Instance);
            Assert.That(932718654L, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem039_IsCorrect()
        {
            var problem = new Problem039(NullLogger<Problem039>.Instance);
            Assert.That(840, Is.EqualTo(problem.Answer()));
        }

        [Test]
        public void Answer_Problem040_IsCorrect()
        {
            var problem = new Problem040(NullLogger<Problem040>.Instance);
            Assert.That(210L, Is.EqualTo(problem.Answer()));
        }
    }
}

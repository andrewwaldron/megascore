using NUnit.Framework;
using ScoreBusiness.domain;

namespace ScoreBusiness.Test.business
{
    [TestFixture]
    public class ScoreController_Test
    {
        private ScoreController subject;

        [SetUp]
        public void SetUp()
        {
            subject = new ScoreController();
        }
        
        [Test]
        public void DoesSomething()
        {
            Assert.True(true);
        }
    }
}
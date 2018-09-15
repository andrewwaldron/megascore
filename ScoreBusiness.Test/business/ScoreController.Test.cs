using NUnit.Framework;
using ScoreBusiness.business;
using ScoreBusiness.data;
using ScoreBusiness.enumeration;

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
        public void ScoringThreePointsWorks()
        {
            var scoreEvent = new ScoreEvent
            {
                ScorePoints =  3,
                ScoreTeam =  Team.Home
            };
            
            subject.ApplyScoreEvent(scoreEvent);
            Assert.AreEqual(3, subject.GetCurrentScore().HomeScore, "Expected home score to be three");
        }
    }
}
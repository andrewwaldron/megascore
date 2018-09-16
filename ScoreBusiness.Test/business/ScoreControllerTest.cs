using NUnit.Framework;
using ScoreBusiness.business;
using ScoreBusiness.data;
using ScoreBusiness.enumeration;

namespace ScoreBusiness.Test.business
{
    [TestFixture]
    public class ScoreControllerTest
    {
        private ScoreController _subject;

        [SetUp]
        public void SetUp()
        {
            _subject = new ScoreController();
        }
        
        [Test]
        public void ScoringThreePointsHomeWorks()
        {
            var scoreEvent = new ScoreEvent
            {
                ScorePoints =  3,
                ScoreTeam =  Team.Home
            };
            
            _subject.ApplyScoreEvent(scoreEvent);
            Assert.AreEqual(3, _subject.GetCurrentScore().HomeScore, "Expected home score to be three");
            Assert.AreEqual(0, _subject.GetCurrentScore().AwayScore, "Expected away score to be zero");
        }
        
        [Test]
        public void ScoringTwoPointsAwayWorks()
        {
            var scoreEvent = new ScoreEvent
            {
                ScorePoints =  2,
                ScoreTeam =  Team.Away
            };
            
            _subject.ApplyScoreEvent(scoreEvent);
            Assert.AreEqual(2, _subject.GetCurrentScore().AwayScore, "Expected away score to be two");
            Assert.AreEqual(0, _subject.GetCurrentScore().HomeScore, "Expected home score to be zero");
        }

        [Test]
        public void ScoringNegativePointsWorks()
        {
            var positiveScoreEvent = new ScoreEvent { ScorePoints =  2, ScoreTeam =  Team.Away };
            _subject.ApplyScoreEvent(positiveScoreEvent);
            
            var negativeScoreEvent = new ScoreEvent { ScorePoints =  -1, ScoreTeam =  Team.Away };
            _subject.ApplyScoreEvent(negativeScoreEvent);
            
            Assert.AreEqual(1, _subject.GetCurrentScore().AwayScore, "Expected away score to be one");
            Assert.AreEqual(0, _subject.GetCurrentScore().HomeScore, "Expected home score to be zero");

        }

        [Test]
        public void ScoreEventsAreStoredInOrder()
        {
            var positiveScoreEvent = new ScoreEvent { ScorePoints =  2, ScoreTeam =  Team.Away };
            var negativeScoreEvent = new ScoreEvent { ScorePoints =  -1, ScoreTeam =  Team.Away };
            
            _subject.ApplyScoreEvent(positiveScoreEvent);
            _subject.ApplyScoreEvent(negativeScoreEvent);

            Assert.AreEqual(positiveScoreEvent, _subject.GetScoreHistory()[0]);
            Assert.AreEqual(negativeScoreEvent, _subject.GetScoreHistory()[1]);
            Assert.AreEqual(2, _subject.GetScoreHistory().Count);
        }

        [Test]
        public void InvalidScoreEventThrowExceptions()
        {
            var invalidScoreEvent = new ScoreEvent { ScorePoints = 4, ScoreTeam =  Team.Away };

            Assert.Throws<System.Exception>(() => { _subject.ApplyScoreEvent(invalidScoreEvent); });
        }
    }
}
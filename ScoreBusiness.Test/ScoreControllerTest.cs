using NUnit.Framework;
using ScoreBusiness.Business;
using ScoreBusiness.Data;
using ScoreBusiness.Enumeration;

namespace ScoreBusiness.Test
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
            var scoreEvent = new ScoreEvent { ScorePoints =  3, ScoreTeam =  Team.Home };
            
            _subject.ApplyScoreEvent(scoreEvent);
            
            var currentScore = _subject.GetCurrentScore();
            Assert.AreEqual(3, currentScore[Team.Home]);
            Assert.AreEqual(0, currentScore[Team.Away]);
        }
        
        [Test]
        public void ScoringTwoPointsAwayWorks()
        {
            var scoreEvent = new ScoreEvent { ScorePoints =  3, ScoreTeam =  Team.Away };

            _subject.ApplyScoreEvent(scoreEvent);

            var currentScore = _subject.GetCurrentScore();
            Assert.AreEqual(2, currentScore[Team.Away]);
            Assert.AreEqual(0, currentScore[Team.Home]);
        }

        [Test]
        public void ScoringNegativePointsWorks()
        {
            var positiveScoreEvent = new ScoreEvent { ScorePoints =  2, ScoreTeam =  Team.Away };
            var negativeScoreEvent = new ScoreEvent { ScorePoints =  -1, ScoreTeam =  Team.Away };

            _subject.ApplyScoreEvent(positiveScoreEvent);
            _subject.ApplyScoreEvent(negativeScoreEvent);

            var currentScore = _subject.GetCurrentScore();
            Assert.AreEqual(1, currentScore[Team.Away]);
            Assert.AreEqual(0, currentScore[Team.Home]);
        }

        [Test]
        public void ScoreEventsAreStoredInOrder()
        {
            var positiveScoreEvent = new ScoreEvent { ScorePoints =  2, ScoreTeam =  Team.Away };
            var negativeScoreEvent = new ScoreEvent { ScorePoints =  -1, ScoreTeam =  Team.Away };
            
            _subject.ApplyScoreEvent(positiveScoreEvent);
            _subject.ApplyScoreEvent(negativeScoreEvent);

            var scoreHistory = _subject.GetScoreHistory();
            Assert.AreEqual(2, scoreHistory.Count);
            Assert.AreEqual(positiveScoreEvent, scoreHistory[0]);
            Assert.AreEqual(negativeScoreEvent, scoreHistory[1]);
        }

        [Test]
        public void InvalidScoreEventThrowExceptions()
        {
            var invalidScoreEvent = new ScoreEvent { ScorePoints = 4, ScoreTeam =  Team.Away };

            Assert.Throws<System.Exception>(() => { _subject.ApplyScoreEvent(invalidScoreEvent); });
        }
    }
}
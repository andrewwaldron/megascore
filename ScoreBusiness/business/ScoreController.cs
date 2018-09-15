using ScoreBusiness.data;

namespace ScoreBusiness.business
{
    public class ScoreController
    {
        private readonly GameScore _currentScore;

        public ScoreController()
        {
            _currentScore = new GameScore();
        }
        
        public void ApplyScoreEvent(ScoreEvent scoreEvent)
        {
            _currentScore.HomeScore += scoreEvent.ScorePoints;
        }

        public GameScore GetCurrentScore()
        {
            return _currentScore;
        }
    }
}
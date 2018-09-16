using ScoreBusiness.data;
using ScoreBusiness.enumeration;

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
            if (scoreEvent.ScoreTeam == Team.Home)
            {
                _currentScore.HomeScore += scoreEvent.ScorePoints;
            }
            else
            {
                _currentScore.AwayScore += scoreEvent.ScorePoints;
            }
        }

        public GameScore GetCurrentScore()
        {
            return _currentScore;
        }
    }
}
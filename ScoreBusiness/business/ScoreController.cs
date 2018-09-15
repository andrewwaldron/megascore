using ScoreBusiness.data;

namespace ScoreBusiness.business
{
    public class ScoreController
    {
        private GameScore currentScore;

        public ScoreController()
        {
            currentScore = new GameScore();
        }
        
        public void ApplyScoreEvent(ScoreEvent scoreEvent)
        {
            currentScore.HomeScore += scoreEvent.ScorePoints;
        }

        public GameScore GetCurrentScore()
        {
            return currentScore;
        }
    }
}
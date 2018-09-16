using System;
using System.Collections.Generic;
using ScoreBusiness.data;
using ScoreBusiness.enumeration;

namespace ScoreBusiness.business
{
    public class ScoreController
    {
        private readonly GameScore _currentScore;
        private readonly List<ScoreEvent> _scoreHistory;

        public ScoreController()
        {
            _scoreHistory = new List<ScoreEvent>();
            _currentScore = new GameScore();
        }
        
        public void ApplyScoreEvent(ScoreEvent scoreEvent)
        {
            validateScoreEvent(scoreEvent);
            
            _scoreHistory.Add(scoreEvent);
            
            if (scoreEvent.ScoreTeam == Team.Home)
            {
                _currentScore.HomeScore += scoreEvent.ScorePoints;
            }
            else
            {
                _currentScore.AwayScore += scoreEvent.ScorePoints;
            }
        }

        private void validateScoreEvent(ScoreEvent scoreEvent)
        {
            if (scoreEvent.ScorePoints >= 4)
                throw new Exception("InvalidEvent: Score Must Be Less Than 4");
        }

        public GameScore GetCurrentScore()
        {
            return _currentScore;
        }

        public List<ScoreEvent> GetScoreHistory()
        {
            return _scoreHistory;
        }
    }
}
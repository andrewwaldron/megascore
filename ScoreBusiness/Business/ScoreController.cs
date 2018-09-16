using System;
using System.Collections.Generic;
using ScoreBusiness.Data;
using ScoreBusiness.Enumeration;

namespace ScoreBusiness.Business
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
            ValidateScoreEvent(scoreEvent);
            
            _scoreHistory.Add(scoreEvent);
            
            _currentScore[scoreEvent.ScoreTeam] += scoreEvent.ScorePoints;
        }

        private static void ValidateScoreEvent(ScoreEvent scoreEvent)
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
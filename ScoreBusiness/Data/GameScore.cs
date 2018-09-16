using System.Collections.Generic;
using ScoreBusiness.Enumeration;

namespace ScoreBusiness.Data
{
    public class GameScore
    {
        public GameScore()
        {
            TeamScores = new SortedList<Team, int> {{Team.Home, 0}, {Team.Away, 0}};
        }
        
        public int this[Team team]
        {
            get => TeamScores[team];
            set => TeamScores[team] = value;
        }

        private SortedList<Team, int> TeamScores { get; }
    }
}
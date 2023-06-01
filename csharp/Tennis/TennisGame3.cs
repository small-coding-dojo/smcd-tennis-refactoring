namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private const int FourPoints = 4;
        private const int SixPoints = 6;
        private int _player2Points;
        private int player1Points;
        private string player1Name;
        private string player2Name;
        public static readonly string[] POINTS_NAMES = new[] { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var isNotYetEndgame = (player1Points < FourPoints && _player2Points < FourPoints) && (player1Points + _player2Points < SixPoints);
            if (isNotYetEndgame)
            {
                var score = POINTS_NAMES[player1Points];
                if (player1Points == _player2Points)
                    return score + "-All";
                else
                    return score + "-" + POINTS_NAMES[_player2Points];
            }
            else
            {
                if (player1Points == _player2Points)
                    return "Deuce";
                var leader = player1Points > _player2Points ? player1Name : player2Name;
                var pointsDifferenceIsOne = (player1Points - _player2Points) * (player1Points - _player2Points) == 1;
                if (pointsDifferenceIsOne)
                    return "Advantage " + leader;
                else
                    return "Win for " + leader;
            }
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                this.player1Points += 1;
            else
                this._player2Points += 1;
        }

    }
}


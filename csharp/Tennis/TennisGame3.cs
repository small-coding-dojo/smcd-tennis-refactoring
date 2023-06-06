namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private const int FourPoints = 4;
        private const int SixPoints = 6;
        private static readonly string ScoreSeparator = "-";
        private static readonly string WordSeparator = " ";
        private static readonly string Draw = "All";
        private static readonly string Deuce = "Deuce";
        private static readonly string Advantage = "Advantage";
        private static readonly string WinFor = "Win for";
        private static readonly string[] PointsNames = new[] { "Love", "Fifteen", "Thirty", "Forty" };
        private int _player2Points;
        private int _player1Points;
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame3(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public string GetScore()
        {
            if (IsNotYetEndGame())
            {
                var score = PointsNames[_player1Points];
                if (IsDraw())
                {
                    return score + ScoreSeparator + Draw;
                }
                else
                {
                    return score + ScoreSeparator + PointsNames[_player2Points];
                }
            }
            else
            {
                if (IsDraw())
                {
                    return Deuce;
                }

                if (PointsDifferenceIsOne())
                {
                    return Advantage + WordSeparator + LeadingPlayer();
                }
                else
                {
                    return WinFor + WordSeparator + LeadingPlayer();
                }
            }
        }

        private bool IsDraw()
        {
            return _player1Points == _player2Points;
        }

        private string LeadingPlayer()
        {
            return _player1Points > _player2Points ? _player1Name : _player2Name;
        }

        private bool IsNotYetEndGame()
        {
            return (_player1Points < FourPoints && _player2Points < FourPoints) && (_player1Points + _player2Points < SixPoints);
        }

        private bool PointsDifferenceIsOne()
        {
            return (_player1Points - _player2Points) * (_player1Points - _player2Points) == 1;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
            {
                _player1Points += 1;
            }
            else
            {
                _player2Points += 1;
            }
        }

    }
}


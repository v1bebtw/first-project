namespace Project.Code
{
    public class BankService
    {
        private int _scoreValue;
        private int _scorePerClick = 1;

        public BankService(int scoreValue)
        {
            _scoreValue = scoreValue;
        }

        public int GetScore()
        {
            return _scoreValue;
        }
        
        public void SetScore()
        {
            _scoreValue += _scorePerClick;
        }

        public void ResetScore()
        {
            _scoreValue = 0;
        }

        public void UpdateScorePerClick(int price)
        {
            _scorePerClick += 1;
            _scoreValue -= price;
        }
    }
}
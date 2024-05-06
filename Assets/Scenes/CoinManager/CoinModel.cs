namespace Scenes.CoinManager
{
    public class CoinModel : ICoinModel
    {
        private int _numberOfCoins;
        public int NumberOfCoins
        {
            get => _numberOfCoins;
            set => _numberOfCoins = value >= 0 ? value : 0;
        }
    }
}
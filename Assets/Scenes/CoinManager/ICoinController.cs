using System;

namespace Scenes.CoinManager
{
    public interface ICoinController
    {
        void AddMoney(int value);
        bool PayMoney(int value);
    }
}

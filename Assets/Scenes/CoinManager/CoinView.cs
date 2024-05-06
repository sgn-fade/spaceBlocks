using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scenes.CoinManager
{
    public class CoinView: MonoBehaviour, ICoinView
    {
        [SerializeField] private Text coinLabel;
        public void UpdateMoney(int value)
        {
            coinLabel.text = value.ToString();
        }
    }
}
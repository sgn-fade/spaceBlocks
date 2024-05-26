using System;
using Scenes.CoinManager;
using Scenes.Player;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Scenes.UI
{
    public class Upgrades : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour player;
        [SerializeField] private MonoBehaviour playerCoins;

        [SerializeField] private Text damageCostLabel;
        [SerializeField] private Text hpCostLabel;

        private IPlayerController _playerController;
        private ICoinController _coinController;

        private int _damageLevel = 1;
        private int _hpLevel = 1;
        private void Awake()
        {
            _playerController = player as IPlayerController;
            _coinController = playerCoins as ICoinController;
        }

        private void Start()
        {
            damageCostLabel.text = UpgradeCost(_damageLevel).ToString();
            hpCostLabel.text = UpgradeCost(_hpLevel).ToString();
        }

        public void OnUpgradesPressed()
        {
            gameObject.SetActive(true);
        }
        public void OnExitPressed()
        {
            gameObject.SetActive(false);
        }

        public void OnDamageUpPressed()
        {
            if (_coinController.PayMoney(UpgradeCost(_damageLevel)))
            {
                Debug.Log("upgrade successful");
                _playerController.UpgradeDamage();
                _damageLevel++;
                damageCostLabel.text = UpgradeCost(_damageLevel).ToString();
                return;
            }

            Debug.Log("not enough");
        }
        public void OnHpUpPressed()
        {
            if (_coinController.PayMoney(UpgradeCost(_hpLevel)))
            {
                _playerController.UpgradeHp();
                _hpLevel++;
                hpCostLabel.text = UpgradeCost(_hpLevel).ToString();
            }
        }

        private int UpgradeCost(int level)
        {
            return level * 2 + Random.Range(1, 5);
        }
    }
}

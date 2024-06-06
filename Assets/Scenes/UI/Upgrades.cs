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
        [SerializeField] private Text shootRateCostLabel;

        [SerializeField] private Text damageLevelLabel;
        [SerializeField] private Text hpLevelLabel;
        [SerializeField] private Text shootRateLevelLabel;

        private IPlayerController _playerController;
        private ICoinController _coinController;

        private int _damageLevel = 1;
        private int _hpLevel = 1;
        private int _shootRateLevel = 1;
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
                _playerController.UpgradeDamage();
                damageLevelLabel.text = (++_damageLevel).ToString();
                damageCostLabel.text = UpgradeCost(_damageLevel).ToString();
            }

        }
        public void OnHpUpPressed()
        {
            if (_coinController.PayMoney(UpgradeCost(_hpLevel)))
            {
                _playerController.UpgradeHp();
                hpLevelLabel.text = (++_hpLevel).ToString();
                hpCostLabel.text = UpgradeCost(_hpLevel).ToString();
            }
        }
        public void OnShootRateUpPressed()
        {
            if (_shootRateLevel == 40)
            {
                shootRateLevelLabel.text = "max";
                return;
            }
            if (_coinController.PayMoney(UpgradeCost(_shootRateLevel)))
            {
                _playerController.UpgradeShootRate();
                shootRateLevelLabel.text = (++_shootRateLevel).ToString();
                shootRateCostLabel.text = UpgradeCost(_shootRateLevel).ToString();
            }
        }

        private int UpgradeCost(int level)
        {
            return level * 2 + Random.Range(1, 5);
        }
    }
}

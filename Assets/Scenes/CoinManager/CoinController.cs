using System;
using Scenes.BlockSpawner.Block;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scenes.CoinManager
{
    public class CoinController : MonoBehaviour, ICoinController
    {
        private CoinModel _model;
        private CoinView _view;
        private void OnDisable()
        {
            BlockController.OnEnemyKilled -= OnEnemyKilled;
        }

        private void OnEnable()
        {
            BlockController.OnEnemyKilled += OnEnemyKilled;
        }

        private void OnEnemyKilled(int value)
        {
            UpdateMoney(value);
        }

        private void Awake()
        {
            _model = new CoinModel();
            _view = gameObject.GetComponentInChildren<CoinView>();
        }

        public void UpdateMoney(int value)
        {
            //Debug.Log(value);
            _model.NumberOfCoins += value;
            _view.UpdateMoney(_model.NumberOfCoins);
        }
    }
}

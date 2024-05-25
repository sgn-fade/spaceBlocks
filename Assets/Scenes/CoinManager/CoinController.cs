using System;
using System.Collections;
using Scenes.BlockSpawner.Block;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scenes.CoinManager
{
    public class CoinController : MonoBehaviour, ICoinController
    {
        private ICoinModel _model;
        private ICoinView _view;
        private int _distance = 0;
        [SerializeField] private Text distanceView;
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

        private void Start()
        {
            StartCoroutine(DistanceCup());
        }

        private IEnumerator DistanceCup()
        {
            while (true)
            {
                _distance++;
                UpdateDistanceView();
                yield return new WaitForSeconds(0.4f);
            }
        }

        private void UpdateDistanceView()
        {
            distanceView.text = _distance.ToString();
        }

        public void UpdateMoney(int value)
        {
            _model.NumberOfCoins += value;
            _view.UpdateMoney(_model.NumberOfCoins);
        }
    }
}

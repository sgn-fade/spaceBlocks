using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Player
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private Text text;
        [SerializeField] private GameObject costButton;
        [SerializeField] private GameObject ConfirmPanel;
        private float _remainingTime;

        public void SetHpText(int value)
        {
            text.text = value.ToString();
        }

        private void OnEnable()
        {
            PlayerController.PlayerRevive += OnPlayerRevive;
        }

        private void OnPlayerRevive()
        {
            costButton.SetActive(false);
        }

        private void OnDisable()
        {
            PlayerController.PlayerRevive -= OnPlayerRevive;
        }

        public void StartDeathTimer()
        {
            costButton.SetActive(true);
            _remainingTime = 300.0f;
        }

        private void Update()
        {
            if (_remainingTime > 0)
            {
                _remainingTime -= Time.deltaTime;
                text.text = (int)_remainingTime / 60 + ":" + (int)(_remainingTime % 60);
                text.color = Color.white;
            }
        }

        public void OnReviveButtonPressed()
        {
            ConfirmPanel.SetActive(true);
        }
        public void OnNoConfirmPressed()
        {
            ConfirmPanel.SetActive(false);
        }
        public void OnYesConfirmPressed()
        {
            ConfirmPanel.SetActive(false);
            _remainingTime = 0;
        }

    }
}

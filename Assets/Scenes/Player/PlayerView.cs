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
        private float _remainingTime;

        public void SetHpText(int value)
        {
            text.text = value.ToString();
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
                text.text = (int)_remainingTime / 60 + ":" + _remainingTime % 60;
                text.color = Color.white;
            }
        }


    }
}

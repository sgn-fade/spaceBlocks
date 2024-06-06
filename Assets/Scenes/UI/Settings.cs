using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.UI
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSourceMusic;

        [SerializeField] private Toggle musicToggle;
        [SerializeField] private Toggle audioToggle;
        private static bool _isAudioEnabled;

        public void OnSettingsPressed()
        {
            Time.timeScale = 0f;
            gameObject.SetActive(true);
        }

        public void OnExitPressed()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }

        private void OnToggleMusic(bool value)
        {
            if (value)
            {
                audioSourceMusic.Play();
            }
            else
            {
                audioSourceMusic.Stop();
            }
        }

        public static bool IsAudioEnabled() => _isAudioEnabled;

        private static void OnToggleAudio(bool value)
        {
            _isAudioEnabled = value;
        }

        private void OnEnable()
        {
            musicToggle.onValueChanged.AddListener(OnToggleMusic);
            audioToggle.onValueChanged.AddListener(OnToggleAudio);
        }

        private void OnDisable()
        {
            musicToggle.onValueChanged.RemoveListener(OnToggleMusic);
            audioToggle.onValueChanged.RemoveListener(OnToggleAudio);
        }
    }
}
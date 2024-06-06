using System;
using UnityEngine;

namespace Scenes.UI
{
    public class Chest : MonoBehaviour
    {
        [SerializeField] private GameObject chestUi;
        [SerializeField] private GameObject chest;
        [SerializeField] private GameObject chestButton;

        private static readonly int ButtonPressed = Animator.StringToHash("ButtonPressed");
        private static readonly int Reset = Animator.StringToHash("Reset");

        public void OnButtonPressed()
        {
            chestUi.SetActive(true);
        }

        public void OnChestOpened()
        {
            chest.GetComponent<Animator>().SetBool(ButtonPressed, true);
            chestButton.SetActive(false);
        }

        public void ResetUi()
        {
            chest.GetComponent<Animator>().SetBool(ButtonPressed, false);
            chest.GetComponent<Animator>().SetBool(Reset, true);
            chestButton.SetActive(true);
            chestUi.SetActive(false);
        }
    }
}

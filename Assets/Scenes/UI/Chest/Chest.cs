using System;
using Scenes.CoinManager;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.UI
{
    public class Chest : MonoBehaviour
    {
        [SerializeField] private GameObject chestUi;
        [SerializeField] private GameObject chest;
        [SerializeField] private GameObject chestButton;
        [SerializeField] private CoinController coinController;
        [SerializeField] private Text notEnoughText;

        private static readonly int ButtonPressed = Animator.StringToHash("ButtonPressed");
        private static readonly int Reset = Animator.StringToHash("Reset");

        public void OnButtonPressed()
        {
            chestUi.SetActive(true);
        }

        public void OnChestOpened()
        {
            if (!coinController.PayMoney(10))
            {
                notEnoughText.gameObject.SetActive(true);
                return;
            }
            notEnoughText.gameObject.SetActive(false);
            chest.GetComponent<Animator>().SetBool(ButtonPressed, true);
            chestButton.SetActive(false);
        }

        public void ResetUi()
        {
            notEnoughText.gameObject.SetActive(false);
            chest.GetComponent<Animator>().SetBool(ButtonPressed, false);
            chest.GetComponent<Animator>().SetBool(Reset, true);
            chestButton.SetActive(true);
            chestUi.SetActive(false);
        }
    }
}

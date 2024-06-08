using System.Collections;
using System.Collections.Generic;
using Scenes.CoinManager;
using Scenes.UI;
using UnityEngine;
using UnityEngine.UI;

public class ChestCoinManager : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private CoinController coinController;
    [SerializeField] private Chest chestUi;
    private int coinValue;
    public void OnAnimationEnded()
    {
        coinText.gameObject.SetActive(true);
        coinValue = Random.Range(1, 5);

        coinValue = coinValue <= 3 ? Random.Range(1, 12) : Random.Range(12, 100);
        coinText.text = coinValue.ToString();
    }

    public void OnClaimPressed()
    {
        coinController.AddMoney(coinValue);
        coinText.gameObject.SetActive(false);
        chestUi.ResetUi();
    }
}

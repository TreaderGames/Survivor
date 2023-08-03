using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class UIGameInfo : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] TextMeshProUGUI coinCountText;
    [SerializeField] TextMeshProUGUI higestCountText;

    #region Untiy
    private void OnEnable()
    {
        PlayerHealthController.Instance.AddListener(HandleHealthUpdated);
        CoinTracker.Instance.AddCoinCountUpdatedListener(HandleCoinUpdated);
    }

    private void OnDisable()
    {
        PlayerHealthController.Instance?.RemoveListener(HandleHealthUpdated); 
        CoinTracker.Instance?.RemoveCountUpdatedListener(HandleCoinUpdated);
    }

    #endregion

    #region Callback
    private void HandleHealthUpdated(int health)
    {
        if (health == 0)
        {
            health = PlayerHealthController.Instance.pPlayerHealth;
        }
        healthBar.value = (float)health / PlayerHealthController.Instance.pPlayerHealth;
    }
    private void HandleCoinUpdated(int currentCoins, int higestCoins)
    {
        coinCountText.text = "Coins: " + currentCoins;
        higestCountText.text = "Highest Coins: " + higestCoins;
    }
    #endregion
}

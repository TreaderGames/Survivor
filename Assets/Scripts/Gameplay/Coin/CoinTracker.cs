using System;
using UnityEngine;

public class CoinTracker : Singleton<CoinTracker>
{
    [SerializeField] CoinSpawner coinSpawner;

    int coinCount = 0;
    int higestCoinCount = 0;

    Action<int, int> coinCountUpdated;

    #region Unity
    private void OnEnable()
    {
        coinSpawner.AddCoinCollectedListener(HandleCoinCollected);
        PlayerHealthController.Instance.AddListener(HandlePlayerHealthUpdated);
    }

    private void OnDisable()
    {
        coinSpawner.RemoveCoinCollectedListener(HandleCoinCollected); 
        PlayerHealthController.Instance.RemoveListener(HandlePlayerHealthUpdated);
    }

    #endregion

    #region Public
    public void AddCoinCountUpdatedListener(Action<int, int> action)
    {
        coinCountUpdated += action;
    }

    public void RemoveCountUpdatedListener(Action<int, int> action)
    {
        coinCountUpdated -= action;
    }
    #endregion

    #region Callback
    private void HandleCoinCollected()
    {
        coinCount++;
        coinCountUpdated?.Invoke(coinCount, higestCoinCount);
    }

    private void HandlePlayerHealthUpdated(int health)
    {
        if(health == 0)
        {
            higestCoinCount = coinCount > higestCoinCount ? coinCount : higestCoinCount;
            coinCount = 0; 

            coinCountUpdated?.Invoke(coinCount, higestCoinCount);
        }
    }
    #endregion
}

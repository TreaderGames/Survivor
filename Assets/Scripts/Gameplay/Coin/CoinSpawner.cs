using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Singleton<CoinSpawner>
{
    [SerializeField] Coin coinTemplate;

    Action onCoinCollected;
    Queue<Coin> inactiveCoins = new Queue<Coin>();

    #region Public
    public void SpawnCoin(Vector3 position)
    {
        Coin coin;
        if(inactiveCoins.Count > 0)
        {
            coin = inactiveCoins.Dequeue();
        }
        else
        {
            coin = Instantiate(coinTemplate, transform);
            coin.AddCollectedListener(HandleCoinCollected);
        }

        coin.transform.localPosition = position;
        coin.gameObject.SetActive(true);
    }

    public void AddCoinCollectedListener(Action action)
    {
        onCoinCollected += action;
    }

    public void RemoveCoinCollectedListener(Action action)
    {
        onCoinCollected -= action;
    }
    #endregion

    #region Callback
    private void  HandleCoinCollected(Coin coin)
    {
        inactiveCoins.Enqueue(coin);
        onCoinCollected?.Invoke();
    }
    #endregion
}

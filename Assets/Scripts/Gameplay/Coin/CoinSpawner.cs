using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Singleton<CoinSpawner>, IReset
{
    [SerializeField] Coin coinTemplate;

    Action onCoinCollected;
    Queue<Coin> inactiveCoins = new Queue<Coin>();
    List<Coin> activeCoins = new List<Coin>();

    #region Unity

    private void Start()
    {
        ResetGame.Instance.AddResetableListener(this);
    }

    #endregion

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
        activeCoins.Add(coin);
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

    public void DoReset()
    {
        for (int i = 0; i < activeCoins.Count; i++)
        {
            activeCoins[i].gameObject.SetActive(false);
        }

        activeCoins.Clear();
    }
    #endregion

    #region Callback
    private void  HandleCoinCollected(Coin coin)
    {
        inactiveCoins.Enqueue(coin);
        activeCoins.Remove(coin);
        onCoinCollected?.Invoke();
    }
    #endregion
}

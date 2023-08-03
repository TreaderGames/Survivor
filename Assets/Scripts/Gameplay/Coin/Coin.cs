using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Action<Coin> coinCollected;

    #region Unity
    private void OnDestroy()
    {
        coinCollected = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(GameTags.PLAYER_TAG))
        {
            coinCollected?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
    #endregion

    #region Public
    public void AddCollectedListener(Action<Coin> action)
    {
        coinCollected += action;
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public bool isTouchingPlayer;

    const string PLAYER_TAG = "Player";
    #region Untiy

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(PLAYER_TAG))
        {
            Debug.Log("Touching player");
            isTouchingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(PLAYER_TAG))
        {
            Debug.Log("Player moved away");
            isTouchingPlayer = false;
        }
    }
    #endregion
}

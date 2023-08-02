using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float currentDelta = 0;
    Vector3 currentDirection;

    #region Unity
    private void Update()
    {
        DoMove();
    }
    #endregion
    #region Public
    public void Fire(Vector3 direction, Vector3 startingPos)
    {
        currentDelta = 0;
        currentDirection = direction;
        gameObject.SetActive(true);
        transform.position = startingPos;
    }
    #endregion

    #region Private
    private void DoMove()
    {
        if(currentDelta < GameConfig.bulletLife)
        {
            currentDelta += Time.deltaTime;
            gameObject.transform.position += currentDirection * (Time.deltaTime * GameConfig.bulletSpeed);
        }
        else
        {
            Debug.Log("Bullet Update");
            gameObject.SetActive(false);
        }
    }
    #endregion
}

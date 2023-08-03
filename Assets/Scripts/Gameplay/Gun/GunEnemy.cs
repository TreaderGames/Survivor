using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : Gun
{
    Transform playerTransform;

    #region Unity
    private void Awake()
    {
        playerTransform = FindObjectOfType<PlayerBase>().transform;
    }

    private void Start()
    {
        StartCoroutine(RepeatingFire());
    }
    #endregion

    #region Private

    IEnumerator RepeatingFire()
    {
        while(gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(GameConfig.gunInterval);
            FireGun(playerTransform.position, GameTags.PLAYER_TAG, Bullet.BulletTarget.Player);
        }
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayer : Gun
{
    Transform currentTarget;

    #region Unity

    private void Start()
    {
        StartCoroutine(RepeatingFire());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(GameTags.ENEMY_TAG))
        {
            currentTarget = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(currentTarget == collision.transform)
        {
            currentTarget = null;
        }
    }
    #endregion

    #region Private
    IEnumerator RepeatingFire()
    {
        while (gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(GameConfig.gunInterval);
            if (currentTarget != null)
            {
                FireGun(currentTarget.position, GameTags.ENEMY_TAG);
            }
        }
    }
    #endregion
}

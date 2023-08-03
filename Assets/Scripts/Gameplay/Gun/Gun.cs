using UnityEngine;

public class Gun : MonoBehaviour
{
    #region Protected
    protected void FireGun(Vector3 target, string targetTag, Bullet.BulletTarget bulletTarget)
    {
        Vector3 normlizedDirection;
        Bullet bullet = PoolHandler.Instance.SpawnElementFromPool(PoolKeys.BULLET_POOL_KEY).GetComponent<Bullet>();
        bullet.pBulletTarget = bulletTarget;

        normlizedDirection = Vector3.Normalize(target - transform.position);
        bullet.Fire(normlizedDirection, transform.position, targetTag);
    }
    #endregion
}

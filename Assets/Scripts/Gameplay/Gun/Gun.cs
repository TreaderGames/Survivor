using UnityEngine;

public class Gun : MonoBehaviour
{
    Transform playerTransform;
    #region Unity
    private void Awake()
    {
        playerTransform = FindObjectOfType<PlayerBase>().transform;
    }

    private void Start()
    {
        InvokeRepeating("FireGun", 0, GameConfig.gunInterval);
    }
    #endregion

    #region Private
    private void FireGun()
    {
        Vector3 normlizedDirection;
        Bullet bullet = PoolHandler.Instance.SpawnElementFromPool(PoolKeys.BULLET_POOL_KEY).GetComponent<Bullet>();

        normlizedDirection = Vector3.Normalize(playerTransform.position - transform.position);
        bullet.Fire(normlizedDirection, transform.position);
    }
    #endregion
}

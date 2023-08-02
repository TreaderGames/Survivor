using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] int initialPoolSize = 15;
    [SerializeField] GameObject bulletTemplate;

    #region Unity
    private void Awake()
    {
        PoolHandler.Instance.CreatePool(PoolKeys.BULLET_POOL_KEY, initialPoolSize, bulletTemplate, transform, false);
    }
    #endregion
}

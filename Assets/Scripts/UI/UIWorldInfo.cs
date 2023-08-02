using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWorldInfo : MonoBehaviour
{
    [SerializeField] RectTransform ground;

    Vector3 boundsMin;
    Vector3 boundsMax;

    public Vector3 pBoundsMin { get => boundsMin; }
    public Vector3 pBoundsMax { get => boundsMax; }

    #region Unity

    private void Awake()
    {
        boundsMin = new Vector3(ground.rect.xMin, ground.rect.yMin, 0);
        boundsMax = new Vector3(ground.rect.xMax, ground.rect.yMax, 0);
    }
    #endregion
}

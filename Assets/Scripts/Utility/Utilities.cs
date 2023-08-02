using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static Vector3 GetRandom2DPosWithingBounds(Vector3 min, Vector3 max)
    {
        Vector3 randomPos = Vector3.zero;
        randomPos.x = Random.Range(min.x, max.x);
        randomPos.y = Random.Range(min.y, max.y);

        return randomPos;
    }
}

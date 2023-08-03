using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ResetGame : MonoBehaviour
{
    List<IReset> resetAbles = new List<IReset>();

    #region Untiy
    private void Start()
    {
        IEnumerable enumerable = FindObjectsOfType<MonoBehaviour>().OfType<IReset>();

        foreach (IReset item in enumerable)
        {
            resetAbles.Add(item);
        }

        PlayerHealthController.Instance.AddListener(HandlePlayerHealth);
    }
    #endregion

    #region Private
    private void ResetMatch()
    {
        foreach (var item in resetAbles)
        {
            item.DoReset();
        }
    }
    #endregion

    #region Callback
    private void HandlePlayerHealth(int health)
    {
        if (health == 0)
        {
            ResetMatch();
        }
    }
    #endregion
}

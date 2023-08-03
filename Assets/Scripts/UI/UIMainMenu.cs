using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] GameObject world;

    #region Public
    public void OnClickStart()
    {
        world.SetActive(true);
    }
    #endregion
}

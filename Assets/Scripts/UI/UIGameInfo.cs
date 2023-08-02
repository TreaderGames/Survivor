using UnityEngine.UI;
using UnityEngine;
using System;

public class UIGameInfo : MonoBehaviour
{
    [SerializeField] Slider healthBar;

    #region Untiy
    private void OnEnable()
    {
        PlayerHealthController.Instance.AddListener(HandleHealthUpdated);
    }

    private void OnDisable()
    {
        PlayerHealthController.Instance.AddListener(HandleHealthUpdated);
    }

    #endregion

    #region Callback
    private void HandleHealthUpdated(int health)
    {
        if (health == 0)
        {
            health = PlayerHealthController.Instance.pPlayerHealth;
        }
        healthBar.value = (float)health / PlayerHealthController.Instance.pPlayerHealth;
    }
    #endregion
}

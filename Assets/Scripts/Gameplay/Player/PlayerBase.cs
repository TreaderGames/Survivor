using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    #region Unity

    private void OnEnable()
    {
        PlayerHealthController.Instance.AddListener(HandleHealthUpdated);
    }

    private void OnDisable()
    {
        PlayerHealthController.Instance?.RemoveListener(HandleHealthUpdated);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(GameTags.BULLT_TAG))
        {
            PlayerHealthController.Instance.HitByBullet();
        }
    }
    #endregion    

    #region Private
    private void HandleHealthUpdated(int health)
    {
        if (health == 0)
        {
            transform.position = Vector3.zero;
        }
    }
    #endregion
}

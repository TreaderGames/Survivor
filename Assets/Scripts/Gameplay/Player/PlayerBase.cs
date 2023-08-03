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
        if (collision.CompareTag(GameTags.BULLT_TAG) && collision.GetComponent<Bullet>().pBulletTarget.Equals(Bullet.BulletTarget.Player))
        {
            PlayerHealthController.Instance.HitByBullet();
        }
        else if (collision.CompareTag(GameTags.ENEMY_TAG))
        {
            PlayerHealthController.Instance.UpdateEnemyContract(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTags.ENEMY_TAG))
        {
            PlayerHealthController.Instance.UpdateEnemyContract(false);
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

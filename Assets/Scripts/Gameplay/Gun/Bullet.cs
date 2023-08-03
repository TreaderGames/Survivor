using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletTarget
    {
        Player,
        Enemy
    }

    float currentDelta = 0;
    Vector3 currentDirection;
    string targetTag;

    public BulletTarget pBulletTarget { get; set; }

    #region Unity
    private void Update()
    {
        DoMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            currentDelta = GameConfig.bulletLife; //Disable bullet
        }
    }
    #endregion

    #region Public
    public void Fire(Vector3 direction, Vector3 startingPos, string inTargetTag)
    {
        currentDelta = 0;
        targetTag = inTargetTag;
        currentDirection = direction;
        gameObject.SetActive(true);
        transform.position = startingPos;
    }

    #endregion

    #region Private
    private void DoMove()
    {
        if(currentDelta < GameConfig.bulletLife)
        {
            currentDelta += Time.deltaTime;
            gameObject.transform.position += currentDirection * (Time.deltaTime * GameConfig.bulletSpeed);
        }
        else
        {
            Debug.Log("Bullet Update");
            gameObject.SetActive(false);
        }
    }
    #endregion
}

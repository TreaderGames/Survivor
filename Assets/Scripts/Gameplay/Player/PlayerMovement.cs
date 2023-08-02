using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] UIWorldInfo worldInfo;
    [SerializeField] FixedJoystick fixedJoystick;
    [SerializeField] float speed;

    Vector3 minBouds, maxBounds;
    #region Unity
    private void Start()
    {
        minBouds = transform.localToWorldMatrix * worldInfo.pBoundsMin;
        maxBounds = transform.localToWorldMatrix * worldInfo.pBoundsMax;
    }

    // Update is called once per frame
    void Update()
    {
        DoMove();
    }
    #endregion

    #region Private
    private void DoMove()
    {
        Vector3 newMoveVector = transform.position;
        if(fixedJoystick.Direction != Vector2.zero)
        {
            newMoveVector += (Vector3)fixedJoystick.Direction * Time.deltaTime * speed;

            newMoveVector.x = Mathf.Clamp(newMoveVector.x, minBouds.x, maxBounds.x);
            newMoveVector.y = Mathf.Clamp(newMoveVector.y, minBouds.y, maxBounds.y);

            transform.position = newMoveVector;
        }
    }
    #endregion
}

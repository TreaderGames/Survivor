using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] FixedJoystick fixedJoystick;
    [SerializeField] float speed;

    #region Unity
    // Update is called once per frame
    void Update()
    {
        DoMove();
    }
    #endregion

    #region Private
    private void DoMove()
    {
        if(fixedJoystick.Direction != Vector2.zero)
        {
            transform.position += (Vector3)fixedJoystick.Direction * Time.deltaTime * speed;
        }
    }
    #endregion
}

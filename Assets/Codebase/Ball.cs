using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    public Rigidbody2D Rb;
    public float Speed;
    public Vector2 Direction;

    public Transform PadTransform;
    public float YOffsetFromPad;

    private bool _isStarted;

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (_isStarted)
        {
            return;
        }

        MoveBallWithPad();
        
        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Direction);
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(transform.position, Rb.velocity);
    }

    #endregion


    #region Private methods

    private void MoveBallWithPad()
    {
        Vector3 currentPosition = PadTransform.position;
        currentPosition.y += YOffsetFromPad;
        transform.position = currentPosition;
    }

    private void StartBall()
    {
        Rb.velocity = Direction.normalized * Speed;
        _isStarted = true;
    }

    #endregion
}
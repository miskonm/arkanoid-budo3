using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    [Header("Base Settings")]
    public Rigidbody2D Rb;
    public float Speed;
    public Vector2 Direction;

    [Header("Pad Settings")]
    public Transform PadTransform;
    public float YOffsetFromPad;

    [Header("Audio")]
    public AudioSource AudioSource;

    private bool _isStarted;
    private float _currentSpeed;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        if (GameManager.Instance.NeedAutoplay)
        {
            StartBall();
        }
    }

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

    private void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        
        if (!_isStarted)
        {
            Gizmos.DrawRay(transform.position, Direction * Speed);
        }
    }

    #endregion


    #region Public methods

    public void Restart()
    {
        _isStarted = false;
    }
    
    public void ChangeSpeed(float speedMultiplier)
    {
        _currentSpeed *= speedMultiplier;
        
        Vector2 currentDirection = Rb.velocity.normalized;
        Rb.velocity = currentDirection * _currentSpeed;
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
        _currentSpeed = Speed;
        Rb.velocity = Direction.normalized * _currentSpeed;
        _isStarted = true;
    }

    #endregion


    
}
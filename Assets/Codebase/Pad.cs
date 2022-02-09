using UnityEngine;

public class Pad : MonoBehaviour
{
    #region Variables

    private Transform _ballTransform;

    #endregion
    
    #region Unity lifecycle

    private void Start()
    {
        _ballTransform = FindObjectOfType<Ball>().transform;
    }

    private void Update()
    {
        if (GameManager.Instance.NeedAutoplay)
        {
            MovePadWithBall();
        }
        else
        {
            MovePadWithMouse();
        }
    }

    #endregion


    #region Private methods

    private void MovePadWithMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 currentPosition = transform.position;
        currentPosition.x = worldPosition.x;
        transform.position = currentPosition;
    }

    private void MovePadWithBall()
    {
        Vector3 ballWorldPosition = _ballTransform.position;

        Vector3 currentPosition = transform.position;
        currentPosition.x = ballWorldPosition.x;
        transform.position = currentPosition;
    }

    #endregion
}
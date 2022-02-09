using UnityEngine;

public class BottomWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(Tags.Ball))
        {
            Ball ball = col.gameObject.GetComponent<Ball>();
            ball.Restart();
            
            // GameManager.Instance.RemoveLive();
            GameManager.Instance.CurrentLives--;
        }
    }
}
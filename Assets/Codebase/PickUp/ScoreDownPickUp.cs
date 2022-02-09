using UnityEngine;

public class ScoreDownPickUp : MonoBehaviour
{
    [SerializeField] private int _scoreToDown;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(Tags.Pad))
        {
            GameManager.Instance.AddScore(_scoreToDown);
            Destroy(gameObject);
        }
    }
}
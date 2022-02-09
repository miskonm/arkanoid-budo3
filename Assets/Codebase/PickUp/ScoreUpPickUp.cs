using UnityEngine;

public class ScoreUpPickUp : MonoBehaviour
{
    [SerializeField] private int _scoreToAdd;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(Tags.Pad))
        {
            GameManager.Instance.AddScore(_scoreToAdd);
            Destroy(gameObject);
        }
    }
}
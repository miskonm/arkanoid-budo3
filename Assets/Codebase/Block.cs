using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables

    public AudioClip AudioClip;
    public int Score = 5;

    #endregion


    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        AudioManager.Instance.PlayOnShot(AudioClip);
        GameManager.Instance.AddScore(Score);
        Destroy(gameObject);
    }

    #endregion
}
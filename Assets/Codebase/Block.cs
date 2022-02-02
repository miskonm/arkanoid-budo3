using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables

    public AudioClip AudioClip;
    public int Score = 5;

    #endregion


    #region Events

    public static event Action OnCreated;
    public static event Action<Block> OnDestroyed;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        OnCreated?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        AudioManager.Instance.PlayOnShot(AudioClip);

        Destroy(gameObject);

        OnDestroyed?.Invoke(this);
    }

    #endregion
}
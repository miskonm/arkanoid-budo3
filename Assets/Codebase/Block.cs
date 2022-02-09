using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    #region Variables

    [Header("Base Settings")]
    public AudioClip AudioClip;
    public int Score = 5;
    
    [Header("Pick Up")]
    [SerializeField] private GameObject _pickUpPrefab;
    
    [Range(0f, 100f)]
    [SerializeField] private float _pickUpChance;
    

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
        if (!col.gameObject.CompareTag(Tags.Ball))
            return;
        
        AudioManager.Instance.PlayOnShot(AudioClip);

        CreatePickUpIfNeeded();
        
        Destroy(gameObject);

        OnDestroyed?.Invoke(this);
    }

    #endregion


    #region Private methods

    private void CreatePickUpIfNeeded()
    {
        float randomChance = Random.Range(0.1f, 100f);

        if (_pickUpChance >= randomChance)
        {
            Instantiate(_pickUpPrefab, transform.position, Quaternion.identity);
        }
    }

    #endregion
}
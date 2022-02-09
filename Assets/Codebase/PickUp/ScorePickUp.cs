using UnityEngine;

public class ScorePickUp : PickUpBase
{
    [SerializeField] private int _scoreToAdd;

    protected override void Start()
    {
        base.Start();
        
        // New logic
    }

    protected override void ApplyPickUp()
    {
        GameManager.Instance.AddScore(_scoreToAdd);
    }
}
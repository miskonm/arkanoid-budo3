using UnityEngine;

public class ChangeBallSpeedPickUp : PickUpBase
{
    [SerializeField] private float _speedMultiplier;

    protected override void ApplyPickUp()
    {
        Ball ball = FindObjectOfType<Ball>();
        ball.ChangeSpeed(_speedMultiplier);
    }
}
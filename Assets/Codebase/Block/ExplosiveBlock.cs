using UnityEngine;

public class ExplosiveBlock : Block
{
    [Header(nameof(ExplosiveBlock))]
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    protected override void ApplyInternalActions()
    {
        base.ApplyInternalActions();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);

        foreach (Collider2D col in colliders)
        {
            if (col.gameObject == gameObject)
            {
                continue;
            }

            Block blockToDestroy = col.gameObject.GetComponent<Block>();
            blockToDestroy.Kill();
        }
    }
}
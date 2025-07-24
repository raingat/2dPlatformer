using UnityEngine;

public class TargetSearcher : MonoBehaviour
{
    [SerializeField] private float _radiusAction;

    [SerializeField] private LayerMask _layerMask;

    public Collider2D Locate()
    {
        Collider2D colliderTarget = Physics2D.OverlapCircle(transform.position, _radiusAction, _layerMask);

        return colliderTarget;
    }
}

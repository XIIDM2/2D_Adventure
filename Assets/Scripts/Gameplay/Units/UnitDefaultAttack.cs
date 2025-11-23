using UnityEngine;
using System.Collections.Generic;

public class UnitDefaultAttack : MonoBehaviour, IAttackable
{
    [SerializeField] private int _damage = 10;

    [SerializeField] private BoxCollider2D _attackRange;

    private List<Collider2D> _hits = new List<Collider2D>(5);

    private LayerMask _filterMasks;
    private ContactFilter2D _filter;

    private void Start()
    {
        _filterMasks = LayerMask.GetMask("Mob");

        _filter = new ContactFilter2D();

        _filter.useLayerMask = true;
        _filter.layerMask = _filterMasks;

        _filter.useTriggers = false;
    }

    public void Attack()
    {
        int hits = _attackRange.Overlap(_filter, _hits);

        foreach (Collider2D hit in _hits)
        {
            if (hit.TryGetComponent<Health>(out Health health))
            {
                health.TakeDamage(_damage);
            }
        }
         
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_attackRange.bounds.center, _attackRange.bounds.size);
    }
}

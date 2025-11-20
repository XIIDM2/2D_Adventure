using UnityEngine;

public class UnitAttack : MonoBehaviour, IAttackable
{
    [SerializeField] private int _damage;

    [SerializeField] private Transform _attackBox;
    [SerializeField] private Vector2 _attackBoxRange;

    private int _DamagableLayer;

    private void Start()
    {
        _DamagableLayer = LayerMask.GetMask("Damagable");
    }

    public void Attack()
    {
        Collider2D[] damagableObjects = Physics2D.OverlapBoxAll(_attackBox.position, _attackBoxRange, 0.0f, _DamagableLayer);

        foreach (Collider2D damagableObject in damagableObjects)
        {
            if (damagableObject.TryGetComponent<Health>(out Health health))
            {
                health.TakeDamage(_damage);
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_attackBox.position, _attackBoxRange);
    }
}

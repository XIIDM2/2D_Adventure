using UnityEngine;
using UnityEngine.Events;

public enum UnitAnimationParameter
{
    IsMoving,
    IsAttacking,
    StopAttack,
}

public class UnitAnimation : MonoBehaviour
{
    public event UnityAction OnAttackHit;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetFloat(UnitAnimationParameter parameter, int value)
    {
        _animator.SetFloat(parameter.ToString(), value);
    }

    public void SetBool(UnitAnimationParameter parameter, bool value)
    {
        _animator.SetBool(parameter.ToString(), value);
    }

    public void SetTrigger(UnitAnimationParameter parameter)
    {
        _animator.SetTrigger(parameter.ToString());
    }

    public bool IsStatePlayingByTag(string name)
    {
        AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);

        return info.IsTag(name) && info.normalizedTime < 1.0f;
    }

    public void ACAttackHit()
    {
        OnAttackHit?.Invoke();
    }
}

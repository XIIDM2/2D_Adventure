using UnityEngine;
using UnityEngine.Events;

public enum UnitAnimationParameter
{

}

public class UnitAnimation : MonoBehaviour
{
    public event UnityAction AttackHit;

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

    public void OnAttackHit()
    {
        AttackHit?.Invoke();
    }
}

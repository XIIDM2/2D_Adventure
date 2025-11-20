using UnityEngine;
using UnityEngine.Events;

public class UnitAnimation : MonoBehaviour
{
    public event UnityAction AttackHit;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetFloat(string name, float value)
    {
        _animator.SetFloat(name, value);
    }

    public void SetBool(string name, bool value)
    {
        _animator.SetBool(name, value);
    }

    public void SetTrigger(string name)
    {
        _animator.SetTrigger(name);
    }

    public bool IsStatePlayingByTag(string name)
    {
        AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);

        return info.IsTag(name) && info.normalizedTime < 1.0f;
    }

    public void OnAttackHit()
    {
        AttackHit?.Invoke();
    }
}

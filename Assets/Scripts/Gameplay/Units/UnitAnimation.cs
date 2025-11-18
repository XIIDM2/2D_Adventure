using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    private Animator _animator;

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
}

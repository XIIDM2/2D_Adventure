using UnityEngine;

public class UnitController : MonoBehaviour
{
    public IControllableBase _controller { get; private set; }

    public IMovable _movement {  get; private set; }
    public IAttackable _attack { get; private set; }

    private UnitAnimation unitAnimation;

    private void Awake()
    {
        _controller = GetComponent<IControllableBase>();

        _movement = GetComponent<IMovable>();
        _attack = GetComponent<IAttackable>();

        unitAnimation = GetComponentInChildren<UnitAnimation>();
    }
}

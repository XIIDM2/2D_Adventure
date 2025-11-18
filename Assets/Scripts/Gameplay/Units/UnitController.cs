using UnityEngine;

public class UnitController : MonoBehaviour
{
    public IControllableBase _controller { get; private set; }
    public IMovable _movement {  get; private set; }
    public IAttackable _attack { get; private set; }

    private UnitAnimation unitAnimation;

    private FiniteStateMachine _movementFSM;

    private void Awake()
    {
        _controller = GetComponent<IControllableBase>();

        _movement = GetComponent<IMovable>();
        _attack = GetComponent<IAttackable>();

        unitAnimation = GetComponentInChildren<UnitAnimation>();
    }

    private void OnEnable()
    {
        _controller.OnActionTriggered += HandleAction;
    }

    private void OnDisable()
    {
        _controller.OnActionTriggered -= HandleAction;
    }

    private void Start()
    {
        _movementFSM = new FiniteStateMachine();
        _movementFSM.StateInit(new WarriorIdleState(), this);
    }

    private void Update()
    {
        _movementFSM.UpdateState(this);
    }

    private void LateUpdate()
    {
        _movementFSM.LateUpdateState(this);
    }

    private void FixedUpdate()
    {
        _movementFSM.FixedUpdateState(this);
    }

    public void HandleAction(ActionDataBase actionDataBase)
    {
        _movementFSM.HandleAction(this, actionDataBase);
    }
}

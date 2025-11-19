using UnityEngine;

public class UnitController : MonoBehaviour
{
    public IControllableBase Controller { get; private set; }
    public IMovable Movement {  get; private set; }
    public IAttackable Attack { get; private set; }

    public UnitAnimation Animation { get; private set; }

    public FiniteStateMachine MovementFSM { get; private set; }

    private void Awake()
    {
        Controller = GetComponent<IControllableBase>();

        Movement = GetComponent<IMovable>();
        Attack = GetComponent<IAttackable>();

        Animation = GetComponentInChildren<UnitAnimation>();
    }

    private void OnEnable()
    {
        Controller.OnActionTriggered += HandleAction;
    }

    private void OnDisable()
    {
        Controller.OnActionTriggered -= HandleAction;
    }

    private void Start()
    {
        MovementFSM = new FiniteStateMachine();
        MovementFSM.StateInit(new GroundIdleState(), this);
    }

    private void Update()
    {
        MovementFSM.UpdateState(this);
    }

    private void LateUpdate()
    {
        MovementFSM.LateUpdateState(this);
    }

    private void FixedUpdate()
    {
        MovementFSM.FixedUpdateState(this);
    }

    public void HandleAction(ActionDataBase actionDataBase)
    {
        MovementFSM.HandleAction(this, actionDataBase);
    }
}

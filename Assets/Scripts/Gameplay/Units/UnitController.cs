using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public IControllableBase Controller { get; private set; }
    public IMovable Movement {  get; private set; }
    public IAttackable Attack { get; private set; }

    public UnitAnimation Animation { get; private set; }

    public FiniteStateMachine MovementFSM { get; private set; }
    public FiniteStateMachine AttackFSM { get; private set; }

    private List<FiniteStateMachine> _finiteStateMachines = new List<FiniteStateMachine>();

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
        Animation.AttackHit += Attack.Attack;
    }

    private void OnDisable()
    {
        Controller.OnActionTriggered -= HandleAction;
        Animation.AttackHit -= Attack.Attack;
    }

    private void Start()
    {
        MovementFSM = new FiniteStateMachine();
        MovementFSM.StateInit(new GroundIdleState(), this);

        AttackFSM = new FiniteStateMachine();
        AttackFSM.StateInit(new NonAttackState(), this);

        _finiteStateMachines.Add(MovementFSM);
        _finiteStateMachines.Add(AttackFSM);

    }

    private void Update()
    {
        foreach (FiniteStateMachine fsm in _finiteStateMachines)
        {
            fsm.UpdateState(this);
        }
    }

    private void LateUpdate()
    {
        foreach (FiniteStateMachine fsm in _finiteStateMachines)
        {
            fsm.LateUpdateState(this);
        }
    }

    private void FixedUpdate()
    {
        foreach (FiniteStateMachine fsm in _finiteStateMachines)
        {
            fsm.FixedUpdateState(this);
        }
    }

    public void HandleAction(ActionDataBase action)
    {
        foreach (FiniteStateMachine fsm in _finiteStateMachines)
        {
            fsm.HandleAction(this, action);
        }
    }
}

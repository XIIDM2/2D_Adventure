using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class UnitController : MonoBehaviour, IMovementContext
{
    public bool IsGrounded {  get; private set; }

    public IActionInvoker Controller {  get; private set; }
    public IAttackable Attack {  get; private set; }
    public IMoveable Movement {  get; private set; }
    public UnitAnimation Animation {  get; private set; }
    public FiniteStateMachine MovementFSM {  get; private set; }

    private List<FiniteStateMachine> _fsmachines = new List<FiniteStateMachine>();
    private State _idleState;

    private void Awake()
    {
        Controller = GetComponent<IActionInvoker>();
        Attack = GetComponent<IAttackable>();
        Movement = GetComponent<IMoveable>();
        Animation = GetComponent<UnitAnimation>();
    }

    private void Start()
    {
        _idleState = new IdleState();

        MovementFSM = new FiniteStateMachine();
        MovementFSM.StateInit(_idleState, this);

        _fsmachines.Add(MovementFSM);
    }

    private void Update()
    {
        foreach (FiniteStateMachine fsm in _fsmachines)
        {
            fsm.UpdateState(this, Controller.GetActions());
        }
    }

    private void LateUpdate()
    {
        foreach (FiniteStateMachine fsm in _fsmachines)
        {
            fsm.LateUpdateState(this);
        }
    }

    private void FixedUpdate()
    {
        foreach (FiniteStateMachine fsm in _fsmachines)
        {
            fsm.FixedUpdateState(this);
        }
    }

    public void SetGroundedStatus(bool value)
    {
        IsGrounded = value;
    }
}

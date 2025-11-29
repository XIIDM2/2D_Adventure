using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitController : MonoBehaviour, IMovementContext
{
    public event UnityAction<bool> OnGroundStateChanged;
    [Header("Movement Info")]
    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
        private set
        {
            if (_isGrounded == value) return;

            _isGrounded = value;
            OnGroundStateChanged?.Invoke(_isGrounded);
        }
    }

    public Vector2 Direction { get; private set; }
    public bool CanMove => _moveLocks == 0;

    private int _moveLocks = 0;
    private bool _isGrounded = true;

    [Header("Attack Info")]
    public bool CanAttack => Time.time > _lastAttackTime + _attackCooldown;

    private float _lastAttackTime = float.MinValue;
    private float _attackCooldown = 1.2f;

    public IActionInvoker ActionController {  get; private set; }
    public IAttackable Attack {  get; private set; }
    public IMoveable Movement {  get; private set; }
    public IJumpable JumpAbility { get; private set; }
    public UnitAnimation Animation {  get; private set; }

    [Header("Finite State Machines Parameters")]
    public IdleState IdleState { get; private set; }
    public MoveState MoveState { get; private set; }
    public JumpState JumpState { get; private set; }
    public NonAttackState NonAttackState { get; private set; }
    public AttackState AttackState { get; private set; }
    public FiniteStateMachine MovementFSM {  get; private set; }
    public FiniteStateMachine AttackFSM {  get; private set; }

    private List<FiniteStateMachine> _fsmachines = new List<FiniteStateMachine>();

    private void Awake()
    {
        ActionController = GetComponent<IActionInvoker>();

        Attack = GetComponent<IAttackable>();

        Movement = GetComponent<IMoveable>();
        JumpAbility = GetComponent<IJumpable>();

        Animation = GetComponentInChildren<UnitAnimation>();
    }

    private void Start()
    {
        IdleState = new IdleState();
        MoveState = new MoveState();
        JumpState = new JumpState();

        NonAttackState = new NonAttackState();
        AttackState = new AttackState();

        MovementFSM = new FiniteStateMachine();
        MovementFSM.StateInit(IdleState, this);

        AttackFSM = new FiniteStateMachine();
        AttackFSM.StateInit(NonAttackState, this);

        _fsmachines.Add(MovementFSM);
        _fsmachines.Add(AttackFSM);
    }

    private void OnEnable()
    {
        Animation.OnAttackHit += Attack.Attack;
        OnGroundStateChanged += Animation.ChangeGroundState;
    }

    private void OnDisable()
    {
        Animation.OnAttackHit -= Attack.Attack;
        OnGroundStateChanged -= Animation.ChangeGroundState;
    }

    private void Update()
    {
        Actions currentActions = ActionController.GetActions();

        Direction = currentActions.MoveDirection;

        foreach (FiniteStateMachine fsm in _fsmachines)
        {
            fsm.UpdateState(this, currentActions);
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

    public void AddMoveLock()
    {
        _moveLocks++;
    }

    public void RemoveMoveLock()
    {
        _moveLocks = Mathf.Max(0, --_moveLocks);
    }

    public void SetLastAttackTime()
    {
        _lastAttackTime = Time.time;
    }

    public void SetGroundedStatus(bool value)
    {
        IsGrounded = value;
    }
}

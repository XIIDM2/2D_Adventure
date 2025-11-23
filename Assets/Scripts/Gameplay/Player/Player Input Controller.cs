using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour, IActionInvoker
{
    private InputSystem_Actions inputActions;

    private Actions _actions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();

        _actions = new Actions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public Actions GetActions()
    {
        _actions.MoveDirection = inputActions.Player.Move.ReadValue<Vector2>();
        _actions.JumpRequested = inputActions.Player.Jump.WasPressedThisFrame();
        _actions.AttackRequested = inputActions.Player.Attack.WasPressedThisFrame();

        return _actions;
    }
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour, IActionInvoker
{
    private InputSystem_Actions inputActions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
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
        Actions actions = new Actions(
            inputActions.Player.Move.ReadValue<Vector2>(), 
            inputActions.Player.Jump.WasPressedThisFrame(),
            inputActions.Player.Attack.WasPressedThisFrame()); 

        return actions;
    }
}

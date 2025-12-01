using UnityEngine;

public class IdleState : UnitState
{
    public override State<UnitController> HandleTransitions(UnitController controller, Actions actions)
    {
        if (actions.MoveDirection != Vector2.zero) return controller.MoveState;
        else if (controller.IsGrounded && actions.JumpRequested) return controller.JumpState;

        return base.HandleTransitions(controller, actions);
    }

    public override void Enter(UnitController controller)
    {
        base.Enter(controller);

        controller.Movement.Move(Vector2.zero);
    }

    public override void Exit(UnitController controller)
    {
        base.Exit(controller);
    }
}

using UnityEngine;

public class IdleState : State
{
    public override State HandleTransitions(UnitController controller, Actions actions)
    {
        if (actions.MoveDirection != Vector2.zero) return controller.MoveState;

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

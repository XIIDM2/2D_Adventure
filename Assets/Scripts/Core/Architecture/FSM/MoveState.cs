using UnityEngine;

public class MoveState : State
{
    public override State HandleTransitions(UnitController controller, Actions actions)
    {
        if (actions.MoveDirection == Vector2.zero) return controller.IdleState;

        return base.HandleTransitions(controller, actions);
    }

    public override void Enter(UnitController controller)
    {
        base.Enter(controller);

        controller.Animation.SetBool(UnitAnimationParameter.IsMoving, true);
    }

    public override void FixedUpdate(UnitController controller)
    {
        base.FixedUpdate(controller);

        if (controller.CanMove)
        {
            controller.Movement.Move(controller.Direction);

        }
        else
        {
            controller.Movement.Move(Vector2.zero);
        }
    }

    public override void Exit(UnitController controller)
    {
        base.Exit(controller);

        controller.Animation.SetBool(UnitAnimationParameter.IsMoving, false);
    }
}

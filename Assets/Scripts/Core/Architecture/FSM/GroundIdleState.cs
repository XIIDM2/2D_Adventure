using UnityEngine;

public class GroundIdleState : State
{
    public override State HandleAction(UnitController controller, ActionDataBase action)
    {
        if (action.ActionType == ActionType.Move)
        {
            return new MoveState();
        }

        return base.HandleAction(controller, action);
    }
    public override void Enter(UnitController controller)
    {
        _direction = Vector2.zero;

        controller.Movement.Move(_direction);
    }
}

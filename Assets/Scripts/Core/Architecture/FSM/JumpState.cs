using UnityEngine;

public class JumpState : State
{
    private const float JUMP_THRESHOLD_TIME = 0.15f;
    private float _lastTimeJumped;
    public override State HandleTransitions(UnitController controller, Actions actions)
    {
        if (Time.time > _lastTimeJumped + JUMP_THRESHOLD_TIME && controller.IsGrounded)
        {
            return actions.MoveDirection == Vector2.zero ? controller.IdleState : controller.MoveState;
        }

        return base.HandleTransitions(controller, actions);
    }

    public override void Enter(UnitController controller)
    {
        base.Enter(controller);

        _lastTimeJumped = Time.time;

        controller.Animation.SetTrigger(UnitAnimationParameter.Jump);

        controller.JumpAbility.Jump();

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
}

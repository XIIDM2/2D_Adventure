using UnityEngine;

public class MoveState : State
{
    private float _idleTransitionTimer = 0.0f;
    private float _idleTransitionTime = 0.01f;
    public override State HandleTransition(UnitController controller)
    {
        if (Mathf.Approximately(controller.Movement.Velocity.x, 0.0f))
        {
            _idleTransitionTimer += Time.deltaTime;

            if (_idleTransitionTimer >= _idleTransitionTime) return new GroundIdleState();
        }

        return base.HandleTransition(controller);
    }

    public override void Update(UnitController controller)
    {
        base.Update(controller);

        controller.Animation.SetFloat("X Velocity", Mathf.Abs(controller.Movement.Velocity.x));
    }

    public override void Exit(UnitController controller)
    {
        base.Exit(controller);

        controller.Animation.SetFloat("X Velocity", 0);
    }
}

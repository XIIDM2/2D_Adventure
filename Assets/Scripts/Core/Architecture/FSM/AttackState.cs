using UnityEngine;

public class AttackState : State
{
    private const string ATTACK_TAG = "Attack";

    public override State HandleTransitions(UnitController controller, Actions actions)
    {
        if (!controller.Animation.IsStatePlayingByTag(ATTACK_TAG)) return controller.NonAttackState;

        return base.HandleTransitions(controller, actions);
    }

    public override void Enter(UnitController controller)
    {
        base.Enter(controller);

        controller.AddMoveLock();

        controller.SetLastAttackTime();

        controller.Animation.SetBool(UnitAnimationParameter.IsAttacking, true);
    }

    public override void Exit(UnitController controller)
    {
        base.Exit(controller);

        controller.RemoveMoveLock();

        controller.Animation.SetBool(UnitAnimationParameter.IsAttacking, false);

    }
}

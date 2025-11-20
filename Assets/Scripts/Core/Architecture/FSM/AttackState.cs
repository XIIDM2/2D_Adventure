using UnityEngine;

public class AttackState : State
{
    private bool _isAnimationTransitionFinished = false;
    public override State HandleTransition(UnitController controller)
    {
        if (!_isAnimationTransitionFinished)
        {
            if (controller.Animation.IsStatePlayingByTag("Attack"))
            {
                _isAnimationTransitionFinished = true;
            }
            else
            {
                return null;
            }
        }

        if (!controller.Animation.IsStatePlayingByTag("Attack"))
        {
            return new NonAttackState();
        }

        return base.HandleTransition(controller);
    }

    public override void Enter(UnitController controller)
    {
        base.Enter(controller);

        controller.Animation.SetTrigger("Attack");
    }

    public override void Exit(UnitController controller)
    {
        base.Exit(controller);
    }
}

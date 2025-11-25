using UnityEngine;

public class NonAttackState : State
{
    public override State HandleTransitions(UnitController controller, Actions actions)
    {
        if (controller.IsGrounded && actions.AttackRequested && controller.CanAttack) return controller.AttackState;

        return base.HandleTransitions(controller, actions);
    }
}

using UnityEngine;

public class NonAttackState : UnitState
{
    public override State<UnitController> HandleTransitions(UnitController controller, Actions actions)
    {
        if (controller.IsGrounded && actions.AttackRequested && controller.CanAttack) return controller.AttackState;

        return base.HandleTransitions(controller, actions);
    }
}

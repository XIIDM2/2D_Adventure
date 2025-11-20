using UnityEngine;

public class NonAttackState : State
{
    public override State HandleAction(UnitController controller, ActionDataBase action)
    {
        if (action.ActionType == ActionType.Attack) return new AttackState();

        return base.HandleAction(controller, action);
    }
}

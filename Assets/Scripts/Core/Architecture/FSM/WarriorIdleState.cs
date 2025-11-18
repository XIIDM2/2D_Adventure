using UnityEngine;

public class WarriorIdleState : State
{
    public override State HandleAction(UnitController controller, ActionDataBase actionDataBase)
    {
        return null;
    }
    public override State HandleTransition(UnitController controller) => null;
    public override void Enter(UnitController controller) { }
    public override void Update(UnitController controller) { }
    public override void LateUpdate(UnitController controller) { }
    public override void FixedUpdate(UnitController controller) { }
    public override void Exit(UnitController controller) { }
}

using UnityEngine;

public class UnitState : State<UnitController>
{
    public override State<UnitController> HandleTransitions(UnitController controller, Actions actions) => null;
    public override void Enter(UnitController controller) { }
    public override void Update(UnitController controller) { }
    public override void LateUpdate(UnitController controller) { }
    public override void FixedUpdate(UnitController controller) { }
    public override void Exit(UnitController controller) { }
}

using UnityEngine;

public abstract class State
{
    public virtual State HandleAction(UnitController controller, ActionDataBase actionDataBase) => null;
    public virtual State HandleTransition(UnitController controller) => null;
    public virtual void Enter(UnitController controller) { }
    public virtual void Update(UnitController controller) { }
    public virtual void LateUpdate(UnitController controller) { }
    public virtual void FixedUpdate(UnitController controller) { }
    public virtual void Exit(UnitController controller) { }
}

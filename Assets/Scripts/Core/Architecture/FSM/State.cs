using UnityEngine;

public abstract class State
{
    public virtual State HandleTransitions(UnitController controller, Actions actions) => null;
    public virtual void Enter(UnitController controller) { }
    public virtual void Update(UnitController controller) { }
    public virtual void LateUpdate(UnitController controller) { }
    public virtual void FixedUpdate(UnitController controller) { }
    public virtual void Exit(UnitController controller) { }
}

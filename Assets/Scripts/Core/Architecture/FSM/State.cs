using UnityEngine;

public abstract class State<T> where T : IControllable
{
    public virtual State<T> HandleTransitions(T controller, Actions actions) => null;
    public virtual void Enter(T controller) { }
    public virtual void Update(T controller) { }
    public virtual void LateUpdate(T controller) { }
    public virtual void FixedUpdate(T controller) { }
    public virtual void Exit(T controller) { }
}

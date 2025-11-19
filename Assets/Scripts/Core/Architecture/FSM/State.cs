using UnityEngine;

public abstract class State
{
    protected Vector2 _direction = Vector2.zero;

    protected bool _canMove = true;
    public virtual State HandleAction(UnitController controller, ActionDataBase action)
    {
        if (action.ActionType == ActionType.Move)
        {
            if (action is ActionData<Vector2> move)
            {
                _direction = move.Value;
            }
            else
            {
                Debug.LogError("Wrong value type");
            }
        }

        return null;
    }
    public virtual State HandleTransition(UnitController controller) => null;
    public virtual void Enter(UnitController controller) 
    {
        _direction = controller.Movement.LastDirection;
    }
    public virtual void Update(UnitController controller) { }
    public virtual void LateUpdate(UnitController controller) { }
    public virtual void FixedUpdate(UnitController controller) 
    {
        if (_canMove) controller.Movement.Move(_direction);
    }

    public virtual void Exit(UnitController controller) 
    {
        controller.Movement.SetLastDirection(_direction);    
    }
}

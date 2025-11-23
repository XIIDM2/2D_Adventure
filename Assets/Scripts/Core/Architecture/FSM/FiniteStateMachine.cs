using UnityEngine;

public class FiniteStateMachine
{
    private State _currentState;

    public void StateInit(State state, UnitController controller)
    {
        _currentState = state;
        _currentState.Enter(controller);
    }

    public void UpdateState(UnitController controller, Actions actions)
    {
        State newState = _currentState.HandleTransitions(controller, actions);

        if (newState != null)
        {
            ChangeState(newState, controller);
        }
        else
        {
            _currentState.Update(controller);
        }

        Debug.Log(_currentState);
    }

    public void LateUpdateState(UnitController controller)
    {
        _currentState.LateUpdate(controller);
    }

    public void FixedUpdateState(UnitController controller)
    {
        _currentState.FixedUpdate(controller);
    }

    private void ChangeState(State state, UnitController controller)
    {
        if (state != null && state != _currentState)
        {
            _currentState.Exit(controller);
            _currentState = state;
            _currentState.Enter(controller);
        }
    }
}

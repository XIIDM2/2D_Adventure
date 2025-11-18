using System;

public interface IControllable<T> : IControllableBase
{
    void HandleAction(T action);
}

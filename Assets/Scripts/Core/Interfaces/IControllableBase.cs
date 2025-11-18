using System;

public interface IControllableBase 
{
    event Action<ActionDataBase> OnActionTriggered;
}


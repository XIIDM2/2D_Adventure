
public class ActionData<T> : ActionDataBase
{
    public T Value {  get; private set; }

    public ActionData(ActionType actionType, T value) : base(actionType)
    {
        Value = value;
    }
}

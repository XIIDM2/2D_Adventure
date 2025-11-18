public class ActionDataBase
{
    public ActionType ActionType { get; private set; }

    public ActionDataBase(ActionType actionType)
    {
        ActionType = actionType;
    }
}
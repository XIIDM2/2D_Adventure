using UnityEngine;

public readonly struct Actions
{
    public readonly Vector2 MoveDirection;

    public readonly bool JumpRequested;

    public readonly bool AttackRequested;

    public Actions(Vector2 MoveDirection, bool JumpRequested, bool AttackRequested)
    {
        this.MoveDirection = MoveDirection;
        this.JumpRequested = JumpRequested;
        this.AttackRequested = AttackRequested;
    }
}

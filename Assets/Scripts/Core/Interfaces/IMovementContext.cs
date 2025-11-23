using UnityEngine;

public interface IMovementContext
{
    public bool IsGrounded { get; }

    void SetGroundedStatus(bool value);
}

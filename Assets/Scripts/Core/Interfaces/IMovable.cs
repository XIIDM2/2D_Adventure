using UnityEngine;

public interface IMovable
{
    Vector2 LastDirection {  get; }
    Vector2 Velocity {  get; }
    public void SetLastDirection(Vector2 vector) { }
    void Move(Vector2 vector);
}

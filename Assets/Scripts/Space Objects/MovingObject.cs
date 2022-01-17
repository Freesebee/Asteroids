using UnityEngine;

public abstract class MovingObject : SpaceObject
{

    public MovingObject(GameObject gameObject, Vector2 position = new Vector2()) : base(gameObject, position)
    {
    }

    public override void Move()
    {
        Moving();
    }

    protected abstract void Moving();

    public override void ConfigureRigidBody()
    {
        _rb.mass = 50f;
    }
}

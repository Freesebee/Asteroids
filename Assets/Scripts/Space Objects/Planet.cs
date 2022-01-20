using UnityEngine;

public class Planet : ConfigurableSpaceObject
{
    public Planet(GameObject gameObject, IMediator gameLogic, Vector2 position = default) : base(gameObject, gameLogic, position)
    {
    }

    protected override void ConfigureCollider()
    {
    }

    protected override void ConfigureGameObject()
    {
    }

    protected override void ConfigureRigidBody()
    {
        _rb.freezeRotation = true;
        _rb.mass = 1000f;
        _rb.drag = 100;
    }
}

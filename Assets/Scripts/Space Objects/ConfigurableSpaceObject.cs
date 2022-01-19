using UnityEngine;

public abstract class ConfigurableSpaceObject : SpaceObject
{
    protected ConfigurableSpaceObject(GameObject gameObject, Vector2 position = default) : base(gameObject, position)
    {
    }

    /// <summary>
    /// Template method used to configure SpaceObject properties
    /// </summary>
    public override void Configure()
    {
        _rb.gravityScale = 0;

        ConfigureRigidBody();
        ConfigureCollider();
        ConfigureGameObject();
    }

    protected abstract void ConfigureRigidBody();
    protected abstract void ConfigureCollider();
    protected abstract void ConfigureGameObject();
}

using System;
using UnityEngine;

public class Asteroid : ConfigurableSpaceObject
{
    public Asteroid(GameObject gameObject, Vector2 position = default) : base(gameObject, position)
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
        _rb.drag = 0;
        _rb.angularDrag = 0;
        _rb.mass = 80f;
    }
}

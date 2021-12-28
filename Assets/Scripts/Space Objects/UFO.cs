using System;
using UnityEngine;

public class UFO : SpaceObject
{
    public UFO(GameObject gameObject, Vector2 position = new Vector2()) : base(gameObject, position)
    {
    }

    protected override void ConfigureRigidBody()
    {
        _rb.mass = 10f;
    }

    protected override void Moving()
    {
        throw new NotImplementedException();
    }
}

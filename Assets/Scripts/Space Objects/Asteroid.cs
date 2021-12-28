using UnityEngine;

public class Asteroid : SpaceObject
{
    private Vector2 _initVelocity;

    public Asteroid(GameObject gameObject, Vector2 initVelocity, Vector2 position = new Vector2()) : base(gameObject, position)
    {
        _initVelocity = initVelocity;
    }

    protected override void ConfigureRigidBody()
    {
        _rb.mass = 50f;
    }

    protected override void Moving()
    {
        if (_initVelocity != Vector2.zero)
        {
            _rb.velocity = _initVelocity;
            _initVelocity = Vector2.zero;
        }
    }
}

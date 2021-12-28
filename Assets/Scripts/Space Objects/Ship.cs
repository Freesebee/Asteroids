using UnityEngine;

public class Ship : SpaceObject
{
    private Vector2 _direction;
    private const float _maxSpeed = 50f;

    public Ship(GameObject gameObject, Vector2 position = new Vector2()) : base(gameObject, position) { }

    public void Control(Vector2 normalizedDirection)
    {
        _direction = normalizedDirection;
    }

    protected override void Moving()
    {
        _rb.AddForce(_direction * _maxSpeed);
    }
    
    protected override void ConfigureRigidBody()
    {
        _rb.mass = 10f;
        _rb.drag = 0.8f;
        _rb.angularDrag = 1f;
    }
}

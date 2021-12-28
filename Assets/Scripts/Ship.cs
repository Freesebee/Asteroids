using UnityEngine;

public class Ship : SpaceObject
{
    private Vector2 _direction;
    private const float _maxSpeed = 50f;

    public Ship(GameObject gameObject) : base(gameObject) { }
    
    public void Control(Vector2 normalizedDirection)
    {
        _direction = normalizedDirection;
    }

    protected override void Moving()
    {
        Vector2 newPosition = _rb.position + _direction * Time.deltaTime * _maxSpeed;
        _rb.MovePosition(newPosition);
    }
}

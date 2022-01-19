using UnityEngine;

public class Ship : ConfigurableSpaceObject
{
    private Vector2 _direction;
    private const float _maxSpeed = 50f;

    public Ship(GameObject gameObject, Vector2 position = new Vector2()) : base(gameObject, position) { }

    public void Control(Vector2 normalizedDirection)
    {
        _direction = normalizedDirection;
    }

    public new void Update()
    {
        Vector2 newPosition = _rb.position + _direction * Time.deltaTime * _maxSpeed;
        _rb.MovePosition(newPosition);
    }

    #region Configuration
    protected override void ConfigureRigidBody()
    {
        _rb.mass = 10f;
        _rb.drag = 0.8f;
        _rb.angularDrag = 1f;
    }

    protected override void ConfigureCollider()
    {
    }

    protected override void ConfigureGameObject()
    {
    }
    #endregion
}

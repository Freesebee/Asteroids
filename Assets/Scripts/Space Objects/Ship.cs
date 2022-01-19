using UnityEngine;

public class Ship : ConfigurableSpaceObject
{
    private Vector2 _direction;
    [SerializeField] private float _speed = 50f;
    [SerializeField] private float _rotationSpeed = 10f;

    public Ship(GameObject gameObject, Vector2 position = new Vector2()) : base(gameObject, position) 
    {
    }

    public void Control(Vector2 normalizedDirection)
    {
        _direction = normalizedDirection;
    }

    public override void Update()
    {
        //float angle = _rb.rotation + Time.deltaTime * _rotationSpeed;
        //_rb.MoveRotation(angle);

        //Vector2 newPosition = _rb.position + _direction * Time.deltaTime * _speed;
        //_rb.MovePosition(newPosition);

        _rb.AddRelativeForce(new Vector2(0, _direction.y), ForceMode2D.Impulse);

        _rb.AddTorque(-_direction.x);

        _direction = Vector2.zero;
    }

    #region Configuration
    protected override void ConfigureRigidBody()
    {
        _rb.mass = 10f;
        _rb.drag = 0.8f;
        _rb.angularDrag = 0.2f;
    }

    protected override void ConfigureCollider()
    {
    }

    protected override void ConfigureGameObject()
    {
    }
    #endregion
}

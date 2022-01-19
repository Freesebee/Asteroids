using UnityEngine;

public class Ship : ConfigurableSpaceObject
{
    private Vector2 _direction;
    [SerializeField] private float _speed = 50f;
    [SerializeField] private float _rotationSpeed = 10f;
    private ObjectPool _bulletPool;

    public Ship(GameObject gameObject, Vector2 position = new Vector2()) : base(gameObject, position) 
    {
    }

    public void Control(Vector2 normalizedDirection)
    {
        _direction = normalizedDirection;
    }

    public void Fire()
    {
        var bullet = _bulletPool.GetPooledObject();
        var script = bullet.GetComponent<Bullet>();
        script.Fire(_rb.position, _rb.rotation);
    }

    public override void Update()
    {
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
        _bulletPool = GameObject.GetComponent<ObjectPool>();
    }
    #endregion
}

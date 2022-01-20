using UnityEngine;

public class Ship : ConfigurableSpaceObject
{
    private Vector2 _direction;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _rotationSpeed = 15f;
    private ObjectPool _bulletPool;

    public Ship(GameObject gameObject, IMediator gameLogic, Vector2 position = new Vector2()) : base(gameObject, gameLogic, position) 
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
        _rb.AddRelativeForce(new Vector2(0, _direction.y) * _speed, ForceMode2D.Impulse);

        _rb.AddTorque(-_direction.x * _rotationSpeed);

        _direction = Vector2.zero;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        _gameLogic.Notify(this, MediatorConsts.GotHit);
    }

    #region Configuration
    protected override void ConfigureRigidBody()
    {
        _rb.mass = 10f;
        _rb.drag = 2f;
        _rb.angularDrag = 3f;
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

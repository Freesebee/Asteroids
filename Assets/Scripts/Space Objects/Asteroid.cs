using UnityEngine;

public class Asteroid : ConfigurableSpaceObject
{
    public Asteroid(GameObject gameObject, IMediator gameLogic, Vector2 position = default) : base(gameObject, gameLogic, position)
    {
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            GameObject.Destroy(GameObject);
        }
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

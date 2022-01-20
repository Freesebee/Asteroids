using UnityEngine;

public class Asteroid : ConfigurableSpaceObject
{
    private int _durability;

    public Asteroid(GameObject gameObject, IMediator gameLogic, Vector2 position = default) : base(gameObject, gameLogic, position)
    {
        _durability = 2;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if(--_durability <= 0) _gameLogic.Notify(this, MediatorConsts.GotDestroyed);
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

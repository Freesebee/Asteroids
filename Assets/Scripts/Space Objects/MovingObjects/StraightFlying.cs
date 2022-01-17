using UnityEngine;

public class StraightFlying : MovingObject
{
    protected Vector2 _initVelocity;
    private bool _forceAdded;

    public StraightFlying(GameObject gameObject, Vector2 initVelocity, Vector2 position = default) : base(gameObject, position)
    {
        _initVelocity = initVelocity;
        _forceAdded = false;
    }

    protected override void Moving()
    {
        if (!_forceAdded)
        {
            _rb.AddForce(_initVelocity, ForceMode2D.Impulse);
        }
    }
}

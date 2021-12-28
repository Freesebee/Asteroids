using UnityEngine;

public class SpaceObjectDecorator : ISpaceObject
{
    protected SpaceObject _wrapped;

    public SpaceObject SetWrapped { set => _wrapped = value; }

    public SpaceObjectDecorator(SpaceObject spaceObject)
    {
        _wrapped = spaceObject;
    }

    public virtual void Awake() => _wrapped.Awake();
    public virtual void Start() => _wrapped.Start();
    public virtual void Update() => _wrapped.Update();
    public virtual void FixedUpdate() => _wrapped.FixedUpdate();
    public virtual void OnEnable() => _wrapped.OnEnable();
    public virtual void OnDisable() => _wrapped.OnDisable();
    public virtual void OnCollisionEnter2D(Collision2D collision) => _wrapped.OnCollisionEnter2D(collision);
    public virtual void OnCollisionExit2D(Collision2D collision) => _wrapped.OnCollisionExit2D(collision);
    public virtual void OnDestroy() => _wrapped.OnDestroy();
}

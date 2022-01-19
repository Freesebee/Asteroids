using UnityEngine;

public class SpaceObjectDecorator : SpaceObject
{
    protected SpaceObject _wrapped;

    public SpaceObject SetWrapped { set => _wrapped = value; }

    public new GameObject GameObject => _wrapped.GameObject;

    public SpaceObjectDecorator(SpaceObject spaceObject) : base(spaceObject.GameObject)
    {
        _wrapped = spaceObject;
    }

    public new virtual void Awake() => _wrapped.Awake();
    public new virtual void Start() => _wrapped.Start();
    public new virtual void Update() => _wrapped.Update();
    public new virtual void FixedUpdate() => _wrapped.FixedUpdate();
    public new virtual void OnEnable() => _wrapped.OnEnable();
    public new virtual void OnDisable() => _wrapped.OnDisable();
    public new virtual void OnCollisionEnter2D(Collision2D collision) => _wrapped.OnCollisionEnter2D(collision);
    public new virtual void OnCollisionExit2D(Collision2D collision) => _wrapped.OnCollisionExit2D(collision);
    public new virtual void OnDestroy() => _wrapped.OnDestroy();
    public override void Configure() => _wrapped.Configure();
}

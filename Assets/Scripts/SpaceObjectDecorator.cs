using UnityEngine;

public class SpaceObjectDecorator : SpaceObject
{
    protected SpaceObject _wrapped;

    public SpaceObject SetWrapped { set => _wrapped = value; }
    public SpaceObject GetWrapped => _wrapped;

    public new GameObject GameObject => _wrapped.GameObject;

    public SpaceObjectDecorator(SpaceObject spaceObject) : base()/* : base(spaceObject.GameObject)*/
    {
        _wrapped = spaceObject;
    }

    public override void Awake() => _wrapped.Awake();
    public override void Start() => _wrapped.Start();
    public override void Update() => _wrapped.Update();
    public override void FixedUpdate() => _wrapped.FixedUpdate();
    public override void OnEnable() => _wrapped.OnEnable();
    public override void OnDisable() => _wrapped.OnDisable();
    public override void OnCollisionEnter2D(Collision2D collision) => _wrapped.OnCollisionEnter2D(collision);
    public override void OnCollisionExit2D(Collision2D collision) => _wrapped.OnCollisionExit2D(collision);
    public override void OnDestroy() => _wrapped.OnDestroy();
    protected override void Configure() => (_wrapped as SpaceObjectDecorator).Configure();
}

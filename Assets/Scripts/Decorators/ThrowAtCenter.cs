using UnityEngine;

public class ThrowAtCenter : SpaceObjectDecorator
{
    private const float _spawnRadius = 16f;
    private float minForce = 100f, maxForce = 400f;

    public ThrowAtCenter(SpaceObject spaceObject) : base(spaceObject)
    {
    }

    public override void Start()
    {
        var x = Random.Range(-_spawnRadius, _spawnRadius);
        var y = _spawnRadius * Mathf.Sqrt(1 - (x / _spawnRadius) * (x / _spawnRadius));

        _wrapped.GameObject.transform.position = new Vector2(x, y);

        var dir = Vector2.zero - (Vector2)_wrapped.GameObject.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90 + Random.Range(-15, 15);
        _wrapped.GameObject.GetComponent<Rigidbody2D>().SetRotation(Quaternion.AngleAxis(angle, Vector3.forward));

        _wrapped.GameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
        _wrapped.GameObject.GetComponent<Rigidbody2D>().AddTorque(Random.Range(10, 50));

        base.Start();
    }
}

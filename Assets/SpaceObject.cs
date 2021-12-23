using System.Collections.Generic;

using UnityEngine;

public abstract class SpaceObject : MonoBehaviour
{
    [SerializeField] private float _mass = 2;
    [SerializeField] protected const float _gravitationalConst = 0.067f; //TODO: Set in mediator

    private Collider2D _collider;
    protected Rigidbody2D _rb;
    private static ISpaceObjectCollection _existingSpaceObject;
    private IMediator _mainLogic;

    #region GameObject Lifecycle
    public SpaceObject() { }

    protected void Awake()
    {
        _existingSpaceObject = new BasicSOCollection();
        _collider = gameObject.AddComponent<PolygonCollider2D>();
        _rb = gameObject.AddComponent<Rigidbody2D>();
        _rb.angularDrag = 0;
        _rb.drag = 0;
        _rb.gravityScale = 0;
        _rb.mass = _mass;
    }

    protected void OnEnable()
    {
        _existingSpaceObject.Add(this);
    }

    protected void FixedUpdate()
    {
        Move();

        ISpaceObjectIterator iterator = _existingSpaceObject.CreateIterator();
        while(iterator.HasMore)
        {
            SpaceObject obj = iterator.GetNext();
            if (obj != this) Attract(obj);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
    }
    #endregion

    #region Template Method
    private void Move()
    {
        moving();
    }

    protected abstract void moving();
    #endregion

    #region Gravity Force
    private void Attract(SpaceObject objectToAttract)
    {
        Rigidbody2D rbToAttract = objectToAttract._rb;

        Vector2 direction = _rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f) return; //Fixes bugging in case of duplication

        float forceMagnitude = _gravitationalConst * (_rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector2 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
    #endregion
}

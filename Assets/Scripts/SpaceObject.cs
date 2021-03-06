
using UnityEngine;

public abstract class SpaceObject : IUnityMonoBehaviour
{
    [SerializeField] protected const float _gravitationalConst = 0.067f; //TODO: Set in mediator

    protected GameObject _gameObject;
    protected Collider2D _collider;
    protected Rigidbody2D _rb;
    protected static ISpaceObjectCollection _existingSpaceObjects;
    protected IMediator _gameLogic;

    public GameObject GameObject => _gameObject;

    protected SpaceObject() { } //required for decorator

    public SpaceObject(GameObject gameObject, IMediator gameLogic, Vector2 position = new Vector2())
    {
        _gameObject = gameObject;
        _existingSpaceObjects = new BasicSOCollection();
        _gameObject.transform.position = position;
        _gameLogic = gameLogic;
    }

    #region GameObject Lifecycle

    public virtual void Awake()
    {
        _collider = _gameObject.AddComponent<PolygonCollider2D>();
        _rb = _gameObject.AddComponent<Rigidbody2D>();
        Configure();
    }

    public virtual void Start() 
    {
    }

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
        ISpaceObjectIterator iterator = _existingSpaceObjects.CreateIterator();
        while (iterator.HasMore)
        {
            SpaceObject obj = iterator.GetNext();
            if (obj != this) Attract(obj);
        }
    }

    public virtual void OnEnable()
    {
        _existingSpaceObjects.Add(this);
    }

    public virtual void OnDisable()
    {
        _existingSpaceObjects.Remove(this);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision) { }

    public virtual void OnCollisionExit2D(Collision2D collision) { }

    public virtual void OnDestroy() { }

    #endregion

    protected abstract void Configure(); //Template method

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

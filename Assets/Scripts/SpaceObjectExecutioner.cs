using UnityEngine;

public class SpaceObjectExecutioner : MonoBehaviour
{
    public IUnityMonoBehaviour SpaceObject { get; set; }

    private void Awake()
    {
        if (SpaceObject == null) throw new UnityException("SpaceObject is not set in executioner script");

        SpaceObject.Awake();
    }

    private void Start() => SpaceObject.Start();
    private void OnEnable() => SpaceObject.OnEnable();
    private void OnDisable() => SpaceObject.OnDisable();
    private void Update() => SpaceObject.Update();
    private void FixedUpdate() => SpaceObject.FixedUpdate();
    private void OnCollisionEnter2D(Collision2D collision) => SpaceObject.OnCollisionEnter2D(collision);
    private void OnCollisionExit2D(Collision2D collision) => SpaceObject.OnCollisionExit2D(collision);
    private void OnDestroy() => SpaceObject.OnDestroy();
}

using UnityEngine;

public class Asteroid : SpaceObject
{
    protected override void moving()
    {
        _rb.position += Time.fixedDeltaTime * new Vector2(.5f, 0f);
    }
}

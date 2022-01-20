using UnityEngine;

public class DestroyAtDistance : SpaceObjectDecorator
{
    private float _distanceLimit;

    public DestroyAtDistance(SpaceObject spaceObject, float distance) : base(spaceObject)
    {
        _distanceLimit = distance;
    }

    public override void Update()
    {
        if(GameObject && Vector2.Distance(GameObject.transform.position, Vector2.zero) >= _distanceLimit)
        {
            GameObject.Destroy(GameObject);
        }
        else
        {
            base.Update();
        }
    }
}

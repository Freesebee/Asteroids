using UnityEngine;

public class ScreenWrapping : SpaceObjectDecorator
{
    private bool isWrappingX = false;
    private bool isWrappingY = false;
    private Renderer[] renderers;

    public ScreenWrapping(SpaceObject spaceObject) : base(spaceObject) { }

    public override void Start()
    {
        renderers = _wrapped.GameObject.GetComponentsInChildren<Renderer>();
        _wrapped.Start();
    }

    public override void Update()
    {
        ScreenWrap();
        _wrapped.Update();
    }

    private bool CheckRenderers()
    {
        foreach (var renderer in renderers)
        {
            if (renderer.isVisible)
            {
                return true;
            }
        }

        return false;
    }

    private void ScreenWrap()
    {
        var isVisible = CheckRenderers();

        if (isVisible)
        {
            isWrappingX = false;
            isWrappingY = false;
            return;
        }

        if (isWrappingX && isWrappingY)
        {
            return;
        }

        var viewportPosition = Camera.main.WorldToViewportPoint(
            _wrapped.GameObject.transform.position);

        var newPosition = _wrapped.GameObject.transform.position;

        if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            newPosition.x = -newPosition.x;
            isWrappingX = true;
        }

        if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            newPosition.y = -newPosition.y;
            isWrappingY = true;
        }

        _wrapped.GameObject.transform.position = newPosition;
    }
}

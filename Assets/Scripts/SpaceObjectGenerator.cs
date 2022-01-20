using System.Collections;
using UnityEngine;

public class SpaceObjectGenerator : MonoBehaviour
{
    public ISpaceObjectFactory factory;
    private bool isRunning;
    private const float _eventInterval = 1f;

    public void Init()
    {
        isRunning = true;
        StartCoroutine(RandomEvent());
    }

    public void Disable()
    {
        isRunning = false;
    }

    private IEnumerator RandomEvent()
    {
        float timer = _eventInterval;
        while(isRunning)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                var asteroid = factory.CreateAsteroid();

                timer = _eventInterval;
            }
            yield return null;
        }
        yield return null;
    }
}

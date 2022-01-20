using System.Collections;
using UnityEngine;

public class SpaceObjectGenerator : MonoBehaviour
{
    public ISpaceObjectFactory factory;
    private bool isRunning;
    private const float _spawnRadius = 16f;
    private const float _eventInterval = 1f;
    [SerializeField] private float minForce = 300f, maxForce = 700f;

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

                var x = Random.Range(-_spawnRadius, _spawnRadius);
                var y = _spawnRadius * Mathf.Sqrt(1 - (x / _spawnRadius) * (x / _spawnRadius));

                asteroid.GameObject.transform.position = new Vector2(x, y);

                var dir = Vector2.zero - (Vector2)asteroid.GameObject.transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90 + Random.Range(-15,15);
                asteroid.GameObject.GetComponent<Rigidbody2D>().SetRotation(Quaternion.AngleAxis(angle, Vector3.forward));

                asteroid.GameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
                asteroid.GameObject.GetComponent<Rigidbody2D>().AddTorque(Random.Range(10, 50));

                timer = _eventInterval;
            }
            yield return null;
        }
        yield return null;
    }
}

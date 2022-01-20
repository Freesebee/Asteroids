using UnityEngine;

public class BasicSOFactory : MonoBehaviour, ISpaceObjectFactory
{
    public GameObject asteroidPrefab;

    public SpaceObject CreateAlien()
    {
        throw new System.NotImplementedException();
    }

    public SpaceObject CreateAsteroid()
    {
        var asteroidGameObject = Instantiate(asteroidPrefab);

        asteroidGameObject.SetActive(false); //makes assigning values before Awake() possible
        var executor = asteroidGameObject.AddComponent<SpaceObjectExecutioner>();
        executor.SpaceObject = new Asteroid(asteroidGameObject);
        asteroidGameObject.SetActive(true);

        return (SpaceObject)executor.SpaceObject;
    }
}

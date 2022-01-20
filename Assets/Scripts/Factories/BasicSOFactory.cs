using UnityEngine;

public class BasicSOFactory : MonoBehaviour, ISpaceObjectFactory
{
    public GameObject asteroidPrefab;
    public GameObject planetPrefab;

    private IMediator _gameLogic;

    public BasicSOFactory(IMediator gameLogic)
    {
        _gameLogic = gameLogic;
    }

    public IMediator gameLogic { set => _gameLogic = value; }

    public SpaceObject CreatePlanet()
    {
        var planetGameObject = Instantiate(planetPrefab);

        planetGameObject.SetActive(false); //makes assigning values before Awake() possible

        var executor = planetGameObject.AddComponent<SpaceObjectExecutioner>();
        executor.SpaceObject = new Planet(planetGameObject, _gameLogic);
        
        planetGameObject.SetActive(true);

        return (SpaceObject)executor.SpaceObject;
    }

    public SpaceObject CreateAsteroid()
    {
        var asteroidGameObject = Instantiate(asteroidPrefab);

        asteroidGameObject.SetActive(false); //makes assigning values before Awake() possible
        
        var executor = asteroidGameObject.AddComponent<SpaceObjectExecutioner>();
        executor.SpaceObject = new DestroyAtDistance(new ThrowAtCenter(new Asteroid(asteroidGameObject, _gameLogic)), 20);
        
        asteroidGameObject.SetActive(true);

        return (SpaceObject)executor.SpaceObject;
    }
}

public interface ISpaceObjectFactory
{
    IMediator gameLogic { set; }
    SpaceObject CreateAsteroid();
    SpaceObject CreatePlanet();
}

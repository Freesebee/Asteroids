using System.Collections.Generic;
using UnityEngine;

public class BaseGalaxyBuilder : IMapBuilder
{
    private List<SpaceObject> _map;
    private ISpaceObjectFactory _spaceObjectFactory;

    public BaseGalaxyBuilder(ISpaceObjectFactory spaceObjectFactory)
    {
        _spaceObjectFactory = spaceObjectFactory;
        _map = new List<SpaceObject>();
    }

    public void AddPlanet(Vector2 position)
    {
        var planet = _spaceObjectFactory.CreatePlanet();
        planet.GameObject.transform.position = position;
        _map.Add(planet);
    }

    public List<SpaceObject> GetMap() => _map;

    public void ResetMap()
    {
        _map = new List<SpaceObject>();
    }
}

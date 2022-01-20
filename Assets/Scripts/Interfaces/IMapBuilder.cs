using System.Collections.Generic;
using UnityEngine;

public interface IMapBuilder
{
    void AddPlanet(Vector2 position);
    void ResetMap();
    List<SpaceObject> GetMap();
}

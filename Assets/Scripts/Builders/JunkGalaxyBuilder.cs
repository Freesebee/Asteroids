using System.Collections.Generic;
using UnityEngine;

    public class JunkGalaxyBuilder : IMapBuilder
    {
        private List<SpaceObject> _map;
        private ISpaceObjectFactory _spaceObjectFactory;

        public JunkGalaxyBuilder(ISpaceObjectFactory spaceObjectFactory)
        {
            _spaceObjectFactory = spaceObjectFactory;
            _map = new List<SpaceObject>();
        }

        public void AddPlanet(Vector2 position)
        {
            var asteroid = _spaceObjectFactory.CreateAsteroid();
            asteroid.GameObject.transform.position = position;
            _map.Add(asteroid);
        }

        public List<SpaceObject> GetMap() => _map;

        public void ResetMap()
        {
            _map = new List<SpaceObject>();
        }
}

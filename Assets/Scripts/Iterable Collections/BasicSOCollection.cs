using System;
using System.Collections.Generic;

public class BasicSOCollection : ISpaceObjectCollection
{
    private IList<SpaceObject> _spaceObjects;

    public BasicSOCollection()
    {
        _spaceObjects = new List<SpaceObject>();
    }

    public IList<SpaceObject> SpaceObjects => _spaceObjects;

    public ISpaceObjectIterator CreateIterator()
    {
        return new BasicSOIterator(this);
    }

    public void Add(SpaceObject spaceObject)
    {
        _spaceObjects.Add(spaceObject);
    }

    public void Remove(SpaceObject spaceObject)
    {
        _spaceObjects.Remove(spaceObject);
    }
}

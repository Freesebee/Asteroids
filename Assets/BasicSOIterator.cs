using System;
using System.Collections.Generic;

public class BasicSOIterator : ISpaceObjectIterator
{
    private ISpaceObjectCollection _collection;
    private uint _currentPosition;
    private IList<SpaceObject> _cache;

    public BasicSOIterator(ISpaceObjectCollection collection)
    {
        _collection = collection;
        _currentPosition = 0;
    }

    public bool HasMore => _currentPosition < _cache.Count;

    public SpaceObject GetNext() => HasMore ? _cache[(int)++_currentPosition] : null;
}

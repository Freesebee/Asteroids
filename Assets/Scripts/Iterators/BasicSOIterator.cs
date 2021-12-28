using System;
using System.Collections.Generic;

public class BasicSOIterator : ISpaceObjectIterator
{
    private BasicSOCollection _collection;
    private uint _currentPosition;
    private IList<SpaceObject> _cache;

    public BasicSOIterator(BasicSOCollection collection)
    {
        _collection = collection;
        _currentPosition = 0;
        _cache = _collection.SpaceObjects;
    }

    public bool HasMore => _currentPosition < _cache.Count;

    public SpaceObject GetNext() => HasMore ? _cache[(int)_currentPosition++] : null;
}

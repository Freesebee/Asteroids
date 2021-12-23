using System;

public class BasicSOCollection : ISpaceObjectCollection
{
    public ISpaceObjectIterator CreateIterator()
    {
        return new BasicSOIterator(this);
    }

    public void Add(SpaceObject @object)
    {
        throw new NotImplementedException();
    }
}

public interface ISpaceObjectCollection
{
    ISpaceObjectIterator CreateIterator();
    void Add(SpaceObject spaceObject);
    void Remove(SpaceObject spaceObject);
}
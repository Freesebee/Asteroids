public interface ISpaceObjectIterator
{
    SpaceObject GetNext();
    bool HasMore { get; }
}

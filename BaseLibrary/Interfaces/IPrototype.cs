namespace BaseLibrary.Interfaces
{
    public interface IPrototype<T>
    {
        T CreateDeepCopy();
    }
}
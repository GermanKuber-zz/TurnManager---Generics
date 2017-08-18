namespace TurnManager
{
    //TODO: 01 -  Impllemento interface
    public interface ITurnManager<T>
    {
        bool Add(T number);
        T Get();
        int Capacity { get; }
        bool IsEmpty();
    }

}
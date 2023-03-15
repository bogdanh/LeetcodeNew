namespace DesignPattern.Iterator;

internal interface AbstractIterator {
    public abstract Employee First();
    public abstract Employee Next();
    public bool IsCompleted { get; }
}
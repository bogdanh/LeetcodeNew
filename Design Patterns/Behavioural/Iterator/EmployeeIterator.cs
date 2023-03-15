#nullable disable warnings

namespace DesignPattern.Iterator;

public class EmployeeIterator : AbstractIterator
{
    private ConcreteCollection Collection;
    private int current = 0;
    private int step = 1;
    public bool IsCompleted => current >= Collection.Count;
    
    public EmployeeIterator(ConcreteCollection collection) {
        Collection = collection;
    }

    public Employee First()
    {
        current = 0;
        return Collection.GetEmployee(current);
    }

    public Employee Next()
    {
        current += step;
        
        if (IsCompleted) {
            return null;
        }

        return Collection.GetEmployee(current);
    }
}
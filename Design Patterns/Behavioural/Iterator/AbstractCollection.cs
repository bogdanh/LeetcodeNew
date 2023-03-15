#nullable disable warnings

namespace DesignPattern.Iterator;

public interface AbstractCollection {
    public EmployeeIterator CreateIterator();
}
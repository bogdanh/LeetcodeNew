#nullable disable warnings

namespace DesignPattern.Iterator;

public class ConcreteCollection : AbstractCollection {
    private IList<Employee> listEmployees = new List<Employee>();
    
    public EmployeeIterator CreateIterator() {
        return new EmployeeIterator(this);
    }

    public int Count => listEmployees.Count;

    public void AddEmployee(Employee employee) => listEmployees.Add(employee);
    
    public Employee GetEmployee(int indexPosition) => listEmployees[indexPosition];
}
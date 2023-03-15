namespace DesignPattern.Iterator;

public class Iterator {
    
    public static void Run() {
        var collection = new ConcreteCollection();
        collection.AddEmployee(new Employee(100, "John"));
        collection.AddEmployee(new Employee(200, "Doe"));
        collection.AddEmployee(new Employee(300, "Bill"));
        collection.AddEmployee(new Employee(400, "Richard"));

        var iterator = collection.CreateIterator();

        for (var employee = iterator.First(); !iterator.IsCompleted; employee = iterator.Next()) {
            Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}");
        }
    }
}

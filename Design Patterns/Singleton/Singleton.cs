#nullable disable warnings
namespace DesignPatterns.Singleton;
public class Singleton {

    sealed class SingletonInstance {
        private static readonly SingletonInstance instance = new SingletonInstance();
        public bool IsLoggedIn { get; set; }

        private SingletonInstance() {
            IsLoggedIn = false;
        }
        
        public static SingletonInstance Instance {
            get {
                return instance;
            }
        }
    }
    
    public static void Run() {
        var singleton1 = SingletonInstance.Instance;
        Console.WriteLine($"singleton1.IsLoggedIn = {singleton1.IsLoggedIn}");
        
        var singleton2 = SingletonInstance.Instance;
        singleton2.IsLoggedIn = true;
        Console.WriteLine($"singleton1.IsLoggedIn = {singleton1.IsLoggedIn}");
        Console.WriteLine($"singleton2.IsLoggedIn = {singleton2.IsLoggedIn}");
    }
}

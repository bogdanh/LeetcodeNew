#nullable disable warnings

namespace DesignPatterns.Builder;

public class Builder {
    internal class Burger {
        string Bun { get; set; }
        string Patty { get; set; }
        string Cheese { get; set; }
        
        public void SetBuns(string bun) {
            Bun = bun;
        }
        
        public void SetPatty(string patty) {
            Patty = patty;
        }
        
        public void SetCheese(string cheese) {
            Cheese = cheese;
        }
        
        public void Print() {
            Console.WriteLine($"[{Bun}, {Patty}, {Cheese}]");
        }
    }
    
    internal class BurgerBuilder {
        Burger Burger { get; set; }
        
        public BurgerBuilder() {
            Burger = new Burger();
        }
        
        public BurgerBuilder AddBuns(string bunStyle) {
            Burger.SetBuns(bunStyle);
            return this;
        }
        
        public BurgerBuilder AddPatty(string pattyStyle) {
            Burger.SetPatty(pattyStyle);
            return this;
        }
        
        public BurgerBuilder AddCheese(string cheeseStyle) {
            Burger.SetCheese(cheeseStyle);
            return this;
        }
        
        public Burger Build() {
            return Burger;
        }
    }
    
    public static void Run() {
        var burger = new BurgerBuilder()
            .AddBuns("sesame")
            .AddPatty("beef-patty")
            .AddCheese("cedar")
            .Build();
        
        burger.Print();
    }
}

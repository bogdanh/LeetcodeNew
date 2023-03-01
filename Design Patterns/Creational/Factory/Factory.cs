#nullable disable warnings

using Library;

namespace DesignPatterns.Factory;

public class Factory {
    internal class Burger {
        string[] Ingredients { get; set; }
        
        public Burger(string[] ingredients) {
            Ingredients = ingredients;
        }
        
        public void Print() {
            AssortedMethods.PrintStringArray(Ingredients);
        }
    }
    
    internal class BurgerFactory {
        
        public Burger CreateCheeseBurger() {
            var ingredients = new string[] { "bun", "cheese", "beef-patty" };
            return new Burger(ingredients);
        }
        
        public Burger CreateDeluxeCheeseBurger() {
            var ingredients = new string[] { "bun", "tomatoes", "lettuce", "cheese", "beef-patty" };
            return new Burger(ingredients);
        }

        public Burger CreateVeganBurger() {
            var ingredients = new string[] { "bun", "special-sauce", "veggie-patty" };
            return new Burger(ingredients);
        }
    }
    
    public static void Run() {
        var burgerFactory = new BurgerFactory();
        burgerFactory.CreateCheeseBurger().Print();
        burgerFactory.CreateDeluxeCheeseBurger().Print();
        burgerFactory.CreateVeganBurger().Print();
    }
}

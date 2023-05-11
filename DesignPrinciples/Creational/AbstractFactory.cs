using System;

namespace DesigngPrinciple.Creational
{
    //The Abstract Factory design pattern provides an interface for creating families of 
    //related or dependent objects without specifying their concrete classes

    //AbstractFactory - declares an interface for operations that create abstract products
    public abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    //AbstractProduct - declares an interface for a type of product object
    public abstract class Herbivore { }

    public abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    //ConcreteFactory - implements the operations to create concrete product objects
    public class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    public class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    //Product - defines a product object to be created by the corresponding concrete factory
    //implements the AbstractProduct interface
    public class Wildebeest : Herbivore { }

    public class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }

    public class Bison : Herbivore { }

    public class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }

    //Client - uses interfaces declared by AbstractFactory and AbstractProduct classes
    public class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }
        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}
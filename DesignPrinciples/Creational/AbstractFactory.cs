using System;

namespace DesigngPrinciple.Creational
{
    //The Abstract Factory design pattern provides an interface for creating families of 
    //related or dependent objects without specifying their concrete classes

    //AbstractFactory - declares an interface for operations that create abstract products
    public abstract class CarFactory
    {
        public abstract Sedan BuildSedan();

        public abstract Coupe BuildCoupe();
    }

    //AbstractProduct - declares an interface for a type of product object
    public abstract class Sedan { }

    public abstract class Coupe
    {
        public abstract void DragRace(Sedan s);
    }

    //ConcreteFactory - implements the operations to create concrete product objects
    public class BMW : CarFactory
    {
        public override Sedan BuildSedan()
        {
            return new ThreeSeries();
        }

        public override Coupe BuildCoupe()
        {
            return new M2();
        }
    }

    public class Ford : CarFactory
    {
        public override Sedan BuildSedan()
        {
            return new Mondeo();
        }
        public override Coupe BuildCoupe()
        {
            return new Mustang();
        }
    }

    //Product - defines a product object to be created by the corresponding concrete factory
    //implements the AbstractProduct interface
    public class ThreeSeries : Sedan { }

    public class M2 : Coupe
    {
        public override void DragRace(Sedan Sedan)
        {
            Console.WriteLine(this.GetType().Name + " goes faster than " + Sedan.GetType().Name);
        }
    }

    public class Mondeo : Sedan { }

    public class Mustang : Coupe
    {
        public override void DragRace(Sedan Sedan)
        {
            Console.WriteLine(this.GetType().Name + " goes faster than " + Sedan.GetType().Name);
        }
    }

    //Client - uses interfaces declared by AbstractFactory and AbstractProduct classes
    public class NFS
    {
        private Sedan _sedan;
        private Coupe _coupe;

        public NFS(CarFactory factory)
        {
            _coupe = factory.BuildCoupe();
            _sedan = factory.BuildSedan();
        }

        public void RunFoodChain() { _coupe.DragRace(_sedan); }
    }
}
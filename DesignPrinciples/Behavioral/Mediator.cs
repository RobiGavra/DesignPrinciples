using System;

namespace DesignPrinciples.Behavioral
{
    //Mediator is a behavioral design pattern that reduces coupling between components of a program by making them communicate indirectly, through a special mediator object.

    //Mediator
    public abstract class TrafficLight
    {
        public abstract void TurnOnGreen();
    }

    //ConcreteMediator
    public class ConcreteTrafficLight : TrafficLight
    {
        Mercedes merc;
        AlfaRomeo alfa;

        public Mercedes Mercedes { set { merc = value; } }

        public AlfaRomeo AlfaRomeo { set { alfa = value; } }

        public override void TurnOnGreen()
        {
            if (alfa.Power > merc.Power)
                Console.WriteLine("AlfaRomeo starts with a burnout");
            else
                Console.WriteLine("Mercedes can't start with a burnout");
        }
    }

    //Colleague classes
    public abstract class Car
    {
        protected TrafficLight light;

        public Car(TrafficLight mediator) { this.light = mediator; }
    }

    public class Mercedes : Car
    {
        public int Power { get { return 350; } }

        public Mercedes(TrafficLight mediator) : base(mediator) { }

        public void Start()
        {
            this.light.TurnOnGreen();
        }
    }

    public class AlfaRomeo : Car
    {
        public int Power { get { return 500; } }

        public AlfaRomeo(TrafficLight mediator) : base(mediator) { }

        public void Start()
        {
            this.light.TurnOnGreen();
        }
    }
}

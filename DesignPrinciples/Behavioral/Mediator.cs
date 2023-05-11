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
        private Mercedes _merc;
        private AlfaRomeo _alfa;

        public Mercedes Mercedes { set { _merc = value; } }
        public AlfaRomeo AlfaRomeo { set { _alfa = value; } }

        public override void TurnOnGreen()
        {
            if (_alfa.Power > _merc.Power)
                Console.WriteLine("AlfaRomeo starts with a burnout");
            else
                Console.WriteLine("Mercedes can't start with a burnout");
        }
    }

    //Colleague classes
    public abstract class Car
    {
        protected TrafficLight Light;

        public Car(TrafficLight Mediator) { this.Light = Mediator; }
    }

    public class Mercedes : Car
    {
        public int Power { get { return 350; } }

        public Mercedes(TrafficLight mediator) : base(mediator) { }

        public void Start() { this.Light.TurnOnGreen(); }
    }

    public class AlfaRomeo : Car
    {
        public int Power { get { return 500; } }

        public AlfaRomeo(TrafficLight mediator) : base(mediator) { }

        public void Start() { this.Light.TurnOnGreen(); }
    }
}

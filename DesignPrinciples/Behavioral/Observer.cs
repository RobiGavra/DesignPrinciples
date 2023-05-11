using System;
using System.Collections.Generic;

namespace DesignPrinciples.Behavioral
{
    //Observer is a behavioral design pattern that allows some objects to notify other objects about changes in their state.
    //defines a one-to-many dependency between objects

    //Subject
    public abstract class Casino
    {
        private List<IInvestor> _investors = new List<IInvestor>();

        public Casino() { }

        public void Attach(IInvestor Investor) { _investors.Add(Investor); }

        public void Detach(IInvestor Investor) { _investors.Remove(Investor); }

        //this should be triggered when a change of the object state is made
        public void Notify()
        {
            foreach (IInvestor Investor in _investors)
                Investor.Update(this);
        }
    }

    //ConcreteSubject
    public class RedSeven : Casino
    {
        public RedSeven() : base() { }
    }

    //Observer  
    public interface IInvestor
    {
        void Update(Casino Casino);
    }

    //ConcreteObserver  
    public class Investor : IInvestor
    {
        private string Name;

        public Investor(string Name) { this.Name = Name; }

        public void Update(Casino Casino)
        {
            Console.WriteLine("{0} come to invest at {1} and double your money", Name, Casino.GetType().Name);
        }
    }
}

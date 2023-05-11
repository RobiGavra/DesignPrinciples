using System;

namespace DesignPrinciples.Behavioral
{
    //Chain of Responsibility is behavioral design pattern that allows passing request along the chain of potential handlers until one of them handles request.
    //avoids coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. 

    //Handler
    public abstract class Approver
    {
        protected Approver successor;

        public void SetSuccessor(Approver successor) { this.successor = successor; }

        public abstract void ProcessRequest(SalaryIncreaseRequest purchase);
    }

    //ConcreteHandlers
    public class TeamLead : Approver
    {
        public override void ProcessRequest(SalaryIncreaseRequest purchase)
        {
            if (purchase.Amount > 100.0 && successor != null)
                successor.ProcessRequest(purchase);
            else
                Console.WriteLine("{0} approved request and your salary will be increased with {1}$", this.GetType().Name, purchase.Amount);
        }
    }

    public class Manager : Approver
    {
        public override void ProcessRequest(SalaryIncreaseRequest purchase)
        {
            if (purchase.Amount > 250.0 && successor != null)
                successor.ProcessRequest(purchase);
            else
                Console.WriteLine("{0} approved request and your salary will be increased with {1}$", this.GetType().Name, purchase.Amount);
        }
    }

    public class Boss : Approver
    {
        public override void ProcessRequest(SalaryIncreaseRequest purchase)
        {
            Console.WriteLine("{0} will not increase your salary with {1}$ because he wants a new car, but we will have pizza on Friday", this.GetType().Name, purchase.Amount);
        }
    }

    //Client
    public class SalaryIncreaseRequest
    {
        private double amount;

        public double Amount { get { return amount; } set { amount = value; } }

        public SalaryIncreaseRequest(double amount) { this.amount = amount; }
    }
}
using DesigngPrinciple.Creational;
using DesignPrinciples.Structural;
using DesignPrinciples.Behavioral;
using System;

namespace DesigngPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            Observer();

            Console.ReadKey();
        }

        //Creational patterns
        //These patterns provide various object creation mechanisms, which increase flexibility and reuse of existing code.
        static void Singleton()
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            // Same instance?
            if (b1 == b2 && b2 == b3 && b3 == b4)
                Console.WriteLine("Same instance\n");

            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 5; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }
        }

        static void AbstractFactory()
        {
            CarFactory BMW = new BMW();
            NFS NfS = new NFS(BMW);
            NfS.RunFoodChain();

            CarFactory Ford = new Ford();
            NfS = new NFS(Ford);
            NfS.RunFoodChain();
        }

        //Structural patterns
        //These patterns explain how to assemble objects and classes into larger structures while keeping these structures flexible and efficient.
        static void Proxy()
        {
            MathProxy Proxy = new MathProxy();

            Console.WriteLine("4 + 2 = " + Proxy.Add(4, 2));
            Console.WriteLine("4 - 2 = " + Proxy.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + Proxy.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + Proxy.Div(4, 2));
        }

        //Behavioral patterns
        //These patterns are concerned with algorithms and the assignment of responsibilities between objects.
        static void Mediator()
        {
            ConcreteTrafficLight Light = new ConcreteTrafficLight();

            Mercedes Merc = new Mercedes(Light);
            AlfaRomeo Alfa = new AlfaRomeo(Light);

            Light.Mercedes = Merc;
            Light.AlfaRomeo = Alfa;

            Merc.Start();
            Alfa.Start();
        }

        static void ChainOfResponsibility()
        {
            Approver Tilica = new TeamLead();
            Approver Samantar = new Manager();
            Approver ElPatron = new Boss();

            Tilica.SetSuccessor(Samantar);
            Samantar.SetSuccessor(ElPatron);

            SalaryIncreaseRequest Request = new SalaryIncreaseRequest(500.00);
            Tilica.ProcessRequest(Request);
        }

        static void Observer()
        {
            // Create casino and attach investors
            Casino RedSeven = new RedSeven();

            RedSeven.Attach(new Investor("Petrica"));
            RedSeven.Attach(new Investor("Traian"));

            RedSeven.Notify();
        }
    }
}
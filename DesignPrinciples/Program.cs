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
            AbstractFactory();

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
            {
                Console.WriteLine("Same instance\n");
            }

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
            MathProxy proxy = new MathProxy();

            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
            Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));
        }

        //Behavioral patterns
        //These patterns are concerned with algorithms and the assignment of responsibilities between objects.
        static void Mediator()
        {
            ConcreteTrafficLight light = new ConcreteTrafficLight();

            Mercedes merc = new Mercedes(light);
            AlfaRomeo alfa = new AlfaRomeo(light);

            light.Mercedes = merc;
            light.AlfaRomeo = alfa;

            merc.Start();
            alfa.Start();
        }

        static void ChainOfResponsibility()
        {
            Approver tilica = new TeamLead();
            Approver samantar = new Manager();
            Approver elPatron = new Boss();

            tilica.SetSuccessor(samantar);
            samantar.SetSuccessor(elPatron);

            SalaryIncreaseRequest p = new SalaryIncreaseRequest(500.00);
            tilica.ProcessRequest(p);
        }
    }
}
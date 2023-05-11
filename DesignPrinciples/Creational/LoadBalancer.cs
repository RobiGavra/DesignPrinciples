using System;
using System.Collections.Generic;

namespace DesigngPrinciple
{
    //The Singleton design pattern ensures a class has only one instance and provide a global point of access to it.
    public class LoadBalancer
    {
        private static LoadBalancer instance;

        // We now have a lock object that will be used to synchronize threads
        // during first access to the Singleton.
        private static object locker = new object();

        List<string> servers = new List<string>();
        Random random = new Random();

        private LoadBalancer()
        {
            servers.Add("ServerI");
            servers.Add("ServerII");
            servers.Add("ServerIII");
            servers.Add("ServerIV");
            servers.Add("ServerV");
        }
        public static LoadBalancer GetLoadBalancer()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (instance == null)
            {
                // Now, imagine that the program has just been launched. Since
                // there's no Singleton instance yet, multiple threads can
                // simultaneously pass the previous conditional and reach this
                // point almost at the same time. The first of them will acquire
                // lock and will proceed further, while the rest will wait here.
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new LoadBalancer();
                        Console.WriteLine("singleton instantiated");
                    }
                }
            }
            return instance;
        }

        //random load balancer
        public string Server
        {
            get
            {
                int r = random.Next(servers.Count);
                return servers[r].ToString();
            }
        }
    }
}
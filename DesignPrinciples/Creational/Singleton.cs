using System;
using System.Collections.Generic;

namespace DesigngPrinciple
{
    //The Singleton design pattern ensures a class has only one instance and provide a global point of access to it.
    public class LoadBalancer
    {
        private static LoadBalancer _instance;

        // We now have a lock object that will be used to synchronize threads
        // during first access to the Singleton.
        private static object _locker = new object();

        private List<string> _servers = new List<string>();
        private Random _random = new Random();

        private LoadBalancer()
        {
            _servers.Add("ServerI");
            _servers.Add("ServerII");
            _servers.Add("ServerIII");
            _servers.Add("ServerIV");
            _servers.Add("ServerV");
        }
        public static LoadBalancer GetLoadBalancer()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_instance == null)
            {
                // Now, imagine that the program has just been launched. Since
                // there's no Singleton instance yet, multiple threads can
                // simultaneously pass the previous conditional and reach this
                // point almost at the same time. The first of them will acquire
                // lock and will proceed further, while the rest will wait here.
                lock (_locker)
                {
                    if (_instance == null)
                    {
                        _instance = new LoadBalancer();
                        Console.WriteLine("singleton instantiated");
                    }
                }
            }
            return _instance;
        }

        //random load balancer
        public string Server
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r].ToString();
            }
        }
    }
}
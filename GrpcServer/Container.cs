using System;
using System.Threading;

namespace GrpcServer
{
    public class Container
    {
        readonly object accessLock = new object();

        double _waterLevel = 0.0;
        double _upperLevel = 0.0;
        double _lowerLevel = 0.0;

        public double waterLevel { get { return _waterLevel; } set { _waterLevel = value; } }
        public double upperLevel { get { return _upperLevel; } set { _upperLevel = value; } }
        public double lowerLevel { get { return _lowerLevel; } set { _lowerLevel = value; } }

        public Container()
        {
            waterLevel = new Random().NextDouble() * 100.0;

            Console.WriteLine($"Set current water level to: {waterLevel}");

            run();
        }

        void run()
        {
            new Thread(() =>
            {
                while (true)
                {
                    lock(accessLock)
                    {
                        lowerLevel = new Random().NextDouble() * 10.0;
                        upperLevel = lowerLevel + new Random().NextDouble() * 30.0;
                    }
                    
                    Console.WriteLine($"Set water level range to: {lowerLevel} - {upperLevel}");

                    Thread.Sleep(8000);
                }
            })
            .Start();
        }
    }
}

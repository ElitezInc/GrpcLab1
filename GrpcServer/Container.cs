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
            waterLevel = Math.Round(new Random().NextDouble() * 100.0, 1);

            Console.WriteLine($"Set current water level to: {waterLevel}L");

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
                        lowerLevel = Math.Round(new Random().NextDouble() * 100.0, 1);
                        upperLevel = Math.Round(lowerLevel + new Random().NextDouble() * 30.0, 1);
                    }
                    
                    Console.WriteLine($"Set water level range to: {lowerLevel}L - {upperLevel}L");

                    Thread.Sleep(8000);
                }
            })
            .Start();
        }
    }
}

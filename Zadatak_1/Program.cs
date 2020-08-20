using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Program
    {
        public static object TheLock = new object();
        public static Stopwatch s = new Stopwatch();
        public static Random r = new Random();
        public static CountdownEvent c = new CountdownEvent(7);
        public static bool semaphore = false;
        public static ArrayList finish = new ArrayList();

        static void Main(string[] args)
        {
            s.Start();

            List<Car> Cars = new List<Car>();

            Car car1 = new Car("Red", "NS", 111);
            Car car2 = new Car("Red", "BG", 222);

            Cars.Add(car1);
            Cars.Add(car2);

            Queue<Truck> Trucks = new Queue<Truck>();

            Truck truck1 = new Truck("Red", "PZ", 333);
            Truck truck2 = new Truck("Blue", "SU", 444);

            Trucks.Enqueue(truck1);
            Trucks.Enqueue(truck2);

            Stack<Tractor> Tractors = new Stack<Tractor>();

            Tractor tractor1 = new Tractor("White", "KR", 555);
            Tractor tractor2 = new Tractor("Red", "ZV", 666);

            Tractors.Push(tractor1);
            Tractors.Push(tractor2);

            Console.WriteLine("Vehicles are ready for the race.");
            Console.WriteLine("--------------------------------");

            while (s.ElapsedMilliseconds != 5000) { }
            s.Stop();
            s.Reset();

            Car car3 = new Car("Orange", "NI", 777);
            Cars.Add(car3);

            Console.WriteLine("Golf ({0}) has joined, and the race begins!", car3.Paint);
            Console.WriteLine("----------------------------------------------");

            s.Start();

            foreach (Car car in Cars)
            {
                car.Start();
            }

            foreach (Truck truck in Trucks)
            {
                truck.Start();
            }

            foreach (Tractor tractor in Tractors)
            {
                tractor.Start();
            }

            c.Wait();

            Console.ResetColor();

            if (finish.Count!=0)
            {
                Console.WriteLine();
                Console.WriteLine("Fastest red vehicle is: {0}", finish[0]);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Not one red vehicle has managed to finish the race.");
            }

            Console.ReadLine();
        }

        public static void RaceStarts()
        {
            int FuelSpend = r.Next(1, 3);
            int FuelVolume = r.Next(1, 50);

            while (s.ElapsedMilliseconds <= 10000)
            {
                if (s.ElapsedMilliseconds % 1000 == 0) { FuelVolume -= FuelSpend; Thread.Sleep(1); }

                if (FuelVolume <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} has run out of fuel.", Thread.CurrentThread.Name);
                    c.Signal();
                    Thread.CurrentThread.Abort();
                }
            }

            lock (TheLock)
            {
                if (!semaphore)
                {
                    Thread.Sleep(1);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Vehicles have reached semaphore!");
                    semaphore = true;
                } 
            }

            while (s.ElapsedMilliseconds <= 12000)
            {
                if (s.ElapsedMilliseconds % 1000 == 0) { FuelVolume -= FuelSpend; Thread.Sleep(1); }

                if (FuelVolume <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} has run out of fuel.", Thread.CurrentThread.Name);
                    c.Signal();
                    Thread.CurrentThread.Abort();
                }
            }

            while (s.ElapsedMilliseconds < 13000)
            {
                if (s.ElapsedMilliseconds % 1000 == 0) { FuelVolume -= FuelSpend; Thread.Sleep(1); }

                if (FuelVolume <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} has run out of fuel.", Thread.CurrentThread.Name);
                    c.Signal();
                    Thread.CurrentThread.Abort();
                }
            }

            if (FuelVolume < 15)
            {
                lock (TheLock)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("{0} is refuling", Thread.CurrentThread.Name);
                    FuelVolume = 50;
                }
            }

            while (s.ElapsedMilliseconds < 20000)
            {
                if (s.ElapsedMilliseconds % 1000 == 0) { FuelVolume -= FuelSpend; Thread.Sleep(1); }

                if (FuelVolume <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} has run out of fuel.", Thread.CurrentThread.Name);
                    c.Signal();
                    Thread.CurrentThread.Abort();
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} has finished the race!", Thread.CurrentThread.Name);

            if (Thread.CurrentThread.Name.Contains("Red"))
            {
                finish.Add(Thread.CurrentThread.Name);
            }
            c.Signal();
        }
    }
}

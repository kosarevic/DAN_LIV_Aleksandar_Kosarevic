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
    /// <summary>
    /// Program simulates different vehicles race.
    /// </summary>
    class Program
    {
        //Necessary static variables for application funtionality.
        public static object TheLock = new object();
        public static Stopwatch s = new Stopwatch();
        public static Random r = new Random();
        public static CountdownEvent c = new CountdownEvent(7);
        public static bool semaphore = false;
        public static ArrayList finish = new ArrayList();

        static void Main(string[] args)
        {
            //Stopwatch starts at the begining of program.
            s.Start();

            //Collection userd for Car objects.
            List<Car> Cars = new List<Car>();

            Car car1 = new Car("Red", "NS", 111);
            Car car2 = new Car("Red", "BG", 222);

            Cars.Add(car1);
            Cars.Add(car2);

            //Collection userd for Truck objects
            Queue<Truck> Trucks = new Queue<Truck>();

            Truck truck1 = new Truck("Red", "PA", 333);
            Truck truck2 = new Truck("Blue", "SU", 444);

            Trucks.Enqueue(truck1);
            Trucks.Enqueue(truck2);

            //Collection userd for Tractor objects.
            Stack<Tractor> Tractors = new Stack<Tractor>();

            Tractor tractor1 = new Tractor("White", "KR", 555);
            Tractor tractor2 = new Tractor("Red", "ZR", 666);

            Tractors.Push(tractor1);
            Tractors.Push(tractor2);

            //Vehicles are waiting at the start line, after being added to the coresponding lists.
            Console.WriteLine("Vehicles are ready for the race.");
            Console.WriteLine("--------------------------------");

            //When 5 seconds pass, Orange "Golf" is joining and race begins.
            while (s.ElapsedMilliseconds != 5000) { }
            //Stopwatch is reseted, to properly caculate race time.
            s.Stop();
            s.Reset();

            Car car3 = new Car("Orange", "NI", 777);
            Cars.Add(car3);

            Console.WriteLine("Golf ({0}) has joined, and the race begins!", car3.Paint);
            Console.WriteLine("----------------------------------------------");

            //Stopwatch starts to measure time once more.
            s.Start();

            //Each vehicle initiates its corresponding thread.
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

            //Countdown event waits for 7 threads to signal their completion.
            c.Wait();

            Console.ResetColor();

            //Only vehicles with Red paint are added to "finish" ArrayList collection and first one added is displayed on the console.
            if (finish.Count!=0)
            {
                Console.WriteLine();
                Console.WriteLine("Fastest red vehicle was: {0}", finish[0]);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Not one red vehicle has managed to finish the race.");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Method responsible for simulating race functionality.
        /// </summary>
        public static void RaceStarts()
        {
            //Variable simulates fuel expenditure every second while the race lasts (random number).
            int FuelSpend = r.Next(1, 3);
            //Variable simulates amount of fuel each vehicle starts with (random number).
            int FuelVolume = r.Next(1, 50);

            //Loop simulates first 10 seconds of the race, fuel is being spent continuously.
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

            //Lock added for the purpose of preventing console output for semaphore to be displayed more than once.
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

            //Loop simulates vehicles waiting 2 seconds on the semaphore.
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
            //Loop simulates conditions after semaphore ends and vehicles reach gas station.
            while (s.ElapsedMilliseconds <= 13000)
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

            //If vehicles has less than 15 liters of fuel it will start refuling.
            if (FuelVolume < 15)
            {
                lock (TheLock)
                {
                    Thread.Sleep(1);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("{0} is refuling", Thread.CurrentThread.Name);
                    FuelVolume = 50;
                }
            }

            //Race lasts for 7 seconds more, which is 20 in total time.
            while (s.ElapsedMilliseconds <= 20000)
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

            //Every vehicle that managed to reach finish line is displayed on the console.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} has finished the race!", Thread.CurrentThread.Name);
            
            //Only vehicles with "Red" paint are added to "finish" ArrayList collection.
            if (Thread.CurrentThread.Name.Contains("Red"))
            {
                finish.Add(Thread.CurrentThread.Name);
            }
            //Every thread signals countdown event upon method completion.
            c.Signal();
        }
    }
}

using System;
using System.Threading;

namespace Philosophers
{
    public class Philosopher
    {
        private int number;
        private bool[] availableForks;
        static Semaphore philosopherHungry = new Semaphore(2, 2);
        Thread thread;

        public Philosopher(int Number, ref bool[] AvailableForks)
        {
            number = Number;
            availableForks = AvailableForks;
            thread = new Thread(Eat);
            thread.Start();
        }

        public void Eat()
        {
            int leftForkIndex = number;
            int rightForkIndex = number - 1;
            if (rightForkIndex < 0)
            {
                rightForkIndex = 4;
            }

            Console.WriteLine("Philosopher №" + number + " is thinking");

            if (availableForks[leftForkIndex] == true && availableForks[rightForkIndex] == true)
            {
                availableForks[leftForkIndex] = false;
                availableForks[rightForkIndex] = false;
                philosopherHungry.WaitOne();
                Console.WriteLine("Philosopher №" + number + " is eating");
                philosopherHungry.Release();
                Console.WriteLine("Philosopher №" + number + "  put forks and begun thinking");
            }
        }
    }
}
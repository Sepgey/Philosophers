using System.Threading;
using Philosophers;

namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                bool[] availableForks = new bool[5] {true, true, true, true, true};

                for (int i = 0; i < 5; i++)
                {
                    Philosopher p = new Philosopher(i, ref availableForks);
                }

                Thread.Sleep(1000);
            }
        }
    }
}
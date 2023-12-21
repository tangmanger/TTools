using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        object locker = new object();
        static void Main(string[] args)
        {
            Action action = null;
            Task.Run(() =>
            {
                int index = 1;
                while (true)
                {
                    Task.Run(() =>
                    {
                        Thread.Sleep(10);
                        action = () =>
                        {
                            Console.WriteLine("=================================" + index);
                            Thread.Sleep(20);
                        };
                        index++;
                    });
                    Thread.Sleep(10);
                }

            });
            Task.Run(() =>
            {
                while (true)
                {
                    if (action != null)
                        action();
                    Thread.Sleep(1);
                }

            });
            Console.ReadKey();
        }
    }
}

using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Week7.WPF.AsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch timer = Stopwatch.StartNew(); //avvio il mio cronometro
            Coffee coffee = PourCoffee();
            Console.WriteLine("Coffee is ready");

            //Egg eggs = FryEggs(2);
            Egg eggs = await FryEggAsync(2);
            Console.WriteLine("Eggs are ready");

            //Bacon bacon = FryBacon(3);
            Bacon bacon = await FryBaconAsync(3);
            Console.WriteLine("Bacon is ready");

            //Toast toast = ToastBread(2);
            Toast toast = await ToastBreadAync(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("Toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("Orange juice is ready");
            Console.WriteLine("Breakfast is ready");
            Console.WriteLine($"It tooks {timer.ElapsedMilliseconds} ms");
        }

        //public static async Task Main(string[] args)
        //{
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    Coffee cup = PourCoffee();
        //    Console.WriteLine();


        //    //Lancio multithread dell'operazione
        //    Task<Egg> eggsTask = FryEggAsync(2);

        //    Task<Toast> toastTask = ToastBreadAync(2);

        //    Toast toast = await toastTask;
        //    ApplyButter(toast);
        //    ApplyJam(toast);
        //    Console.WriteLine("Toast is ready");
        //    Juice oj = PourOJ();
        //    Console.WriteLine("Oj is ready");

        //    Egg eggs = await eggsTask;
        //    Console.WriteLine("eggs are ready");
        //    Task<Bacon> baconTask = FryBaconAsync(2);
        //    Bacon bacon = await baconTask;
        //    Console.WriteLine("Bacon is ready");

        //    Console.WriteLine("Breakfast is ready");
        //    Console.WriteLine($"It tooks {stopwatch.ElapsedMilliseconds}");

        //}



        private static async Task<Toast> ToastBreadAync(int v)
        {
            for (int i = 0; i < v; i++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private async static Task<Bacon> FryBaconAsync(int v)
        {
            Console.WriteLine($"putting {v} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int i = 0; i < v; i++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second slice of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private async static Task<Egg> FryEggAsync(int v)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"Cracking {v} eggs");
            Console.WriteLine("cooking the eggs");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast)
        {
            Console.WriteLine("Putting jam on the toast");
        }

        private static void ApplyButter(Toast toast)
        {
            Console.WriteLine("Putting butter on the toast");
        }

        private static Toast ToastBread(int v)
        {
            for(int i = 0; i < v;i++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static Bacon FryBacon(int v)
        {
            Console.WriteLine($"putting {v} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait(); 
            for(int i = 0; i < v; i++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second slice of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static Egg FryEggs(int v)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"Cracking {v} eggs");
            Console.WriteLine("cooking the eggs");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }
}

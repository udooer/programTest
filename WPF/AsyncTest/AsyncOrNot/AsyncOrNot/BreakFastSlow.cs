using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AsyncOrNot
{
    class Coffee { };
    class Egg { };
    class Bacon { };
    class Toast {
        public void PrintToast() {
            Console.WriteLine("toast");
        } 
    };
    class Juice { };
    class BreakFastSlow
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Fast one");
            Toast t = new Toast();
            t.PrintToast();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<Egg> eggTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = ToastBreadAsync(2);

            Egg eggs = await eggTask;
            Console.WriteLine("eggs are ready");

            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready");

            Toast toast = await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            watch.Stop();
            Console.WriteLine($"Breakfast is ready! It takes {watch.Elapsed} seconds");
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
            Console.WriteLine("putting butter on the toast");
        }
        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int i = 0; i < slices; i++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.ReadKey();
            Console.WriteLine("Remove toast from toaster");
            return new Toast();
        }
        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }
        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }
        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        } 
    }
    #region without task
    //class BreakFastFast
    //{
    //    public static async Task Main(string[] args)
    //    {
    //        Console.WriteLine("Fast one");
    //        Stopwatch watch = new Stopwatch();
    //        watch.Start();
    //        Coffee cup = PourCoffee();
    //        Console.WriteLine("coffee is ready");

    //        Egg eggs = await FryEggsAsync(2);
    //        Console.WriteLine("eggs are ready");

    //        Bacon bacon = await FryBaconAsync(3);
    //        Console.WriteLine("bacon is ready");

    //        Toast toast = await ToastBreadAsync(2);
    //        ApplyButter(toast);
    //        ApplyJam(toast);
    //        Console.WriteLine("toast is ready");

    //        Juice oj = PourOJ();
    //        Console.WriteLine("oj is ready");
    //        watch.Stop();
    //        Console.WriteLine($"Breakfast is ready! It takes {watch.Elapsed} seconds");

    //    }
    //    private static Juice PourOJ()
    //    {
    //        Console.WriteLine("Pouring orange juice");
    //        return new Juice();
    //    }
    //    private static void ApplyJam(Toast toast)
    //    {
    //        Console.WriteLine("Putting jam on the toast");
    //    }
    //    private static void ApplyButter(Toast toast)
    //    {
    //        Console.WriteLine("putting butter on the toast");
    //    }
    //    private static async Task<Toast> ToastBreadAsync(int slices)
    //    {
    //        for (int i = 0; i < slices; i++)
    //        {
    //            Console.WriteLine("Putting a slice of bread in the toaster");
    //        }
    //        Console.WriteLine("Start toasting...");
    //        Task.Delay(3000).Wait();
    //        Console.WriteLine("Remove toast from toaster");
    //        return new Toast();
    //    }
    //    private static async Task<Bacon> FryBaconAsync(int slices)
    //    {
    //        Console.WriteLine($"putting {slices} slices of bacon in the pan");
    //        Console.WriteLine("cooking first side of bacon...");
    //        Task.Delay(3000).Wait();
    //        for (int slice = 0; slice < slices; slice++)
    //        {
    //            Console.WriteLine("flipping a slice of bacon");
    //        }
    //        Console.WriteLine("cooking the second side of bacon...");
    //        Task.Delay(3000).Wait();
    //        Console.WriteLine("Put bacon on plate");

    //        return new Bacon();
    //    }
    //    private static async Task<Egg> FryEggsAsync(int howMany)
    //    {
    //        Console.WriteLine("Warming the egg pan...");
    //        Task.Delay(3000).Wait();
    //        Console.WriteLine($"cracking {howMany} eggs");
    //        Console.WriteLine("cooking the eggs ...");
    //        Task.Delay(3000).Wait();
    //        Console.WriteLine("Put eggs on plate");

    //        return new Egg();
    //    }
    //    private static Coffee PourCoffee()
    //    {
    //        Console.WriteLine("Pouring coffee");
    //        return new Coffee();
    //    }
    //}
    #endregion
    #region sync example
    //class BreakFastSlow
    //{
    //    public static void Main(string[] args)
    //    {
    //        Stopwatch watch = new Stopwatch();
    //        watch.Start();
    //        Coffee cup = PourCoffee();
    //        Console.WriteLine("coffee is ready");

    //        Egg eggs = FryEggs(2);
    //        Console.WriteLine("eggs are ready");

    //        Bacon bacon = FryBacon(3);
    //        Console.WriteLine("bacon is ready");

    //        Toast toast = ToastBread(2);
    //        ApplyButter(toast);
    //        ApplyJam(toast);
    //        Console.WriteLine("toast is ready");

    //        Juice oj = PourOJ();
    //        Console.WriteLine("oj is ready");
    //        watch.Stop();
    //        Console.WriteLine($"Breakfast is ready! It takes {watch.Elapsed} seconds");

    //    }
    //    private static Juice PourOJ()
    //    {
    //        Console.WriteLine("Pouring orange juice");
    //        return new Juice();
    //    }
    //    private static void ApplyJam(Toast toast) {
    //        Console.WriteLine("Putting jam on the toast");
    //    }
    //    private static void ApplyButter(Toast toast) {
    //        Console.WriteLine("putting butter on the toast");
    //    }
    //    private static Toast ToastBread(int slices) {
    //        for (int i = 0; i < slices; i++) {
    //            Console.WriteLine("Putting a slice of bread in the toaster");
    //        }
    //        Console.WriteLine("Start toasting...");
    //        Task.Delay(3000).Wait();
    //        Console.WriteLine("Remove toast from toaster");
    //        return new Toast();
    //    }
    //    private static Bacon FryBacon(int slices)
    //    {
    //        Console.WriteLine($"putting {slices} slices of bacon in the pan");
    //        Console.WriteLine("cooking first side of bacon...");
    //        Task.Delay(3000).Wait();
    //        for (int slice = 0; slice < slices; slice++)
    //        {
    //            Console.WriteLine("flipping a slice of bacon");
    //        }
    //        Console.WriteLine("cooking the second side of bacon...");
    //        Task.Delay(3000).Wait();
    //        Console.WriteLine("Put bacon on plate");

    //        return new Bacon();
    //    }
    //    private static Egg FryEggs(int howMany)
    //    {
    //        Console.WriteLine("Warming the egg pan...");
    //        Task.Delay(3000).Wait();
    //        Console.WriteLine($"cracking {howMany} eggs");
    //        Console.WriteLine("cooking the eggs ...");
    //        Task.Delay(3000).Wait();
    //        Console.WriteLine("Put eggs on plate");

    //        return new Egg();
    //    }
    //    private static Coffee PourCoffee()
    //    {
    //        Console.WriteLine("Pouring coffee");
    //        return new Coffee();
    //    }
    //}
    #endregion
}


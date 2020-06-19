using System;
using System.Diagnostics;
using System.Threading;

namespace async_think
{
    public class Cake
    {
        public void MakeCake()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            PreheatOven();
            AddCakeIngredients();
            BakeCake();
            AddFrostingIngredients();
            CoolFrosting();
            CoolCake();
            FrostCake();

            stopWatch.Stop();

            Console.WriteLine("Synchronous time to make = {0} seconds.", Utilities.GetFormattedElapsedTime(stopWatch));
        }

        private void PreheatOven()
        {
            Console.WriteLine("Preheating oven...");
            Thread.Sleep(2500);
            Console.WriteLine("Oven is ready!");
        }

        private void AddCakeIngredients()
        {
            Thread.Sleep(500);
            Console.WriteLine("Added cake mix");
            Thread.Sleep(500);
            Console.WriteLine("Added milk");
            Thread.Sleep(500);
            Console.WriteLine("Added vegetable oil");
            Thread.Sleep(500);
            Console.WriteLine("Added eggs");

            Console.WriteLine("Cake ingredients mixed!");
        }

        private void BakeCake()
        {
            Console.WriteLine("Baking cake...");
            Thread.Sleep(5000);
            Console.WriteLine("Cake is done baking!");
        }

        private void AddFrostingIngredients()
        {
            Thread.Sleep(500);
            Console.WriteLine("Added cream cheese");
            Thread.Sleep(500);
            Console.WriteLine("Added milk");
            Thread.Sleep(500);
            Console.WriteLine("Added vegetable oil");
            Thread.Sleep(500);
            Console.WriteLine("Added eggs");

            Console.WriteLine("Frosting ingredients mixed!");
        }

        private void CoolFrosting()
        {
            Console.WriteLine("Cooling frosting...");
            Thread.Sleep(2500);
            Console.WriteLine("Frosting is cooled!");
        }

        private void CoolCake()
        {
            Console.WriteLine("Cooling cake...");
            Thread.Sleep(2500);
            Console.WriteLine("Cake is cooled!");
        }

        private void FrostCake()
        {
            Console.WriteLine("Frosting cake...");
            Thread.Sleep(1000);
            Console.WriteLine("Cake is frosted!");
        }
    }
}

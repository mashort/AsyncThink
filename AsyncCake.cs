using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace async_think
{
    public class AsyncCake
    {
        // THE Task TYPE:
        // => Tells the caller about the eventual return value type
        // => Indicates that other actions can execute while the caller method is being processed

        // THE async KEYWORD:
        // => Enables the await keyword, which lets the compiler know that we’ll need the return value of the function, but not right away
        // => Therefore, we don’t need to block the call and can continue running other tasks until the awaited value is needed

        // An async method will initially run synchronously until it hits an await keyword, then asynchronous execution begins

        public async Task MakeCakeAsync()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            // start/store this task (no blocking needed!) and come back to it later
            Task<bool> preheatTask = PreheatOvenAsync();
            // mix cake base ingredients while waiting for the oven to preheat
            AddCakeIngredients();
            // get the result of the PreheatOvenAsync() method in order to bake the cake
            bool isPreheated = await preheatTask;

            // start baking the cake and do other things while baking it
            Task<bool> bakeCakeTask = BakeCakeAsync(isPreheated);
            // make the frosting while the cake is baking
            AddFrostingIngredients();
            // start cooling the frosting and come back to it when needed
            Task<bool> coolFrostingTask = CoolFrostingAsync();
            // do other things while cake is baking and frosting is cooling
            PassTheTime();
            // get the result of BakeCakeAsync() method in order to cool the cake
            bool isBaked = await bakeCakeTask;

            // start cooling the cake after it's done baking
            Task<bool> coolCakeTask = CoolCakeAsync(isBaked);

            // get the result of CoolCakeAsync() method when finished
            bool cakeIsCooled = await coolCakeTask;

            // get the result of CoolFrostingAsync() when finished
            bool frostingIsCooled = await coolFrostingTask;

            // frost the cake once the cake and frosting are cooled
            FrostCake(cakeIsCooled, frostingIsCooled);

            stopWatch.Stop();

            Console.WriteLine("Asynchronous time to make = {0} seconds.", Utilities.GetFormattedElapsedTime(stopWatch));
        }

        private async Task<bool> PreheatOvenAsync()
        {
            Console.WriteLine("Preheating oven...");
            await Task.Delay(2500);
            Console.WriteLine("Oven is ready!");
            return true;
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

        private async Task<bool> BakeCakeAsync(bool isPreheated)
        {
            if (isPreheated)
            {
                Console.WriteLine("Baking cake...");
                await Task.Delay(5000);
                Console.WriteLine("Cake is done baking!");
                return true;
            }
            return false;
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

        private async Task<bool> CoolFrostingAsync()
        {
            Console.WriteLine("Cooling frosting...");
            await Task.Delay(2500);
            Console.WriteLine("Frosting is cooled!");
            return true;
        }

        private async Task<bool> CoolCakeAsync(bool isBaked)
        {
            if (isBaked)
            {
                Console.WriteLine("Cooling cake...");
                await Task.Delay(2500);
                Console.WriteLine("Cake is cooled!");
                return true;
            }
            return false;
        }

        private void FrostCake(bool cakeIsCooled, bool frostingIsCooled)
        {
            if (cakeIsCooled && frostingIsCooled)
            {
                Console.WriteLine("Frosting cake...");
                Thread.Sleep(1000);
                Console.WriteLine("Cake is frosted!");
            }
        }

        private void PassTheTime()
        {
            Thread.Sleep(500);
            Console.WriteLine("Watched TV");
            Thread.Sleep(500);
            Console.WriteLine("Ate lunch");
            Thread.Sleep(500);
            Console.WriteLine("Cleaned the kitchen");
        }
    }
}

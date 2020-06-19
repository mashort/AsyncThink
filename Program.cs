using System.Threading.Tasks;

namespace async_think
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    new Cake().MakeCake();
        //}

        static async Task Main(string[] args)
        {
            await new AsyncCake().MakeCakeAsync();
        }
    }
}

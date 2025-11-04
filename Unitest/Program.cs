using DBL;
using Model;
using static System.Net.Mime.MediaTypeNames;

namespace Unitest
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            Console.WriteLine("Hello, kabab romani hamodi!");
            PlayerDB db = new PlayerDB();

            //TEST Get All Players
            List<Player> list = await db.GetAllAsync();
            for (int i = 0; i < list.Count; i++)
            {
                await Console.Out.WriteLineAsync(@$" id={list[i].PlayerID} name={list[i].UserName} email={list[i].Email}");
            }
            await Console.Out.WriteLineAsync("\n\n");

        }
    }
}

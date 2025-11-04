using DBL;
using Model;

namespace ConsoleUnitTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("khdodiku ");

            PlayerDB db = new PlayerDB();

            //TEST Get All Players
            List<Player> list = await db.GetAllAsync();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    await Console.Out.WriteLineAsync(@$" id={list[i].PlayerID} name={list[i].UserName} email={list[i].Email}"); //כדי להדפיס את הליסט
            //}
            //await Console.Out.WriteLineAsync("\n\n");
            //לינה
            //המלכה
            //של
            //כולםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםםם


            //הכל יעבוד לך!!:)
            //Test Insert new customer Async
            Player player = new Player(2, "khdodhanasich", "khdodi@gmail.com", 1, null, 6700);
            await db.InsertAsync(player, "emashelimalca");
            //await Console.Out.WriteLineAsync($"id: {player.PlayerID} name: {player.UserName} email: {player.Email}\n\n");
            
            

        }
    }
}

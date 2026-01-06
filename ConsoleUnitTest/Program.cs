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
            List<Player> list = await db.GetAllAsync();

            //TEST Get All Players
            ///
            //for (int i = 0; i < list.Count; i++)
            //{
            //    await Console.Out.WriteLineAsync(@$" id={list[i].PlayerID} name={list[i].UserName} email={list[i].Email}"); //כדי להדפיס את הליסט
            //}
            //await Console.Out.WriteLineAsync("\n\n");
            ///
            ////מדפיס את כל המשתמשים


            ////Test Insert new customer Async
            ///
            //Player player = new Player("A.B.A.", "ABA@gmail.com", 0, null, 23);
            //player = await db.InsertAsync(player, "ParacelsusMWAHMWAHMWAH");
            //Console.WriteLine("Josh");
            ////await Console.Out.WriteLineAsync($"id: {player.PlayerID} name: {player.UserName} email: {player.Email}\n\n");


            ////Update Testing
            ///
            ////basic update
            //list[2].UserName = "A.B.A.";
            //await db.UpdateAsync(list[2]); 
            ///
            ////password update
            //list[1].Password = "me? ow....";
            //await db.UpdatePassAsync(list[1]);

            //Console.WriteLine("bonjour");

            
            ///await db.updateImageAsync(list[0].PlayerID, DBNull.Value); /////לא עובדב הצילו

            // delete testing
            //await db.DeleteAsync(list[1]);
            //Console.WriteLine("bonjour");





        }
    }
}

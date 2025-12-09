using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class Player
    {
        
        public int PlayerID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int IsAdmin { get; set; } // ערך 0 למשתמש וכל ערך אחר לאדמין
        public byte[] ProfilePicture { get; set; }
        public int Tokens { get; set; }
        public DateTime DateCode { get; set; }
        public int TempCode { get; set; }

        //ריק
        public Player() { }
            //בלי סיסמה
        public Player(int playerID, string userName, string email, int isAdmin, byte[] profilePicture, int tokens)
        {
            PlayerID = playerID;
            UserName = userName;
            Email = email;
            IsAdmin = isAdmin;
            ProfilePicture = profilePicture;
            Tokens = tokens;
        }
            // בלי סיסמה+ בלי תז
        public Player(string userName, string email, int isAdmin, byte[] profilePicture, int tokens)
        {
            UserName = userName;
            Email = email;
            IsAdmin = isAdmin;
            ProfilePicture = profilePicture;
            Tokens = tokens;
        }
        //עם סיסמה
        public Player(int playerID, string userName, string password, string email, int isAdmin, byte[] profilePicture, int tokens)
        {
            PlayerID = playerID;
            UserName = userName;
            Password = password;
            Email = email;
            IsAdmin = isAdmin;
            ProfilePicture = profilePicture;
            Tokens = tokens;
        }
            //עם סיסמה+ בלי תז
        public Player(string userName, string password, string email, int isAdmin, byte[] profilePicture, int tokens)
        {
            UserName = userName;
            Password = password;
            Email = email;
            IsAdmin = isAdmin;
            ProfilePicture = profilePicture;
            Tokens = tokens;
        }

    }
}

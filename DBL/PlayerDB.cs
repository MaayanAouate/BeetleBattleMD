using Model;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class PlayerDB : BaseDB<Player>
    {
        protected override async Task<Player> CreateModelAsync(object[] row)
        {
            Player bob = new Player();
            bob.PlayerID = int.Parse(row[0].ToString());
            bob.UserName = row[1].ToString();
            bob.Email = row[3].ToString();
            bob.IsAdmin = int.Parse(row[6].ToString());
            bob.Tokens = int.Parse(row[5].ToString());
            try
            {
                bob.ProfilePicture = (byte[])row[4];
            }
            catch { }
            return bob;
        }

        protected override string GetPrimaryKeyName()

        {
            return "PlayerID";
        }

        protected override string GetTableName()
        {
            return "player";
        }

        public async Task<List<Player>> GetAllAsync()
        {
            return ((List<Player>)await SelectAllAsync());
        }

        public async Task<Player> InsertAsync(Player player, String Password)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>
            {
                { "UserName", player.UserName },
                { "Password", Password },
                { "Email", player.Email }              
            };
            if (player.ProfilePicture != null)
                fillValues.Add("Profile Picture", player.ProfilePicture);
            return (Player)await base.InsertGetObjAsync(fillValues);

        }
        public async Task<int> UpdateAsync(Player player)// אפדייט לנתונים
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("UserName", player.UserName);
            fillValues.Add("Email", player.Email);
            filterValues.Add("PlayerID", player.PlayerID.ToString());
            return await base.UpdateAsync(fillValues, filterValues);
        }

        public async Task<int> UpdatePassAsync(Player player)// אפדייט נתונים+סיסמה
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("Password", player.Password);
            filterValues.Add("PlayerID", player.PlayerID.ToString());
            return await base.UpdateAsync(fillValues, filterValues);
        }

        public async Task<int> updateImageAsync(int PlayerID, byte[] ProfilePic)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("ProfilePicture", ProfilePic.ToString());
            filterValues.Add("PlayerID", PlayerID.ToString());
            return await base.UpdateAsync(fillValues, filterValues);
        }

        public async Task<int> UpdateTokensAsync(Player player)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("Tokens", player.Tokens);
            filterValues.Add("PlayerID", player.PlayerID.ToString());
            return await base.UpdateAsync(fillValues, filterValues);
        }

        public async Task<int> DeleteAsync(Player player) // מחיקת משתמש לפי הID שלו
        {
            Dictionary<string, object> filterValues = new Dictionary<string, object>
            {
                { "PlayerID", player.PlayerID.ToString() }
            };
            return await base.DeleteAsync(filterValues);
        }

        public async Task<Player> LoginAsync(string Email, string Password)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("Email", Email);
            p.Add("Password", Password);
            List<Player> list = (List<Player>)await SelectAllAsync(p);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public async Task<Player> ForgotPassAsync(string Email, int Code)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("Email", Email);
            p.Add("TempCode", Code);
            List<Player> list = (List<Player>)await SelectAllAsync(p);
            if (list.Count == 1)
            {
                Player pl =  list[0];
                TimeSpan ts = DateTime.Now.Subtract(pl.DateCode);
                double sec = ts.TotalSeconds;
                if (sec <= (60 * 5))
                {
                    return pl;
                }
                else return null;
            }
            else
                return null;
        }

        public async Task<int> UpdateTempCodeAsync(Player player)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("DateCode", player.DateCode);
            fillValues.Add("TempCode", player.TempCode);
            filterValues.Add("PlayerID", player.PlayerID.ToString());
            return await base.UpdateAsync(fillValues, filterValues);
        }

    }
}

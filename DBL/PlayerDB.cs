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
        public async Task<int> UpdateAsync(Player player)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("UserName", player.UserName);
            fillValues.Add("Email", player.Email);
            filterValues.Add("PlayerID", player.PlayerID.ToString());
            return await base.UpdateAsync(fillValues, filterValues);
        }



    }
}

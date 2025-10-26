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
            bob.ProfilePicture = (byte[])row[4];
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

        public async Insert
    }
}

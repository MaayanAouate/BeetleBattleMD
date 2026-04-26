using Model;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace DBL
{
    public class CharacterDB : BaseDB<Character>
    {
        protected override async Task<Character> CreateModelAsync(object[] row)
        {
            Character beetle = new Character();
            beetle.CharacterID = int.Parse(row[0].ToString());
            beetle.CharacterName = row[1].ToString();
            beetle.Attack = int.Parse(row[2].ToString());
            beetle.HealthPoints = int.Parse(row[3].ToString());
            beetle.Defence = int.Parse(row[4].ToString());
            beetle.CritRate = double.Parse(row[5].ToString());
            beetle.Rarity = row[6].ToString();

            return beetle;
        }

        protected override string GetPrimaryKeyName()

        {
            return "CharacterID";
        }

        protected override string GetTableName()
        {
            return "character";
        }
        public async Task<List<Character>> GetAllAsync()
        {
            return ((List<Character>)await SelectAllAsync());
        }

        public async Task<List<Character>> GetAllByPlayerID(int playerid)
        {
            string s = @"Select `character`.*
                         From player_characters
                         Inner Join `character` On player_characters.CharacterID = `character`.CharacterID 
                         Inner Join player On player_characters.PlayerID = player.PlayerID";
                         //Where player.PlayerID = @id";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("player.PlayerID", playerid);
            List<Character> lst = await SelectAllAsync(s, p);
            return lst;
        }







    }
}

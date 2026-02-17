using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DBL
{
    public class CharacterDataDB : BaseDB<CharacterData>
    {
        protected async override Task<CharacterData> CreateModelAsync(object[] row)
        {
            CharacterData beetle = new CharacterData();
            beetle.CharacterID = int.Parse(row[0].ToString());
            beetle.CharacterName = row[1].ToString();
            beetle.Attack = int.Parse(row[2].ToString());
            beetle.HealthPoints = int.Parse(row[3].ToString());
            beetle.Defence = int.Parse(row[4].ToString());
            beetle.CritRate = double.Parse(row[5].ToString());
            beetle.Rarity = row[6].ToString();
            beetle.Accension = int.Parse(row[7].ToString());
            beetle.Counter = int.Parse(row[8].ToString());
            return beetle;
        }

        protected override string GetPrimaryKeyName()
        {
            return null;
        }

        protected override string GetTableName()
        {
            return null;
        }

        public async Task<List<CharacterData>> SelectCharacterData(int playerID)
        {
            string sql = @$" Select    `character`.*,    player_characters.Accension,    player_characters.Counter
                            From    `character` 
                            Inner Join    player_characters On player_characters.CharacterID = `character`.CharacterID 
                            Inner Join    player On player_characters.PlayerID = player.PlayerID 
                            Where    player.PlayerID = {playerID}";
            List<CharacterData> beetles =  (List<CharacterData>)(await base.SelectAllAsync(sql));
            return beetles;
        }
    }
}

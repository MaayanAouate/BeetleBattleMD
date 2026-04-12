using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class PlayerCharactersDB : BaseDB<PlayerCharacters>
    {
        protected override async Task<PlayerCharacters> CreateModelAsync(object[] row)
        {
            PlayerCharacters pc = new PlayerCharacters();
            pc.PlayerID = int.Parse(row[0].ToString());
            pc.CharacterID = int.Parse(row[1].ToString());
            pc.Counter = int.Parse(row[2].ToString());
            return pc;
        }

        protected override string GetPrimaryKeyName()
        {
            // בטבלת קישור לרוב יש מפתח מורכב, נחזיר את אחד מהם כברירת מחדל
            return "PlayerID";
        }

        protected override string GetTableName()
        {
            return "player_characters";
        }

        public async Task<List<PlayerCharacters>> GetAllAsync()
        {
            return (List<PlayerCharacters>)await SelectAllAsync();
        }

        public async Task<List<PlayerCharacters>> GetByPlayerIdAsync(int playerId)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>
            {
                { "PlayerID", playerId }
            };
            return (List<PlayerCharacters>)await SelectAllAsync(filter);
        }

        public async Task<PlayerCharacters> InsertAsync(PlayerCharacters pc)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>
            {
                { "PlayerID", pc.PlayerID },
                { "CharacterID", pc.CharacterID },
                { "Counter", pc.Counter }
            };
            return (PlayerCharacters)await base.InsertGetObjAsync(fillValues);
        }

        public async Task<int> UpdateCounterAsync(PlayerCharacters pc)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();

            fillValues.Add("Counter", pc.Counter);

            // עדכון ספציפי לפי השילוב של השחקן והדמות
            filterValues.Add("PlayerID", pc.PlayerID.ToString());
            filterValues.Add("CharacterID", pc.CharacterID.ToString());

            return await base.UpdateAsync(fillValues, filterValues);
        }

        public async Task<int> DeleteAsync(PlayerCharacters pc)
        {
            Dictionary<string, object> filterValues = new Dictionary<string, object>
            {
                { "PlayerID", pc.PlayerID.ToString() },
                { "CharacterID", pc.CharacterID.ToString() }
            };
            return await base.DeleteAsync(filterValues);
        }

        /// <summary>
        /// פונקציה לבדיקה האם לשחקן כבר יש דמות מסוימת
        /// </summary>
        public async Task<PlayerCharacters> GetSpecificCharacterAsync(int playerId, int characterId)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>();
            filter.Add("PlayerID", playerId);
            filter.Add("CharacterID", characterId);

            List<PlayerCharacters> list = (List<PlayerCharacters>)await SelectAllAsync(filter);
            return list.Count > 0 ? list[0] : null;
        }
    }
}

//using Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DBL
//{
//        public class PlayerCharactersDB : BaseDB<PlayerCharacters>
//        {


//            protected override async Task<PlayerCharacters> CreateModelAsync(object[] row)
//            {
//                PlayerCharacters pc= new PlayerCharacters();
//                pc.PlayerID = int.Parse(row[0].ToString());
//                pc.CharacterID = int.Parse(row[1].ToString());
//                pc.Counter = int.Parse(row[2].ToString());
//                return pc;
//            }

//            protected override string GetPrimaryKeyName()
//            {
//                return "";
//            }

//            protected override string GetTableName()
//            {
//                return "player_characters";
//            }




//        }
//    }

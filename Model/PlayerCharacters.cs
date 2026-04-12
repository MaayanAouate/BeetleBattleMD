using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PlayerCharacters
    {
        public int PlayerID { get; set; }
        public int CharacterID { get; set; }
        public int Counter { get; set; }

        public PlayerCharacters()
        {
        }
        public PlayerCharacters(int PlayerID, int characterID, int Counter)
        {
            PlayerID = PlayerID;
            CharacterID = characterID;
        }

        public int GetLevel()
        {
            return Counter / 3;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Character
    {
    

        public int CharacterID { get; set; }
        public string CharacterName { get; set; }
        public int Attack { get; set; }
        public int HealthPoints { get; set; }
        public int Defence { get; set; }
        public double CritRate { get; set; }

        public Character()
        {
        }
        public Character(int characterID, string characterName, int attack, int healthPoints, int defence, double critRate)
        {
            CharacterID = characterID;
            CharacterName = characterName;
            Attack = attack;
            HealthPoints = healthPoints;
            Defence = defence;
            CritRate = critRate;
        }

    }

}

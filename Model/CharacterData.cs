using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CharacterData
    {
        public int CharacterID { get; set; }
        public string CharacterName { get; set; }
        public int Attack { get; set; }
        public int HealthPoints { get; set; }
        public int Defence { get; set; }
        public double CritRate { get; set; }
        public string Rarity { get; set; }
        public int Accension { get; set; }
        public int Counter { get; set; }

        public CharacterData(int characterID, string characterName, int attack, int healthPoints, int defence, double critRate, string rarity, int accension, int counter)
        {
 
            CharacterID = characterID;
            CharacterName = characterName;
            Attack = attack;
            HealthPoints = healthPoints;
            Defence = defence;
            CritRate = critRate;
            Rarity = rarity;
            Accension = accension;
            Counter = counter;
        }
        public CharacterData()
        { }


    }
}

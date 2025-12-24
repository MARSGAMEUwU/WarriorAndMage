using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorAndMageProject
{
    internal class Weapon : Item
    {
        private readonly int bonusDamage;
        private readonly int bonusStrength;
        private readonly int bonusIntelligence;
        private readonly CharacterClass requiredClass;

        public int BonusDamage => bonusDamage;
        public int BonusStrength => bonusStrength;
        public int BonusIntelligence => bonusIntelligence;
        public CharacterClass RequiredClass => requiredClass;

        public Weapon(int maxStack, string name, string description,
                     int bonusDamage, int bonusStrength = 0, int bonusIntelligence = 0,
                     CharacterClass requiredClass = CharacterClass.Any)
            : base(maxStack, name, description)
        {
            this.bonusDamage = bonusDamage;
            this.bonusStrength = bonusStrength;
            this.bonusIntelligence = bonusIntelligence;
            this.requiredClass = requiredClass;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorAndMageProject
{
    internal class Armor : Item
    {
        private readonly ArmorType armorType;
        private readonly int defense;
        private readonly int bonusStrength;
        private readonly int bonusIntelligence;
        private readonly CharacterClass requiredClass;

        public ArmorType ArmorType => armorType;
        public int Defense => defense;
        public int BonusStrength => bonusStrength;
        public int BonusIntelligence => bonusIntelligence;
        public CharacterClass RequiredClass => requiredClass;

        public Armor(int maxStack, string name, string description,
                    ArmorType armorType, int defense = 0,
                    int bonusStrength = 0, int bonusIntelligence = 0,
                    CharacterClass requiredClass = CharacterClass.Any)
            : base(maxStack, name, description)
        {
            this.armorType = armorType;
            this.defense = defense;
            this.bonusStrength = bonusStrength;
            this.bonusIntelligence = bonusIntelligence;
            this.requiredClass = requiredClass;
        }
    }
}

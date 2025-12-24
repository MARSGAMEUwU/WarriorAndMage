using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorAndMageProject
{
    internal class Mage : Player
    {
        private int mana;
        private int intelligence;
        private const int intelligenceMultiplier = 5;

        public Mage(int maxHealth, int baseDamage, int intelligence, string name, Inventory inventory)
    : base(maxHealth, baseDamage, name, inventory)
        {
            mana = 0;
            this.intelligence = intelligence;
            this.baseDamage = baseDamage + intelligenceMultiplier * intelligence;
            EquipmentManager.SetPlayerClass(CharacterClass.Mage);
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void ApplyDamage(int damage)
        {
            throw new NotImplementedException();
        }
    }
}

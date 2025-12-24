using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorAndMageProject
{
    internal class Warrior : Player
    {
        private int rage;
        private int strength;
        private const int strengthMultiplier = 20;

        public Warrior(int maxHealth, int baseDamage, int strength, string name, Inventory inventory)
    : base(maxHealth, baseDamage, name, inventory)
        {
            rage = 0;
            this.strength = strength;
            this.baseDamage = baseDamage + strengthMultiplier * strength;

            EquipmentManager.SetPlayerClass(CharacterClass.Warrior);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorAndMageProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Inventory inventory = new Inventory();

            Console.WriteLine("            ВОИН", Console.ForegroundColor=ConsoleColor.Red);
            Console.ForegroundColor = ConsoleColor.White;
            EquipmentManager.SetPlayerClass(CharacterClass.Warrior);



            Weapon warriorSword = new Weapon(1, "Меч воина", "Мощный меч для воина",
                bonusDamage: 10, bonusStrength: 5, requiredClass: CharacterClass.Warrior);

            Armor warriorHelmet = new Armor(1, "Шлем воина", "Прочный шлем",
                ArmorType.Head, defense: 5, bonusStrength: 2, requiredClass: CharacterClass.Warrior);

            Armor strengthRing = new Armor(1, "Кольцо силы", "Увеличивает силу",
                ArmorType.Ring, bonusStrength: 3, requiredClass: CharacterClass.Any);



            EquipmentManager.EquipWeapon(warriorSword);
            EquipmentManager.EquipArmor(warriorHelmet);
            EquipmentManager.EquipArmor(strengthRing);

            EquipmentManager.DisplayEquipment();




            Console.WriteLine("\nЭкипирую предмет не того класса", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Weapon mageStaff = new Weapon(1, "Посох мага", "Магический посох", bonusDamage: 5, bonusIntelligence: 10, requiredClass: CharacterClass.Mage);



            EquipmentManager.EquipWeapon(mageStaff);

            Console.WriteLine("\n            МАГ", Console.ForegroundColor = ConsoleColor.Blue);
            Console.ForegroundColor = ConsoleColor.White;
            EquipmentManager.SetPlayerClass(CharacterClass.Mage);

            EquipmentManager.EquipWeapon(mageStaff);



            Armor magicNecklace = new Armor(1, "Ожерелье мудрости", "Увеличивает интеллект", ArmorType.Necklace, bonusIntelligence: 7, requiredClass: CharacterClass.Mage);



            EquipmentManager.EquipArmor(magicNecklace);

            EquipmentManager.DisplayEquipment();

            Console.WriteLine("\nСнимаю броню", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            EquipmentManager.UnequipWeapon();
            EquipmentManager.UnequipArmor(ArmorType.Necklace);

            EquipmentManager.DisplayEquipment();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorAndMageProject
{
    internal static class EquipmentManager
    {
        private static Weapon equippedWeapon;
        private static Armor headArmor;
        private static Armor bodyArmor;
        private static Armor handsArmor;
        private static Armor legsArmor;
        private static Armor bootsArmor;

        private static Armor ring1;
        private static Armor ring2;
        private static Armor necklace;

        private static CharacterClass currentPlayerClass;

        public static void SetPlayerClass(CharacterClass playerClass)
        {
            currentPlayerClass = playerClass;
        }

        public static bool EquipWeapon(Armor Armor)
        {
            Console.WriteLine("Нельзя экипировать броню в оружие");
            return false;
        }

        public static bool EquipWeapon(Weapon weapon)
        {
            if (weapon == null) return false;
            if (weapon.RequiredClass != CharacterClass.Any && weapon.RequiredClass != currentPlayerClass)
            {
                Console.WriteLine($"Оружие '{weapon.Name}' нельзя экипировать персонажу класса {currentPlayerClass}");
                return false;
            }
            if (equippedWeapon != null)
            {
                UnequipWeapon();
            }

            equippedWeapon = weapon;
            Console.WriteLine($"Экипировано оружие: {weapon.Name}");
            return true;
        }

        public static bool EquipArmor(Weapon weapon)
        {
            Console.WriteLine("Нельзя экипировать оружие в броню");
            return false;
        }
        public static bool EquipArmor(Armor armor)
        {
            if (armor == null) return false;
            if (armor.RequiredClass != CharacterClass.Any && armor.RequiredClass != currentPlayerClass)
            {
                Console.WriteLine($"Броню '{armor.Name}' нельзя экипировать персонажу класса {currentPlayerClass}");
                return false;
            }
            switch (armor.ArmorType)
            {
                case ArmorType.Head:
                    if (headArmor != null) UnequipArmor(ArmorType.Head);
                    headArmor = armor;
                    break;

                case ArmorType.Body:
                    if (bodyArmor != null) UnequipArmor(ArmorType.Body);
                    bodyArmor = armor;
                    break;

                case ArmorType.Hands:
                    if (handsArmor != null) UnequipArmor(ArmorType.Hands);
                    handsArmor = armor;
                    break;

                case ArmorType.Legs:
                    if (legsArmor != null) UnequipArmor(ArmorType.Legs);
                    legsArmor = armor;
                    break;

                case ArmorType.Boots:
                    if (bootsArmor != null) UnequipArmor(ArmorType.Boots);
                    bootsArmor = armor;
                    break;

                case ArmorType.Ring:
                    if (ring1 == null)
                    {
                        ring1 = armor;
                    }
                    else if (ring2 == null)
                    {
                        ring2 = armor;
                    }
                    else
                    {
                        Console.WriteLine("Все слоты для колец заняты!");
                        return false;
                    }
                    break;

                case ArmorType.Necklace:
                    if (necklace != null) UnequipArmor(ArmorType.Necklace);
                    necklace = armor;
                    break;

                default:
                    Console.WriteLine($"Неизвестный тип брони: {armor.ArmorType}");
                    return false;
            }

            Console.WriteLine($"Экипирована броня: {armor.Name} в слот {armor.ArmorType}");
            return true;
        }

        public static bool UnequipWeapon()
        {
            if (equippedWeapon == null)
            {
                Console.WriteLine("Оружие не экипировано");
                return false;
            }

            Console.WriteLine($"Снято оружие: {equippedWeapon.Name}");
            equippedWeapon = null;
            return true;
        }

        public static bool UnequipArmor(ArmorType armorType)
        {
            switch (armorType)
            {
                case ArmorType.Head:
                    if (headArmor == null) return false;
                    Console.WriteLine($"Снята броня: {headArmor.Name} с головы");
                    headArmor = null;
                    break;

                case ArmorType.Body:
                    if (bodyArmor == null) return false;
                    Console.WriteLine($"Снята броня: {bodyArmor.Name} с тела");
                    bodyArmor = null;
                    break;

                case ArmorType.Hands:
                    if (handsArmor == null) return false;
                    Console.WriteLine($"Снята броня: {handsArmor.Name} с рук");
                    handsArmor = null;
                    break;

                case ArmorType.Legs:
                    if (legsArmor == null) return false;
                    Console.WriteLine($"Снята броня: {legsArmor.Name} с ног");
                    legsArmor = null;
                    break;

                case ArmorType.Boots:
                    if (bootsArmor == null) return false;
                    Console.WriteLine($"Снята броня: {bootsArmor.Name} с обуви");
                    bootsArmor = null;
                    break;

                case ArmorType.Ring:
                    if (ring1 != null)
                    {
                        Console.WriteLine($"Снято кольцо: {ring1.Name}");
                        ring1 = null;
                        return true;
                    }
                    else if (ring2 != null)
                    {
                        Console.WriteLine($"Снято кольцо: {ring2.Name}");
                        ring2 = null;
                        return true;
                    }
                    return false;

                case ArmorType.Necklace:
                    if (necklace == null) return false;
                    Console.WriteLine($"Снято ожерелье: {necklace.Name}");
                    necklace = null;
                    break;

                default:
                    return false;
            }

            return true;
        }

        public static int GetArmorPoints()
        {
            int totalDefense = 0;

            if (headArmor != null) totalDefense += headArmor.Defense;
            if (bodyArmor != null) totalDefense += bodyArmor.Defense;
            if (handsArmor != null) totalDefense += handsArmor.Defense;
            if (legsArmor != null) totalDefense += legsArmor.Defense;
            if (bootsArmor != null) totalDefense += bootsArmor.Defense;

            return totalDefense;
        }

        public static int GetTotalBonusDamage()
        {
            return equippedWeapon?.BonusDamage ?? 0;
        }

        public static int GetTotalBonusStrength()
        {
            int totalStrength = equippedWeapon?.BonusStrength ?? 0;

            if (headArmor != null) totalStrength += headArmor.BonusStrength;
            if (bodyArmor != null) totalStrength += bodyArmor.BonusStrength;
            if (handsArmor != null) totalStrength += handsArmor.BonusStrength;
            if (legsArmor != null) totalStrength += legsArmor.BonusStrength;
            if (bootsArmor != null) totalStrength += bootsArmor.BonusStrength;
            if (ring1 != null) totalStrength += ring1.BonusStrength;
            if (ring2 != null) totalStrength += ring2.BonusStrength;
            if (necklace != null) totalStrength += necklace.BonusStrength;

            return totalStrength;
        }

        public static int GetTotalBonusIntelligence()
        {
            int totalIntelligence = equippedWeapon?.BonusIntelligence ?? 0;

            if (headArmor != null) totalIntelligence += headArmor.BonusIntelligence;
            if (bodyArmor != null) totalIntelligence += bodyArmor.BonusIntelligence;
            if (handsArmor != null) totalIntelligence += handsArmor.BonusIntelligence;
            if (legsArmor != null) totalIntelligence += legsArmor.BonusIntelligence;
            if (bootsArmor != null) totalIntelligence += bootsArmor.BonusIntelligence;
            if (ring1 != null) totalIntelligence += ring1.BonusIntelligence;
            if (ring2 != null) totalIntelligence += ring2.BonusIntelligence;
            if (necklace != null) totalIntelligence += necklace.BonusIntelligence;

            return totalIntelligence;
        }

        public static void DisplayEquipment()
        {
            Console.WriteLine("\n        ЭКИПИРОВКА", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Оружие: {equippedWeapon?.Name ?? "Не экипировано"}");
            Console.WriteLine($"Шлем: {headArmor?.Name ?? "Не экипирован"}");
            Console.WriteLine($"Нагрудник: {bodyArmor?.Name ?? "Не экипирован"}");
            Console.WriteLine($"Перчатки: {handsArmor?.Name ?? "Не экипированы"}");
            Console.WriteLine($"Поножи: {legsArmor?.Name ?? "Не экипированы"}");
            Console.WriteLine($"Обувь: {bootsArmor?.Name ?? "Не экипирована"}");
            Console.WriteLine($"Кольцо 1: {ring1?.Name ?? "Не экипировано"}");
            Console.WriteLine($"Кольцо 2: {ring2?.Name ?? "Не экипировано"}");
            Console.WriteLine($"Ожерелье: {necklace?.Name ?? "Не экипировано"}");

            Console.WriteLine("\n        БОНУСЫ", Console.ForegroundColor = ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Защита: {GetArmorPoints()}");
            Console.WriteLine($"Бонус к урону: {GetTotalBonusDamage()}");
            Console.WriteLine($"Бонус к силе: {GetTotalBonusStrength()}");
            Console.WriteLine($"Бонус к интеллекту: {GetTotalBonusIntelligence()}");
        }
    }
}

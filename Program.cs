using System;
using System.Collections.Generic;
using System.Linq;
namespace KursovProekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Item weapon1 = new Item("sword", 1, 0);            
            Item weapon2 = new Item("sparky", 8, 0);
            Item weapon3 = new Item("firebow", 5, 10);
            Item weapon4 = new Item("rocket", 10, 8);
            Item weapon5 = new Item("zap", 4, 3);

            Item armor1 = new Item("boots", 4, 1);
            Item armor2 = new Item("leggings", 9, 5);
            Item armor3 = new Item("chestplate", 10 ,9);
            Item armor4 = new Item("helmet", 7, 6);

            Hero jivko = new ("jivko1", Fraction.Rogue);
            jivko.LevelUp();
            jivko.LevelUp();
            jivko.LevelUp();
            jivko.LevelUp();

            jivko.ItemSet.Add(weapon5);
            jivko.ItemSet.Add(armor1);
            jivko.ItemSet.Add(armor2);
            jivko.ItemSet.Add(armor3);
            jivko.ItemSet.Add(armor4);

            Hero paco = new ("pacopaco", Fraction.Knight);
            paco.LevelUp();
            paco.LevelUp();

            paco.ItemSet.Add(weapon1);
            paco.ItemSet.Add(armor1);
            paco.ItemSet.Add(armor2);
            paco.ItemSet.Add(armor3);
            paco.ItemSet.Add(armor4);

            Hero genadi = new("genadi", Fraction.Priest);
            genadi.LevelUp();
            genadi.LevelUp();
            genadi.LevelUp();

            genadi.ItemSet.Add(weapon3);
            genadi.ItemSet.Add(armor1);
            genadi.ItemSet.Add(armor2);
            genadi.ItemSet.Add(armor3);
            genadi.ItemSet.Add(armor4);

            Console.WriteLine($"\tPlayer1\nLevel: {jivko.Level}\nHero name: {jivko.Name}\nHealth: {jivko.Health}\nMana: {jivko.Mana}\nStamina: {jivko.Stamina}\nFraction: {jivko.Fraction}\nDamage: {jivko.GetAttack()}\nDefence: {jivko.GetDeffence()}");
            Console.WriteLine();
            Console.WriteLine($"\tPlayer2\nLevel: {paco.Level}\nHero name: {paco.Name}\nHealth: {paco.Health}\nMana: {paco.Mana}\nStamina: {paco.Stamina}\nFraction: {paco.Fraction}\nDamage: {paco.GetAttack()}\nDefence: {paco.GetDeffence()}");
            Console.WriteLine();
            Console.WriteLine($"\tPlayer3\nLevel: {genadi.Level}\nHero name: {genadi.Name}\nHealth: {genadi.Health}\nMana: {genadi.Mana}\nStamina: {genadi.Stamina}\nFraction: {genadi.Fraction}\nDamage: {genadi.GetAttack()}\nDefence: {genadi.GetDeffence()}");

        }
    }


    public enum Fraction
    {
        Mage,
        Knight,
        Priest,
        Ranged,
        Rogue
    }



    public class Hero
    {
        private double attackCoef = 15;
        private double defenceCoef = 20;


        public string Name { get; set; }
        public Fraction Fraction { get; set; }
        public int Level { get; private set; }
        public double Health { get; private set; }
        public double Stamina { get; private set; }
        public double Mana { get; private set; }


        public List<Item> ItemSet { get; }

        public Hero(string Name, Fraction fraction)
        {
            Level = 0;
            Health = 100;
            Stamina = 100;
            Mana = 100;
            ItemSet = new List<Item>();
            this.Name = Name;
            Fraction = fraction;
        }

        public double LevelUp()
        {
            Level += 1;
            Health = 100;
            Stamina = 100;
            Mana = 100;
            return Level;

        }
        public double GetAttack()
        {
            double getAttack = ItemSet.Sum(i => i.Attack) + (Level * attackCoef);
            return getAttack;
        }
        public double GetDeffence()
        {
            double getDefence = ItemSet.Sum(i => i.Defence) + (Level * defenceCoef);
            return getDefence;
        }
    }



    public class Item
    {
        public string Name { get; private set; }
        public double Attack { get; private set; }
        public double Defence { get; private set; }
        public Item(string name, double attack, double defence)
        {
            Name = name;
            Attack = attack;
            Defence = defence;
            if (attack < 0 || attack > 10 || defence < 0 || defence > 10)
            {

                Console.WriteLine("Invalid Attack / Defence item value");
            }
        }

        public void UpgradeAttack(double attack)
        {
            Attack += attack;
            if (attack > 50 || attack < 0)
            {
                Console.WriteLine("Invalid Attack improvement value.");
            }
        }

        public void UpgradeDefence(double defence)
        {
            Defence += defence;
            if (defence < 0 || defence > 50)
            {
                Console.WriteLine("Invalid Defence improvement value.");
            }
        }
    }
}

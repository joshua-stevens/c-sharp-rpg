using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgV1
{
    class Program
    {
        public static Random r1;

        public static int getInt()
        {
            int n1 = 0;
            String input = "";
            Console.WriteLine("Please enter an integer: ");
            input = Console.ReadLine();
            n1 = Convert.ToInt32(input);
            return n1;
        }

        public static String getString()
        {
            String s1 = "";
            String input = "";
            Console.WriteLine("Please enter a word: ");
            input = Console.ReadLine();
            s1 = Convert.ToString(input);
            return s1;
        }
       
        public static void defeat()
        {
            int choice = 0;

            Console.WriteLine("You have been defeated!");
            Console.WriteLine("Press 1 if you would like to try again.");
            Console.WriteLine("Press 2 if you would like to quit");
            choice = getInt();

            while(choice != 1 && choice != 2)
            {
                Console.WriteLine("Error. Invalid Choice. Please enter 1 or 2.");
                choice = getInt();
            }

            if (choice == 1)
            {
                Console.Clear();
                startRPG();
            }
            if(choice == 2)
            {
                System.Environment.Exit(0);
            }
        }

        public static void levelUpOne(Hero h1, int health, int attack, int level)
        {
            h1.health = health;
            h1.attack = attack;
            h1.level = level;
            h1.health += 15;
            h1.attack += 5;
            h1.level += 1;

            Console.WriteLine("You have leveled up! Here are your new stats!");
            Console.WriteLine(h1);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static void levelUpTwo(Hero h1, int health, int attack, int level)
        {
            h1.health = health;
            h1.attack = attack;
            h1.level = level;
            h1.health += 20;
            h1.attack += 10;
            h1.level += 1;

            Console.WriteLine("You have leveled up! Here are your new stats!");
            Console.WriteLine(h1);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static void usePotion(Hero h1)
        {
            h1.health += 10;
            h1.potions -= 1;
            Console.WriteLine("You used a potion!");
            Console.WriteLine("It restored 10 health!");
            Console.WriteLine("Your health is now: " + h1.health);
            Console.WriteLine("You have " + h1.potions + " potions left!");
        }

        public static void rouletteAttack(Hero h1, Thief t1)
        {
            int num = 0;
            int guess = 0;
            int tries = 3;
            int damage = 0;
            bool correct = false;

            while (tries > 0 && correct == false)
            {
                Console.WriteLine("You have " + tries + " guess(es)!");
                Console.WriteLine("Guess a number between 1 and 5.");
                num = r1.Next(1, 6);
                guess = getInt();
                while (guess < 1 || guess > 5)
                {
                    Console.WriteLine("You've entered an invaled number! Please try again!");
                    guess = getInt();
                }
                if (guess == num)
                {
                    damage = h1.attack * 2;
                    Console.WriteLine("Congratulations you guessed correctly!");
                    Console.WriteLine("You have done " + damage + " damage!");
                    t1.health -= h1.attack * 2;
                    correct = true;
                }
                else
                {
                    tries--;
                    Console.WriteLine("Sorry you guessed incorrectly! Try again!");
                }
            }
            if (correct == false)
            {
                damage = 1;
                t1.health -= 1;
                Console.WriteLine("Sorry you are out of guesses!");
                Console.WriteLine("You have done 1 damage.");
                Console.WriteLine("The enemy has " + t1.health + " left.");

            }
        }

        public static void rouletteAttackBoss(Hero h1, Boss b1)
        {
            int num = 0;
            int guess = 0;
            int tries = 3;
            int damage = 0;
            bool correct = false;

            while (tries > 0 && correct == false)
            {
                Console.WriteLine("You have " + tries + " guess(es)!");
                Console.WriteLine("Guess a number between 1 and 5.");
                num = r1.Next(1, 6);
                guess = getInt();
                while(guess < 1 || guess > 5)
                {
                    Console.WriteLine("You've entered an invaled number! Please try again!");
                    guess = getInt();
                }

                if (guess == num)
                {
                    damage = h1.attack * 2;
                    Console.WriteLine("Congratulations you guessed correctly!");
                    Console.WriteLine("You have done " + damage + " damage!");
                    b1.health -= h1.attack * 2;
                    correct = true;
                }
                else
                {
                    
                    tries--;
                    Console.WriteLine("Sorry you guessed incorrectly! Try again!");
                    Console.WriteLine("You have " + tries + " tries left!");
                }               
            }
            if (correct == false)
            {
                damage = 1;
                b1.health -= 1;
                Console.WriteLine("Sorry you are out of guesses!");
                Console.WriteLine("You have done 1 damage.");
                Console.WriteLine("The enemy has " + b1.health + " left.");

            }
        }

        public static void playerBossBattlePhase(Hero h1, Boss b1)
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("You have three actions you can choose from.");
            Console.WriteLine("The fist option attack will deal the same amount of damage as your attack stat.");
            Console.WriteLine("The second option Roulette Attack is a risk vs. reward attack.");
            Console.WriteLine("You will have 3 chances to guess a number between 1 and 5. If you guess correctly you will do double damage.");
            Console.WriteLine("However if you guess wrong all three times you will only do 1 damage!");
            Console.WriteLine("The last option is to use a potion to heal yourself for 10 health but be careful! You only get 3 for the whole game!");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            int action = 0;
            Console.WriteLine("Select your action!");
            Console.WriteLine("1: Attack");
            Console.WriteLine("2: Roulette Attack");
            Console.WriteLine("3: Use Potion");
            action = getInt();
            while ((action < 1) || (action > 3))
            {
                Console.WriteLine("You've entered an invalid choice. Please enter 1, 2, or 3.");
                action = getInt();
            }
            while (action == 3 && h1.potions == 0)
            {


                Console.WriteLine("Sorry! You are out of potions! Please choose a different action.");
                action = getInt();


            }

            switch (action)
            {
                case 1:
                    b1.attacked(h1);
                    Console.WriteLine("You attacked the enemey for " + h1.attack + " damage!");
                    Console.WriteLine("He now has " + b1.health + " left!");
                    Console.WriteLine("Enter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    rouletteAttackBoss(h1, b1);
                    Console.WriteLine("Enter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    usePotion(h1);
                    Console.WriteLine("Enter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Error in battle phase.");
                    break;
            }
        }
        
        public static void bossBattlePhase(Hero h1, Boss b1)
        {
            int criticalHit = 0;
            int damage = 0;
            criticalHit = r1.Next(1, 60);

            if (criticalHit < 21)
            {
                h1.health -= b1.attack + 7;
                damage = b1.attack + 7;
                Console.WriteLine("The enemy landed a critical hit!");
                Console.WriteLine("You've taken " + damage + " damage!");
                Console.WriteLine("You now have " + h1.health + " health left!");
            }
            else
            {
                h1.health -= b1.attack;
                damage = b1.attack;
                Console.WriteLine("The enemy landed a normal hit!");
                Console.WriteLine("You've taken " + damage + " damage!");
                Console.WriteLine("You now have " + h1.health + " health left!");
            }
            Console.WriteLine("Enter any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void bossBattle(Hero h1, Boss b1)
        {
            Console.WriteLine("Boss Fight!!!!");
            Console.WriteLine("The leader of Biggs and Wedge approaches!!");
            Console.WriteLine("His name is " + b1.name + " and he is ready for battle!!");
            Console.WriteLine(b1);

            while ((h1.health > 0) && (b1.health > 0))
            {
                if (h1.health > 0)
                {
                    playerBossBattlePhase(h1, b1);
                }
                if (b1.health > 0)
                {
                    bossBattlePhase(h1, b1);
                }
            }
            if (h1.health <= 0)
            {
                defeat();
            }
            else if (b1.health <= 0)
            {
                Console.WriteLine("Congratulations!! You won!!");
            }
            else
            {
                Console.WriteLine("Error in boss battle.");
            }
            Console.WriteLine("Press enter to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void playerBattlePhase(Hero h1, Thief t1)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("You have three actions you can choose from.");
            Console.WriteLine("The fist option attack will deal the same amount of damage as your attack stat.");
            Console.WriteLine("The second option Roulette Attack is a risk vs. reward attack.");
            Console.WriteLine("You will have 3 chances to guess a number between 1 and 5. If you guess correctly you will do double damage.");
            Console.WriteLine("However if you guess wrong all three times you will only do 1 damage!");
            Console.WriteLine("The last option is to use a potion to heal yourself for 10 health but be careful! You only get 3 for the whole game!");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            int action = 0;
            Console.WriteLine("Select your action!");
            Console.WriteLine("1: Attack");
            Console.WriteLine("2: Roulette Attack");
            Console.WriteLine("3: Use Potion");
            action = getInt();
            while((action < 1) || (action > 3))
            {
                Console.WriteLine("You've entered an invalid choice. Please enter 1, 2, or 3.");
                action = getInt(); 
            }
            while(action == 3 && h1.potions == 0)
            {
               
                
                    Console.WriteLine("Sorry! You are out of potions! Please choose a different action.");
                    action = getInt();
                

            }
            switch (action)
            {
                case 1:
                    t1.attacked(h1);
                    Console.WriteLine("You attacked for " + h1.attack + " damage!");
                    Console.WriteLine("The enemy has " + t1.health + " left!");
                    Console.WriteLine("Enter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    rouletteAttack(h1, t1);
                    Console.WriteLine("Enter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    usePotion(h1);
                    Console.WriteLine("Enter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Error in battle phase.");
                    break;
            }
        }

        public static void enemyBattlePhase(Hero h1, Thief t1)
        {    
            int criticalHit = 0;
            int damage = 0;
            criticalHit = r1.Next(1, 100);

            if(criticalHit < 21 )
            {
                h1.health -= t1.attack + 5;
                damage = t1.attack + 5;
                Console.WriteLine("The enemy landed a critical hit!");
                Console.WriteLine("You've taken " + damage + " damage!");
                Console.WriteLine("You now have " + h1.health + " health left!");
            }
            else
            {
                h1.health -= t1.attack;
                damage = t1.attack;
                Console.WriteLine("The enemy landed a normal hit!");
                Console.WriteLine("You've taken " + damage + " damage!");
                Console.WriteLine("You now have " + h1.health + " health left!");
            }
            Console.WriteLine("Enter any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
        
        public static void fightThief(Hero h1, Thief t1)
        {
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("An enemy approaches!!!!");
            Console.WriteLine("A thief named " + t1.name + " has challenged you to a fight!!!");
            Console.WriteLine(t1);
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
         
            while ((h1.health > 0)&&(t1.health > 0))
            {
                if(h1.health > 0)
                {
                    playerBattlePhase(h1, t1);
                }
                if(t1.health > 0)
                {
                    enemyBattlePhase(h1, t1);
                }  
            }
            if(h1.health <= 0)
            {
                defeat();
            }
            else if (t1.health <= 0)
            {
                Console.WriteLine("Congratulations!! You won!!");
            }
            else
            {
                Console.WriteLine("Error in thief fight.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void intro(Hero h1)
        {
            string name = "";

            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Welcome to My RPG Version 1!");
            Console.WriteLine("You will fight 3 enemies!");
            Console.WriteLine("You will have multiple actions you can select to fight your enemies!");
            Console.WriteLine("Read the instructions as the come up and most importantly have fun!");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Name you hero!");
            name = getString();  
            h1.name = name;
            Console.WriteLine("Here are your stats!");
            Console.WriteLine(h1);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void startRPG()
        {
            Hero h1 = new Hero();
            Thief t1 = new Thief();
            t1.name = "Biggs";
            Thief t2 = new Thief();
            t2.name = "Wedge";
            t2.attack += 4;
            t2.health += 30;     
            Boss b1 = new Boss();
            int health = 0;
            int attack = 0;
            int level = 0;
       
            health = h1.health;
            attack = h1.attack;
            level = h1.level;
           
            intro(h1);
            fightThief(h1, t1);
            levelUpOne(h1, health, attack, level);
            health = h1.health;
            attack = h1.attack;
            level = h1.level;
            fightThief(h1, t2);
            levelUpTwo(h1, health, attack, level);
            bossBattle(h1, b1);
        }

        static void Main(string[] args)
        {
            r1 = new Random();
            startRPG();
        }
    }
}

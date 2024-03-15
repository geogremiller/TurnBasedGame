using System;

namespace TurnBasedGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            bool playAgain;

            do
            {
                int playerHP = 40;
                int enemyHP = 40;

                int playerAttack = 5;
                int enemyAttack = 7;

                int healAmount = 5;

                while (playerHP > 0 && enemyHP > 0)
                {
                    Console.WriteLine("<--Player's turn-->");
                    Console.WriteLine("Player HP - " + playerHP + ". Enemy HP - " + enemyHP);
                    Console.WriteLine("Enter 'a' to attack or 'h' to heal.");
                    Console.WriteLine("-------------------------------------------");

                    string choice = Console.ReadLine();

                    if (choice == "a")
                    {
                        Console.WriteLine("-------------------------------------------");
                        enemyHP -= playerAttack;
                        Console.WriteLine("Player attacks enemy and deals " + playerAttack + " damage");
                    }
                    else if (choice == "h")
                    {
                        playerHP += healAmount;
                        Console.WriteLine("Player restores " + healAmount + " HP");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice! Please enter 'a' to attack or 'h' to heal.");
                        continue; // Skip enemy's turn if invalid choice
                    }

                    if (enemyHP > 0)
                    {
                        Console.WriteLine("<--Enemy's turn-->");
                        int enemyChoice = rand.Next(0, 2);

                        if (enemyChoice == 0)
                        {
                            playerHP -= enemyAttack;
                            Console.WriteLine("Enemy attacks and deals " + enemyAttack + " damage");
                        }
                        else
                        {
                            enemyHP += healAmount;
                            Console.WriteLine("Enemy restores " + healAmount + " HP");
                        }
                    }
                }

                if (playerHP > 0)
                {
                    Console.WriteLine("Congratulations! Player has won the game!");
                }
                else
                {
                    Console.WriteLine("You lose!");
                }

                Console.WriteLine("Do you want to play again? (yes/no)");
                string playAgainInput = Console.ReadLine().Trim().ToLower();
                playAgain = (playAgainInput == "yes");

            } while (playAgain);

            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
        }
    }
}

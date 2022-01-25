using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery
{
    class End_Game
    {
        public void Game_Win()
        {
            Console.WriteLine("You exited with the bank with ${0}.", Inventory_Manage.player_cash);
            Console.WriteLine("You also left with...");
            Console.WriteLine(" ");
            for (int i = 0; i < Inventory_Manage.Player_Inventory.Count; i++)
            {
                Console.WriteLine("- {0} ({1})", Inventory_Manage.Player_Inventory[i], Inventory_Manage.Item_Descriptions[i]);
            }
            Console.WriteLine("Press enter to exit the game.");
            Console.ReadLine();
            Environment.Exit(0);
        }

        public void Game_Lose()
        {
            Console.WriteLine("You Lose.");
            Console.WriteLine("You lost in {0}.", Global_Variables.current_room);
            Console.WriteLine("Press enter to exit the game.");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}

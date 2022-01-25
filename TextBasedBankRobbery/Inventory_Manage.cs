using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery
{
    class Inventory_Manage
    {
        //Declares all of the inventory related variables to be used throughout the program as well as the inventory lists.
        public static float added_cash = 0.00f;
        public static string new_item = " ";
        public static string item_desc = " ";
        public static float player_cash;
        public static List<string> Player_Inventory = new List<string>();
        public static List<string> Item_Descriptions = new List<string>();
        Global_Variables stand = new Global_Variables();

        public void Item_Add()
        {
            //Adds a new item to the player's inventory as well as telling them.
            Console.WriteLine("\n!!-------------------------------------------------------------------------------------------------------------------!!");
            Player_Inventory.Add(new_item);
            Item_Descriptions.Add(item_desc);
            Console.WriteLine("{0} was added to your inventory", new_item);
            Console.WriteLine("!!-------------------------------------------------------------------------------------------------------------------!!\n");
        }
        public void Money_Add()
        {
            //Adds money to the player's inventory as well as telling them.
            Console.WriteLine("\n!!-------------------------------------------------------------------------------------------------------------------!!");
            player_cash = player_cash + added_cash;
            Console.WriteLine("${0} was added to your inventory", added_cash);
            Console.WriteLine("!!-------------------------------------------------------------------------------------------------------------------!!\n");
        }
        public void Inventory_List()
        {
            //Lists every item in the player's inventory as well as it's description.
            Console.Clear();
            Console.WriteLine("==-------------------------------------------------------------------------------------------------------------------==");
            Console.WriteLine("Your inventory contains:\n\nMoney: ${1}\nCombat Power: {0}\nItems:", Global_Variables.combat_power, player_cash);
            if (Player_Inventory.Count < 1)
            {
                Console.WriteLine("None");
            }
            else
            {
                for (int i = 0; i < Player_Inventory.Count; i++)
                {
                    Console.WriteLine("- {0} ({1})", Player_Inventory[i], Item_Descriptions[i]);
                }
            }
            Console.WriteLine("==-------------------------------------------------------------------------------------------------------------------==");
            Console.WriteLine("Press enter to continue:");
            Console.ReadLine();

        }
    }
}

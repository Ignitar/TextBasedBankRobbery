using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery.Rooms
{
    class Bank_Vault
    {
        //Declares all of the external classes which will need to be used within this class.
        Global_Variables stand = new Global_Variables();
        Room_Travels travel = new Room_Travels();
        Inventory_Manage inventory = new Inventory_Manage();

        public void Vault_Description()
        {
            //Prints the current description of the room as well as the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: The Vault");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The vault is full of valueables, gold, jewlerey, bundles of cash and all sorts.");
            Console.WriteLine("- It would be impossible to carry all of this back on your own.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            Console.WriteLine("(2) - Back Corridor");
            if (Inventory_Manage.Player_Inventory.Contains("Gold Bar") == false)
            {
                Console.WriteLine("(3) - Loot Vault");
            }
            else
            {
                Console.WriteLine("(3) - Loot Vault [LOOTED]");
            }
            Vault_Choice();   
        }

        public void Vault_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                inventory.Inventory_List();
                Vault_Description();
            }
            else if (stand.player_input.ToUpper() == "BACK CORRIDOR" || stand.player_input == "2")
            {
                travel.Corridor2_Travel();
            }
            else if (stand.player_input.ToUpper() == "LOOT" || stand.player_input == "3")
            {
                if (Inventory_Manage.Player_Inventory.Contains("Gold Bar") == false)
                {
                    Console.WriteLine("You take the most valueable items in the vault.");
                    Inventory_Manage.new_item = "Gold Bar";
                    Inventory_Manage.item_desc = "Valued at $2500";
                    inventory.Item_Add();
                    inventory.Item_Add();
                    Inventory_Manage.new_item = "Jeweled Knife";
                    Inventory_Manage.item_desc = "+4 Combat Power";
                    Global_Variables.combat_power = Global_Variables.combat_power + 4;
                    inventory.Item_Add();
                    Vault_Choice();
                }
                else
                {
                    Console.WriteLine("You have already looted the vault as much as you can.");
                    Vault_Choice();
                }
                        
            }
            else
            {
                Console.WriteLine("You did not enter one of the choices.");
                Vault_Choice();
            }
        }
    }
}

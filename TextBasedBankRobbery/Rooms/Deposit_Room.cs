using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery.Rooms
{
    class Deposit_Room
    {
        //Declares all of the external classes which will need to be used within this class.
        Global_Variables stand = new Global_Variables();
        Room_Travels travel = new Room_Travels();
        Inventory_Manage inventory = new Inventory_Manage();

        public void Deposit_Description()
        {
            //Prints the current description of the room as well as the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Deposit Room");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The deposit room is filled with deposit boxes, each one being locked.");
            Console.WriteLine("- It would take too long to pick lock all of them.");
            if (Global_Variables.know_deposit == false)
            {
                Console.WriteLine("- Maybe theres a way for you to find out which ones are worth picking.\n");
            }
            else
            {
                Console.WriteLine("- You remember the guard said that deposit box 544 had valubles worth while in.\n");
            }
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            Console.WriteLine("(2) - Back Corridor");
            if (Inventory_Manage.Player_Inventory.Contains("Gem Necklace") == false)
            {
                Console.WriteLine("(3) - Loot Room");
            }
            else
            {
                Console.WriteLine("(3) - Loot Room [LOOTED[");
            }
            Deposit_Choice();
        }

        public void Deposit_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                inventory.Inventory_List();
                Deposit_Description();
            }
            else if (stand.player_input.ToUpper() == "BACK CORRIDOR" || stand.player_input == "2")
            {
                travel.Corridor2_Travel();
            }
            else if (stand.player_input.ToUpper() == "LOOT" || stand.player_input == "3")
            {
                if (Inventory_Manage.Player_Inventory.Contains("Gem Necklace") == false)
                {
                    if (Global_Variables.know_deposit == true)
                    {
                        Console.WriteLine("You go to deposit box 544 and lock pick it open.");
                        Console.WriteLine("You find a large amount of money and a valueable necklace.");
                        Inventory_Manage.added_cash = 450.00f;
                        inventory.Money_Add();
                        Inventory_Manage.new_item = "Gem Necklace";
                        Inventory_Manage.item_desc = "Valued at $1000";
                        inventory.Item_Add();
                        Console.WriteLine("Press enter to continue:");
                        Console.ReadLine();
                        Deposit_Description();
                    }
                    else
                    {
                        Console.WriteLine("You only have one lock pick and there are hundreds of boxes.");
                        Console.WriteLine("You decide not to risk it.");
                        Console.WriteLine("Press enter to continue:");
                        Console.ReadLine();
                        Deposit_Description();
                    }
                }
                else
                {
                    Console.WriteLine("You have looted what you can.");
                    Console.WriteLine("Press enter to continue:");
                    Console.ReadLine();
                    Deposit_Description();
                }
            }
            else
            {
                Console.WriteLine("You did not enter one of the choices.");
                Console.WriteLine("\nPlease enter a different option:");
                Deposit_Choice();
            }
        }
    }
}

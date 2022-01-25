using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery.Rooms
{
    class Staff_Room
    {
        //Declares all of the external classes which will need to be used within this class.
        Global_Variables stand = new Global_Variables();
        Room_Travels travel = new Room_Travels();
        Inventory_Manage inventory = new Inventory_Manage();
        End_Game end = new End_Game();

        public void Staff_Description()
        {
            //Prints the current description of the room as well as the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Staff Room");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The staff room has a very homley fill, with a box of biscuits in the middle of the table for anyone.");
            Console.WriteLine("- There is a row of clothes pegs at the back of the room, bearly being used other than a couple of coats.");
            Console.WriteLine("- There are 3 young staff members all of their phones, they are too pre ocupied to notice you.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            Console.WriteLine("(2) - Front Corridor");
            if (Inventory_Manage.Player_Inventory.Contains("Vault Key") == false)
            {
                Console.WriteLine("(3) - Loot Room");
            }
            else
            {
                Console.WriteLine("(3) - Loot Room [LOOTED]");
            }
            Staff_Choice();
        }

        public void Staff_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                inventory.Inventory_List();
                Staff_Description();
            }
            else if (stand.player_input.ToUpper() == "FRONT CORRIDOR" || stand.player_input == "2")
            {
                travel.Corridor1_Travel();
            }
            else if (stand.player_input.ToUpper() == "LOOT" || stand.player_input == "3")
            {
                if (Inventory_Manage.Player_Inventory.Contains("Vault Key") == false)
                {
                    Console.WriteLine("You walk over to the end of the table quietley to not disturb the staff.");
                    Console.WriteLine("You found a very important key just tossed to the side with no care.");
                    Inventory_Manage.new_item = "Vault Key";
                    Inventory_Manage.item_desc = "Grants access to the bank's vault";
                    inventory.Item_Add();
                    Staff_Choice();
                }
                else
                {
                    Console.WriteLine("You have looted all you can without disturbing the staff.");
                    Staff_Choice();
                }
            }
            else
            {
                Console.WriteLine("Please enter one of the choices.");
                Staff_Choice();
            }
        }
    }
}
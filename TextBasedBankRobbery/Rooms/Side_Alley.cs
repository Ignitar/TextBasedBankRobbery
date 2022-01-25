using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery.Rooms
{
    class Side_Alley
    {
        //Declares all of the external classes which will need to be used within this class.
        Global_Variables stand = new Global_Variables();
        Room_Travels travel = new Room_Travels();
        Inventory_Manage inventory = new Inventory_Manage();

        public void Alley_Description()
        {
            //Prints the current description of the room as well as the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Side Alley");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The alley is littered with boxes, most likley filled with junk.");
            Console.WriteLine("- The smell is unbearable, but nothing in sight should be making such an horrible musk.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            Console.WriteLine("(2) - Bank Outside");
            Console.WriteLine("(3) - Back Entrance");
            if (Inventory_Manage.Player_Inventory.Contains("Screwdriver") == false)
            {
                Console.WriteLine("(4) - Loot Alley");
            }
            else
            {
                Console.WriteLine("(4) - Loot Alley [LOOTED]");
            }
            Alley_Choice();
        }

        public void Alley_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                //Displays the players inventory.
                inventory.Inventory_List();
                Alley_Description();
            }
            else if (stand.player_input.ToUpper() == "BANK OUTSIDE" || stand.player_input == "2")
            {
                //Sends the player to the bank outside.
                travel.Outside_Travel();
            }
            else if (stand.player_input.ToUpper() == "BACK ENTRANCE" || stand.player_input == "3")
            {
                //Sends the player to the back entrance.
                travel.Back_Travel();
            }
            else if (stand.player_input.ToUpper() == "LOOT" || stand.player_input == "4")
            {
                //Checks if the player has obtained a screwdriver which is recieved from looting the alley, therefore checking if the alley has already been looted or not.
                if (Inventory_Manage.Player_Inventory.Contains("Screwdriver") == false)
                {
                    Console.WriteLine("- You rummaged through the trash bags and found a rusty screwdriver.");
                    Inventory_Manage.new_item = "Screwdriver";
                    Inventory_Manage.item_desc = "+ 3 CP";
                    inventory.Item_Add();
                    Global_Variables.combat_power = Global_Variables.combat_power + 3;
                    Console.WriteLine("Press enter to continue:");
                    Console.ReadLine();
                    Console.Clear();
                    Alley_Description();
                }
                else
                {
                    Console.WriteLine("!- You have already looted the alley.");
                    Console.WriteLine("\nPlease enter another choice:");
                    Alley_Choice();
                }
            }
            else
            {
                //Error handling for it the player enters an invalid choice.
                Console.WriteLine("!- You did not enter a valid choice.");
                Console.WriteLine("\nPlease enter another choice:");
                Alley_Choice();
            }
        }
    }
}

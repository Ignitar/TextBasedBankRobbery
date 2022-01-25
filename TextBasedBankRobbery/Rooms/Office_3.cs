using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery.Rooms
{
    class Office_3
    {
        //Declares all of the external classes which will need to be used within this class.
        Global_Variables stand = new Global_Variables();
        Room_Travels travel = new Room_Travels();
        Inventory_Manage inventory = new Inventory_Manage();

        public void Office3_Description()
        {
            //Prints the current description of the room as well as the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Office C");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The office looks like it was abandoned after a busy meeting with lots of random objects and paper scattered across the table.");
            Console.WriteLine("- Random loose pieces of paper also lie on the floor, none of which containing anything of use.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            Console.WriteLine("(2) - Front Lobby");
            if (Inventory_Manage.Player_Inventory.Contains("Corridor Key") == false)
            {
                Console.WriteLine("(3) - Round table");
            }
            else
            {
                Console.WriteLine("(3) - Round Table (Looted)");
            }
            Office3_Choice();
        }

        public void Office3_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                //Displays the player's inventory.
                inventory.Inventory_List();
                Office3_Description();
            }
            else if (stand.player_input.ToUpper() == "FRONT LOBBY" || stand.player_input == "2")
            {
                //Sends the player to the front lobby.
                travel.Lobby_Travel();
            }
            else if (stand.player_input.ToUpper() == "TABLE" || stand.player_input == "3")
            {
                //Calls the table method for the user to then interact with the table.
                Table_Description();
            }
            else
            {
                //Error handling for if the player doesn't enter a valid choice.
                Console.WriteLine("You did not enter a valid choice.");
                Console.WriteLine("\nPlease enter another choice:");
                Office3_Choice();
            }
        }
        public void Table_Description()
        {
            //Displays information about the table and the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Office C");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The table is a mess of everything.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inspect Table");
            if (Inventory_Manage.Player_Inventory.Contains("Lobby Key") == false)
            {
                Console.WriteLine("(2) - Loot Table Top");
            }
            else
            {
                Console.WriteLine("(2) - Loot Table Top [LOOTED]");
            }
            Console.WriteLine("(3) - Back");
            Table_Choice();
        }
        public void Table_Choice()
        {
            stand.player_input = Console.ReadLine();
            //Displays more information about the table.
            if (stand.player_input.ToUpper() == "INSPECT" || stand.player_input == "1")
            {
                Console.WriteLine("- The table has a mess of papers and random objects.");
                Console.WriteLine("Press enter to continue:");
                Console.ReadLine();
                Table_Description();
            }
            else if (stand.player_input.ToUpper() == "LOOT" || stand.player_input == "2")
            {
                //Checks if the player has obtained the lobby key, which they get from looting the table, checking if it has been looted or not.
                if (Inventory_Manage.Player_Inventory.Contains("Lobby Key") == false)
                {
                    Console.WriteLine("- You scan the table top and notice a key resting amongst the unorganised mess.");
                    Inventory_Manage.new_item = "Lobby Key";
                    Inventory_Manage.item_desc = "Grants access to the Bank Corridor and Front Lobby";
                    inventory.Item_Add();
                    Console.WriteLine("Press enter to continue:");
                    Console.ReadLine();
                    Table_Description();
                }
                else
                {
                    Console.WriteLine("!- You have already looted the table.");
                    Console.WriteLine("\nPlease enter another choice:");
                    Table_Choice();
                }
            }
            else if (stand.player_input.ToUpper() == "BACK" || stand.player_input == "3")
            {
                //Sends the player back to the overall office description.
                Office3_Description();
            }
            else
            {
                //Error handling for if the player does not enter a valid choice.
                Console.WriteLine("You did not enter a valid choice.");
                Console.WriteLine("\nPlease enter another choice:");
                Table_Choice();
            }
        }
    }
}

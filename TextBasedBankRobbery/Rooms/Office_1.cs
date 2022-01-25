using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery.Rooms
{
    class Office_1
    {
        //Declares all of the external classes which will need to be used within this class.
        Global_Variables stand = new Global_Variables();
        Room_Travels travel = new Room_Travels();
        Inventory_Manage inventory = new Inventory_Manage();

        public void Office1_Description()
        {
            //Prints the current description of the room as well as the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Office A");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The office is very well kept with many filing cabinets stored at the back.");
            Console.WriteLine("- The table has nothing on it and looks as if it hasn't been used in days.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            Console.WriteLine("(2) - Front Lobby");
            Office1_Choice();
        }

        public void Office1_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                inventory.Inventory_List();
                Office1_Description();
            }
            else if (stand.player_input.ToUpper() == "FRONT LOBBY" || stand.player_input == "2")
            {
                travel.Lobby_Travel();
            }
            else
            {
                Console.WriteLine("You did not enter a valid choice.");
                Console.WriteLine("\nPlease enter a different choice:");
                Office1_Choice();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery.Rooms
{
    class Front_Entrance
    {
        //Declares all of the external classes which will need to be used within this class.
        Global_Variables stand = new Global_Variables();
        Room_Travels travel = new Room_Travels();
        Inventory_Manage inventory = new Inventory_Manage();

        public void Front_Description()
        {
            //Prints the current description of the room as well as the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Front Entrance");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The front entrance is small, to be expected for an independent bank.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            Console.WriteLine("(2) - Bank Outside");
            Console.WriteLine("(3) - Front Lobby");
            Front_Choice();
        }

        public void Front_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                //Displays the player's inventory.
                inventory.Inventory_List();
                Front_Description();
            }
            else if (stand.player_input.ToUpper() == "BANK OUTSIDE" || stand.player_input == "2")
            {
                //Sends the player to the bank outside.
                travel.Outside_Travel();
            }
            else if (stand.player_input.ToUpper() == "FRONT LOBBY" || stand.player_input == "3")
            {
                //Sends the player to the front lobby.
                travel.Lobby_Travel();
            }
            else
            {
                //Error handling if the player did not enter a valid choice.
                Console.WriteLine("!- You did not enter a valid choice.");
                Console.WriteLine("\nPlease enter another choice:");
                Front_Choice();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery.Rooms
{
    class Back_Corridor1
    {
        //Declares all of the external classes which will need to be used within this class.
        Global_Variables stand = new Global_Variables();
        Room_Travels travel = new Room_Travels();
        Inventory_Manage inventory = new Inventory_Manage();

        public void Corridor1_Description()
        {
            //Prints the current description of the room as well as the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Corridor");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The corridor is empty, following fire saftey guidelines.");
            Console.WriteLine("- There is the rest of the corridor up ahead, as well as the entrance to the front desk and staff room.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            Console.WriteLine("(2) - Back Corridor");
            if (Inventory_Manage.Player_Inventory.Contains("Lobby Key") == false)
            {
                Console.WriteLine("(3) - Front Lobby [LOCKED]");
            }
            else
            {
                Console.WriteLine("(3) - Front Lobby");
            }
            Console.WriteLine("(4) - Front Desk");
            Console.WriteLine("(5) - Staff Room");
            Corridor1_Choice();
        }

        public void Corridor1_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                inventory.Inventory_List();
                Corridor1_Description();
            }
            else if (stand.player_input.ToUpper() == "BACK CORRIDOR" || stand.player_input == "2")
            {
                travel.Corridor2_Travel();
            }
            else if (stand.player_input.ToUpper() == "FRONT LOBBY" || stand.player_input == "3")
            {
                if (Inventory_Manage.Player_Inventory.Contains("Lobby Key") == false)
                {
                    Console.WriteLine("!- You do not have the key to go through this door yet.");
                    Console.WriteLine("\nPlease enter another choice:");
                    Corridor1_Choice();
                }
                else
                {
                    travel.Lobby_Travel();
                }
            }
            else if (stand.player_input.ToUpper() == "FRONT DESK" || stand.player_input == "4")
            {
                travel.Desk_Travel();
            }
            else if (stand.player_input.ToUpper() == "STAFF ROOM" || stand.player_input == "5")
            {
                travel.Staff_Travel();
            }
            else
            {
                Console.WriteLine("!- You did not enter one of the choices.");
                Console.WriteLine("\nPlease enter another choice:");
                Corridor1_Choice();
            }
        }
    }
}

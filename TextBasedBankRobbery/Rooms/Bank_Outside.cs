using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery.Rooms
{
    class Bank_Outside
    {
        //Declares all of the external classes which will need to be used within this class.
        Global_Variables stand = new Global_Variables();
        Room_Travels travel = new Room_Travels();
        Inventory_Manage inventory = new Inventory_Manage();
        End_Game end = new End_Game();

        public void Outside_Description()
        {
            //Prints the current description of the room as well as the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Bank Outside");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The bank stands in front of you with two ways in, the front entrance and the alleyway.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            Console.WriteLine("(2) - Front Entrance");
            Console.WriteLine("(3) - Side Alley");
            Console.WriteLine("(4) - Leave");
            Outside_Choice();
        }

        public void Outside_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                //Displays the player's inventory.
                inventory.Inventory_List();
                Outside_Description();
            }
            else if (stand.player_input.ToUpper() == "FRONT ENTRANCE" || stand.player_input == "2")
            {
                //Sends the player to the front entrance.
                travel.Front_Travel();
            }
            else if (stand.player_input.ToUpper() == "SIDE ALLEY" || stand.player_input == "3")
            {
                //Sends the player to the side alley.
                travel.Alley_Travel();
            }
            else if (stand.player_input.ToUpper() == "FLEE" || stand.player_input == "4")
            {
                //Ends the game for the player.
                end.Game_Win();
            }
            else
            {
                //Error handling if the player did not enter a valid choice.
                Console.WriteLine("!- You did not enter a valid choice.");
                Console.WriteLine("\nPlease enter another choice:");
                Outside_Choice();
            }
        }
    }
}

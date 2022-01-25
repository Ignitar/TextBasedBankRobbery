using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery.Rooms
{
    class Office_2
    {
        //Declares all of the external classes which will need to be used within this class.
        Global_Variables stand = new Global_Variables();
        Room_Travels travel = new Room_Travels();
        Inventory_Manage inventory = new Inventory_Manage();

        public void Office2_Description()
        {
            //Prints the current description of the room as well as the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Office B");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The table has some files left on top with some loose papers on it containing personal information of customers.");
            Console.WriteLine("- A wallet has also been left on the table.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            Console.WriteLine("(2) - Front Lobby");
            Console.WriteLine("(3) - Table");
            Office2_Choice();
        }

        public void Office2_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                inventory.Inventory_List();
                Office2_Description();
            }
            else if (stand.player_input.ToUpper() == "FRONT LOBBY" || stand.player_input == "2")
            {
                travel.Lobby_Travel();
            }
            else if (stand.player_input.ToUpper() == "TABLE" || stand.player_input == "3")
            {
                Table_Description();
            }
            else
            {
                Console.WriteLine("You did not enter a valid choice.");
                Console.WriteLine("\nPlease enter a different option:");
                Office2_Choice();
            }
        }

        private void Table_Description()
        {
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Office C");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The table has bits and bobs scattered in some places.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("(1) - Inventory");
            if (Inventory_Manage.Player_Inventory.Contains("Toy Gun") == false)
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
        private void Table_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                inventory.Inventory_List();
                Table_Description();
            }
            else if (stand.player_input.ToUpper() == "LOOT" || stand.player_input == "2")
            {
                if (Inventory_Manage.Player_Inventory.Contains("Toy Gun") == false)
                {
                    Console.WriteLine("You scan the top of the table and grab money out of the wallet and a Toy Gun... For saftey.");
                    Inventory_Manage.new_item = "Toy Gun";
                    Inventory_Manage.item_desc = "Seems pretty useless, maybe it could come in handy?";
                    inventory.Item_Add();
                    Inventory_Manage.added_cash = 75.00f;
                    inventory.Money_Add();
                    Table_Description();
                }
                else
                {
                    Console.WriteLine("The table has already been looted.");
                    Table_Choice();
                }
            }
            else if (stand.player_input.ToUpper() == "BACK" || stand.player_input == "3")
            {
                Office2_Description();
                Office2_Choice();
            }
            else
            {
                Console.WriteLine("Please enter one of the options.");
                Table_Choice();
            }
        }
    }
}

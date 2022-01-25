using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery.Rooms
{
    class Front_Desk
    {
        //Declares all of the external classes which will need to be used within this class.
        Global_Variables stand = new Global_Variables();
        Room_Travels travel = new Room_Travels();
        Inventory_Manage inventory = new Inventory_Manage();
        End_Game end = new End_Game();

        //Declares all of the private variables to be used within this class.
        private static bool desk_looted = false;
        private static bool staff_looted = false;

        public void Desk_Description()
        {
            //Prints the current description of the room as well as the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Front Desk");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The front desk is a small box only meant for 2 people max.");
            if (Global_Variables.desk_killed == true)
            {
                Console.WriteLine("- The body of the desk staff lies on the floor sleeping.");
                if (desk_looted == false)
                {
                    Console.WriteLine("- Small bundles of money lie neatly stacked in the room as well as a big red panic button.\n");
                    Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
                    Console.WriteLine("Please enter one of the following:");
                    Console.WriteLine("(1) - Inventory");
                    Console.WriteLine("(2) - Back Corridor");
                    Console.WriteLine("(3) - Loot Desk");
                }
                else
                {
                    Console.WriteLine("- The desk is empty apart from the limp body on the floor.\n");
                    Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
                    Console.WriteLine("Please enter one of the following:");
                    Console.WriteLine("(1) - Inventory");
                    Console.WriteLine("(2) - Back Corridor");
                    Console.WriteLine("(3) - Loot Desk [LOOTED]");
                }
                if (desk_looted == false)
                {
                    Console.WriteLine("(4) - Staff Body");
                }
                else
                {
                    Console.WriteLine("(4) - Staff Body [LOOTED]");
                }
                    
            }
            else
            {
                Console.WriteLine("!- The staff member manning the front desk presses a big red panic button before you get a chance to look around.\n");
                end.Game_Lose();
            }
            Desk_Choice();
        }

        public void Desk_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                inventory.Inventory_List();
                Desk_Description();
            }
            else if (stand.player_input.ToUpper() == "FRONT CORRIDOR" || stand.player_input == "2")
            {
                travel.Corridor1_Travel();
            }
            else if (stand.player_input.ToUpper() == "LOOT" || stand.player_input == "3")
            {
                if (desk_looted == false)
                {
                    Inventory_Manage.added_cash = 47.00f;
                    inventory.Money_Add();
                    desk_looted = true;
                    Console.WriteLine("Press enter to continue:");
                    Console.ReadLine();
                    Desk_Description();
                }
                else
                {
                    Console.WriteLine("!- The desk has already been looted.");
                    Console.WriteLine("\nPlease enter a different option.");
                    Desk_Choice();
                }
            }
            else if (stand.player_input.ToUpper() == "EXAMINE" || stand.player_input == "4")
            {
                Body_Description();
            }
            else
            {
                Console.WriteLine("!- You did not enter one of the choices.");
                Console.WriteLine("\nPlease enter a different option.");
                Desk_Choice();
            }
        }

        private void Body_Description()
        {
            Console.WriteLine("The employee is completley unconcious on the floor, but still breathing.");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            Console.WriteLine("(2) - Examine Body");
            if (staff_looted == false)
            {
                Console.WriteLine("(3) - Loot Body");
            }
            else
            {
                
                Console.WriteLine("(3) - Loot Body [LOOTED]");
            }
            Console.WriteLine("(4) - Back");
            Body_Choice();
        }

        private void Body_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                inventory.Inventory_List();
                Body_Description();
            }
            else if (stand.player_input.ToUpper() == "EXAMINE" || stand.player_input == "2")
            {
                Console.WriteLine("The staff member is still breathing, it would be possible to steal their belongings.");
                Console.WriteLine("Press enter to continue:");
                Console.ReadLine();
                Body_Description();
            }
            else if (stand.player_input.ToUpper() == "LOOT" || stand.player_input == "3")
            {
                if (staff_looted == false)
                {
                    Inventory_Manage.new_item = "Staff Keyring";
                    Inventory_Manage.item_desc = "Grants access to offices and the deposit box room";
                    inventory.Item_Add();
                    staff_looted = true;
                    Console.WriteLine("Press enter to continue:");
                    Console.ReadLine();
                    Body_Description();
                }
                else
                {
                    Console.WriteLine("!- The body has already been looted.");
                    Console.WriteLine("\nPlease enter a different option.");
                    Body_Choice();
                }
            }
            else if (stand.player_input.ToUpper() == "BACK" || stand.player_input == "4")
            {
                Desk_Description();
            }
            else
            {
                Console.WriteLine("!- You did not enter one of the choices");
                Console.WriteLine("\nPlease enter a different option.");
                Body_Choice();
            }
        }
    }
}
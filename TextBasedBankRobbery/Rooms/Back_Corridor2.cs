using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery.Rooms
{
    class Back_Corridor2
    {
        //Declares all of the external classes which will need to be used within this class.
        Global_Variables stand = new Global_Variables();
        Room_Travels travel = new Room_Travels();
        Inventory_Manage inventory = new Inventory_Manage();
        End_Game end = new End_Game();

        //Declares all of the private variables to be used within this class.
        private static bool guard_threatened = false;
        private bool loop1 = true;

        public void Corridor2_Description()
        {
            //Prints the current description of the room as well as the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Corridor");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- This side of the corridor is empty, if you dont count the massive vault door in the middle of it.");
            Console.WriteLine("- The deposit box room and back entrance doors are also present.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            if (Inventory_Manage.Player_Inventory.Contains("Back Entrance Key") == false)
            {
                Console.WriteLine("(2) - Back Entrance [LOCKED]");
            }
            else
            {
                Console.WriteLine("(2) - Back Entrance");
            }
            Console.WriteLine("(3) - Front Corridor");
            if (Inventory_Manage.Player_Inventory.Contains("Vault Key") == false)
            {
                Console.WriteLine("(4) - Vault Room [LOCKED]");
            }
            else
            {
                Console.WriteLine("(4) - Vault Room");
            }
            if (Inventory_Manage.Player_Inventory.Contains("Staff Keyring") == false)
            {
                Console.WriteLine("(5) - Deposit Box Room [LOCKED]");
            }
            else
            {
                Console.WriteLine("(5) - Deposit Box Room");
            }
            Corridor2_Choice();
        }

        public void Corridor2_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                inventory.Inventory_List();
                Corridor2_Description();
            }
            else if (stand.player_input.ToUpper() == "BACK ENTRANCE" || stand.player_input == "2")
            {
                if (Inventory_Manage.Player_Inventory.Contains("Back Entrance Key") == false)
                {
                    Console.WriteLine("!- You do not have the key to go through this door yet.");
                    Console.WriteLine("\nPlease enter another choice:");
                    Corridor2_Choice();
                }
                else
                {
                    travel.Back_Travel();
                }
            }
            else if (stand.player_input.ToUpper() == "FRONT CORRIDOR" || stand.player_input == "3")
            {
                travel.Corridor1_Travel();
            }
            else if (stand.player_input.ToUpper() == "VAULT ROOM" || stand.player_input == "4")
            {
                if (Inventory_Manage.Player_Inventory.Contains("Vault Key") == false)
                {
                    if (guard_threatened == false)
                    {
                        Console.WriteLine("- Before you get into this room you must get past the guard.");
                        Console.WriteLine("!- But you do not have the key to go through this door yet anyway.");
                        Console.WriteLine("Press enter to continue:");
                        Console.ReadLine();
                        Corridor2_Description();
                    }
                }
                else
                {
                    if (guard_threatened == false)
                    {
                        Console.WriteLine("- Before you get into this room you must get past the guard.");
                        Console.WriteLine("Press enter to continue:");
                        Console.ReadLine();
                        Guard_Description();
                    }
                    else if (guard_threatened == true)
                    {
                        Console.WriteLine("- You point the gun at the guard.");
                        Console.WriteLine("- He quivers and allows you past.");
                        travel.Vault_Travel();
                    }

                }
            }
            else if (stand.player_input.ToUpper() == "DEPOSIT BOX ROOM" || stand.player_input == "5")
            {
                if (Inventory_Manage.Player_Inventory.Contains("Staff Keyring") == false)
                {
                    if (guard_threatened == false)
                    {
                        Console.WriteLine("- Before you get into this room you must get past the guard.");
                        Console.WriteLine("!- But you do not have the key to go through this door yet anyway.");
                        Console.WriteLine("Press enter to continue:");
                        Console.ReadLine();
                        Corridor2_Description();
                    }
                }
                else
                {
                    if (guard_threatened == false)
                    {
                        Console.WriteLine("- Before you get into this room you must get past the guard.");
                        Console.WriteLine("Press enter to continue:");
                        Console.ReadLine();
                        Guard_Description();
                    }
                    else if (guard_threatened == true)
                    {
                        Console.WriteLine("- You point the gun at the guard.");
                        Console.WriteLine("- He quivers and allows you past.");
                        travel.Deposit_Travel();
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("!- You did not enter one of the choices.");
                Console.WriteLine("\nPlease enter another choice:");
                Corridor2_Choice();
            }
        }

        private void Guard_Description()
        {
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Corridor");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\nThe guard is big and threatening, there isnt any weapon which could help you win a fight against him.");
            Console.WriteLine("But maybe you could make it look like you would win.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            Console.WriteLine("(2) - Talk");
            Console.WriteLine("(3) - Threaten");
            Console.WriteLine("(4) - Fight");
            Console.WriteLine("(5) - Back");
            Guard_Choice();
        }
        private void Guard_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                inventory.Inventory_List();
                Guard_Description();
            }
            else if (stand.player_input.ToUpper() == "TALK" || stand.player_input == "2")
            {
                Console.WriteLine("!- You try to talk to the guard, he gives you a sour look.");
                Console.WriteLine("\nPlease enter another choice:");
                Guard_Choice();
            }
            else if (stand.player_input.ToUpper() == "THREATEN" || stand.player_input == "3")
            {
                if (Inventory_Manage.Player_Inventory.Contains("Toy Gun") == true)
                {
                    Console.WriteLine("- You point the toy gun at the guard.");
                    Console.WriteLine("- Luckily the guard is a meat head, and believes it is real.");
                    guard_threatened = true;
                    Console.WriteLine("- He puts his hands in the air and surrenders to you, allowing you wherever you want.");
                    Console.WriteLine("- He also tells you the most valueable deposit box number.");
                    Global_Variables.know_deposit = true;
                    Console.WriteLine("Press enter to continue:");
                    Console.ReadLine();
                    Corridor2_Description();
                }
                else
                {
                    Console.WriteLine("!- The guard laughs in your face and knocks you out.");
                    end.Game_Lose();
                }
            }
            else if (stand.player_input.ToUpper() == "FIGHT" || stand.player_input == "4")
            {
                Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
                Console.WriteLine("\nYou have a 0% chance of winning this fight.");
                Console.WriteLine("Are you sure you want to continue?\n");
                Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
                Console.WriteLine("Please enter one of the following:");
                Console.WriteLine("(Y) - Yes");
                Console.WriteLine("(N) - No");
                while (loop1 == true)
                {
                    stand.player_input = Console.ReadLine();
                    if (stand.player_input.ToUpper() == "YES" || stand.player_input.ToUpper() == "Y")
                    {
                        Console.WriteLine("!- You attempt to attack the guard who swiftly dodges and instantly knocks you out with a single blow.");
                        end.Game_Lose();
                        break;
                    }
                    else if (stand.player_input.ToUpper() == "NO" || stand.player_input.ToUpper() == "N")
                    {
                        Console.WriteLine("- Good Choice.");
                        Console.WriteLine("Press enter to continue:");
                        Console.ReadLine();
                        Guard_Description();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("!- You did not enter one of the choices.");
                        Console.WriteLine("\nPlease enter another choice:");
                    }
                }
            }
            else if (stand.player_input.ToUpper() == "BACK" || stand.player_input == "5")
            {
                Corridor2_Description();
            }
            else
            {
                Console.WriteLine("!- You did not enter one of the choices.");
                Console.WriteLine("\nPlease enter another choice:");
                Guard_Choice();

            }
        }
    }
}

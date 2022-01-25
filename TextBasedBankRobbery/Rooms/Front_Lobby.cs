using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery.Rooms
{
    class Front_Lobby
    {
        //Declares all of the external classes which will need to be used within this class.
        Global_Variables stand = new Global_Variables();
        Room_Travels travel = new Room_Travels();
        Inventory_Manage inventory = new Inventory_Manage();
        End_Game end = new End_Game();

        //Declares all of the private variables to be used within this class.
        private bool loop1 = true;
        private static bool atm_looted = false;

        public void Lobby_Description()
        {
            //Prints the current description of the room as well as the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Front Lobby");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The lobby is a large open area, to the left are a set of offices and to the right is a row of ATM machines.");
            Console.WriteLine("- In front of you is the front desk as well as the door to the back corridor which reads \"Staff only\".");
            if (Inventory_Manage.Player_Inventory.Contains("Lobby Key") == true && (Inventory_Manage.Player_Inventory.Contains("Back Entrance Key")) == true)
            {
                Console.WriteLine("- There are no customers queuing at the front desk.");
            }
            else
            {
                Console.WriteLine("- There are two customers queuing at the front desk.");
            }
            if (Global_Variables.desk_killed == false)
            {
                Console.WriteLine("- If you were to do anything suspicious you would most likley be noticed by the desk staff.\n");
                
            }
            else
            {
                Console.WriteLine(" ");
            }
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            Console.WriteLine("(2) - Front Entrance");
            if (Inventory_Manage.Player_Inventory.Contains("Lobby Key") == false)
            {
                Console.WriteLine("(3) - Front Corridor (Locked)");
            }
            else
            {
                Console.WriteLine("(3) - Front Corridor");
            }
            
            Console.WriteLine("(4) - Offices");
            if (Inventory_Manage.Player_Inventory.Contains("Lobby Key") == true && (Inventory_Manage.Player_Inventory.Contains("Back Entrance Key")) == true)
            {
                Console.WriteLine("(5) - Front Desk [QUEUELESS]");
            }
            else
            {
                Console.WriteLine("(5) - Front Desk [QUEUE]");
            }
            Console.WriteLine("(6) - ATMs");
            Lobby_Choice();
        }

        public void Lobby_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                inventory.Inventory_List();
                Lobby_Description();
            }
            else if (stand.player_input.ToUpper() == "FRONT ENTRANCE" || stand.player_input == "2")
            {
                travel.Front_Travel();
            }
            else if (stand.player_input.ToUpper() == "FRONT CORRIDOR" || stand.player_input == "3")
            {
                if (Inventory_Manage.Player_Inventory.Contains("Lobby Key") == false)
                {
                    Console.WriteLine("!- You do not have the key to go through this door yet.");
                    Console.WriteLine("\nPlease enter another choice:");
                    Lobby_Choice();
                }
                else
                {
                    travel.Corridor1_Travel();
                }
            }
            else if (stand.player_input.ToUpper() == "OFFICES" || stand.player_input == "4")
            {
                Office_Description();
            }
            else if (stand.player_input.ToUpper() == "FRONT DESK" || stand.player_input == "5")
            {
                
                if (Inventory_Manage.Player_Inventory.Contains("Lobby Key") == true && (Inventory_Manage.Player_Inventory.Contains("Back Entrance Key")) == true)
                {
                    Fdesk_Description();
                }
                else
                {
                    Console.WriteLine("The queue is too long to sit through right now.");
                    Console.WriteLine("\nPlease enter another choice:");
                    Lobby_Choice();
                }
            }
            else if (stand.player_input.ToUpper() == "ATMS" || stand.player_input == "6")
            {
                Atm_Description();
            }
            else
            {
                Console.WriteLine("You did not enter a valid choice.");
                Console.WriteLine("\nPlease enter another choice:");
                Lobby_Choice();
            }
        }
        private void Office_Description()
        {
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Front Lobby");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- There are 3 offices all adjacent to eachother.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            if (Inventory_Manage.Player_Inventory.Contains("Staff Keyring") == false)
            {
                Console.WriteLine("(2) - Office A [LOCKED]");
            }
            else
            {
                Console.WriteLine("(2) - Office A");
            }
            if (Inventory_Manage.Player_Inventory.Contains("Staff Keyring") == false)
            {
                Console.WriteLine("(3) - Office B [LOCKED]");
            }
            else
            {
                Console.WriteLine("(3) - Office B");
            }
            Console.WriteLine("(4) - Office C");
            Console.WriteLine("(5) - Back");
            Office_Choice();
        }

        private void Office_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input.ToUpper() == "1")
            {
                inventory.Inventory_List();
                Office_Description();
            }
            else if (stand.player_input.ToUpper() == "OFFICE A" || stand.player_input.ToUpper() == "2")
            {
                if (Inventory_Manage.Player_Inventory.Contains("Staff Keyring") == false)
                {
                    Console.WriteLine("!- You do not have the key to go through this door yet.");
                    Console.WriteLine("\nPlease enter another choice:");
                    Office_Choice();
                }
                else
                {
                    travel.Office1_Travel();
                }
            }
            else if (stand.player_input.ToUpper() == "OFFICE B" || stand.player_input.ToUpper() == "3")
            {
                if (Inventory_Manage.Player_Inventory.Contains("Staff Keyring") == false)
                {
                    Console.WriteLine("!- You do not have the key to go through this door yet.");
                    Console.WriteLine("\nPlease enter another choice:");
                    Office_Choice();
                }
                else
                {
                    travel.Office2_Travel();
                }
            }
            else if (stand.player_input.ToUpper() == "OFFICE C" || stand.player_input.ToUpper() == "4")
            {
                travel.Office3_Travel();
            }
            else if (stand.player_input.ToUpper() == "BACK" || stand.player_input.ToUpper() == "5")
            {
                Lobby_Description();
            }
            else
            {
                Console.WriteLine("You did not enter one of the choices.");
                Console.WriteLine("\nPlease enter another choice:");
                Office_Choice();
            }
        }

        private void Fdesk_Description()
        {
            if (Global_Variables.desk_killed == false)
            {
                Console.Clear();
                Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
                Console.WriteLine("Location: Front Lobby");
                Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
                Console.WriteLine("\n- You walk up to the front desk where the bored employee is.");
                Console.WriteLine("- \"How may I help you?\" the desk staff asks.\n");
                Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
                Console.WriteLine("Please enter one of the following:");
                Console.WriteLine("(1) - Inventory");
                Console.WriteLine("(2) - Talk ");
                Console.WriteLine("(3) - Attack ");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
                Console.WriteLine("Location: Front Lobby");
                Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
                Console.WriteLine("\nYou walk up to the empty front desk.\n");
                Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
                Console.WriteLine("Please enter one of the following:");
                Console.WriteLine("(1) - Inventory");
                Console.WriteLine("(2) - Examine Desk");
                Console.WriteLine("(3) - Loot");
            }
            Console.WriteLine("(4) - Back");
            Fdesk_Choice();
        }
        private void Fdesk_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (Global_Variables.desk_killed == false)
            {
                if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
                {
                    inventory.Inventory_List();
                    Fdesk_Description();
                }
                else if (stand.player_input.ToUpper() == "TALK" || stand.player_input == "2")
                {
                    Console.WriteLine("- You talk to the front desk staff and learn that the bank is at its least busy hour.");
                    Console.WriteLine("- The staff reveals that they only have 6 employees on site currently.");
                    Console.WriteLine("Press enter to continue:");
                    Console.ReadLine();
                    Fdesk_Description();
                }
                else if (stand.player_input.ToUpper() == "ATTACK" || stand.player_input == "3")
                {
                    if (Global_Variables.combat_power <= 5)
                    {
                        Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
                        Console.WriteLine("You need a combat power above 5 to guarantee winning this fight, instead you have a {0}0% chance of winning this fight.", Global_Variables.combat_power);
                        Console.WriteLine("Are you sure you want to continue?");
                        Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
                        Console.WriteLine("Please enter one of the following:");
                        Console.WriteLine("(Y) - Yes");
                        Console.WriteLine("(N) - No");
                        while (loop1 == true)
                        {
                            stand.player_input = Console.ReadLine();
                            if (stand.player_input.ToUpper() == "YES" || stand.player_input.ToUpper() == "Y")
                            {
                                stand.random_num = stand.rng.Next(11);
                                if (Global_Variables.combat_power < stand.random_num)
                                {
                                    Console.WriteLine("!- You lost the fight.");
                                    end.Game_Lose();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("- You reach your hands through the holes in the glass and knock out the Staff member with a struggle");
                                    Global_Variables.desk_killed = true;
                                    Console.WriteLine("Press enter to continue:");
                                    Console.ReadLine();
                                    Fdesk_Description();
                                    break;
                                }
                            }
                            else if (stand.player_input.ToUpper() == "NO" || stand.player_input.ToUpper() == "N")
                            {
                                Fdesk_Description();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You did not enter a valid choice.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("- You reach your hands through the holes in the glass and knock out the Staff member with a swift blow.");
                        Global_Variables.desk_killed = true;
                        Console.WriteLine("Press enter to continue:");
                        Console.ReadLine();
                        Fdesk_Description();
                    }
                }
                else if (stand.player_input.ToUpper() == "BACK" || stand.player_input == "4")
                {
                    Lobby_Description();
                }
                else
                {
                    Console.WriteLine("!- You did not enter a valid choice.");
                    Console.WriteLine("\nPlease enter another choice:");
                    Fdesk_Choice();
                }
            }
            else
            {
                if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
                {
                    inventory.Inventory_List();
                    Fdesk_Description();
                    Fdesk_Choice();
                }
                else if (stand.player_input.ToUpper() == "EXAMINE" || stand.player_input == "2")
                {
                    Console.WriteLine("- The desk is empty from the outside, you cannot see the floor.");
                    Console.WriteLine("Press enter to continue:");
                    Console.ReadLine();
                    Fdesk_Description();
                }
                else if (stand.player_input.ToUpper() == "LOOT" || stand.player_input == "3")
                {
                    Console.WriteLine("- The desk has a glass barrier stopping you from looting it from the outside.");
                    Console.WriteLine("Press enter to continue:");
                    Console.ReadLine();
                    Fdesk_Description();
                }
                else if (stand.player_input.ToUpper() == "BACK" || stand.player_input == "4")
                {
                    Lobby_Description();
                }
                else
                {
                    Console.WriteLine("!- You did not enter a valid choice.");
                    Console.WriteLine("\nPlease enter another choice:");
                    Fdesk_Choice();
                }

            }
            
        }
        
        private void Atm_Description()
        {
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Front Lobby");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The ATM machines stand shoulder to shoulder.\n");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory ");
            Console.WriteLine("(2) - Examine");
            if (atm_looted == false)
            {
                Console.WriteLine("(3) - Loot");
            }
            else
            {
                Console.WriteLine("(3) - Loot [LOOTED]");
            }
            Console.WriteLine("(4) - Back");
            Atm_Choice();
        }
        private void Atm_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                inventory.Inventory_List();
                Atm_Description();
            }
            else if (stand.player_input.ToUpper() == "EXAMINE" || stand.player_input == "2")
            {
                Console.WriteLine("- The ATM machines look old, they could probably be screwed open easily.");
                Console.WriteLine("Press enter to continue:");
                Console.ReadLine();
                Console.Clear();
                Atm_Description();
            }
            else if (stand.player_input.ToUpper() == "LOOT" || stand.player_input == "3")
            {
                if (atm_looted == false)
                {
                    if (Inventory_Manage.Player_Inventory.Contains("Screwdriver") == true)
                    {
                        if (Global_Variables.desk_killed == true)
                        {
                            Console.WriteLine("- You unscrew the ATM cases to reveal bundles of cash inside.");
                            Inventory_Manage.added_cash = 600.00f;
                            inventory.Money_Add();
                            atm_looted = true;
                            Console.WriteLine("Press enter to continue:");
                            Console.ReadLine();
                            Atm_Description();
                        }
                        else
                        {
                            Console.WriteLine("!- You are spotted trying to break into the ATM machines and are reported.");
                            end.Game_Lose();
                        }
                    }
                    else
                    {
                        Console.WriteLine("!- You dont have any tools to open the ATMs.");
                        Console.WriteLine("\nPlease enter another choice:");
                        Atm_Choice();
                    }
                }
                else
                {
                    Console.WriteLine("!- The ATMs have already been looted.");
                    Console.WriteLine("\nPlease enter another choice:");
                    Atm_Choice();
                }
            }
            else if (stand.player_input.ToUpper() == "BACK" || stand.player_input == "4")
            {
                Lobby_Description();
            }
            else
            {
                Console.WriteLine("!- You did not enter a valid choice.");
                Console.WriteLine("\nPlease enter another choice:");
                Atm_Choice();
            }
        }
    }
}

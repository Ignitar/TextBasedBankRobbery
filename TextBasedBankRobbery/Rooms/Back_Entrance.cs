using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery.Rooms
{
    class Back_Entrance
    {
        //Declares all of the external classes which will need to be used within this class.
        Global_Variables stand = new Global_Variables();
        Room_Travels travel = new Room_Travels();
        Inventory_Manage inventory = new Inventory_Manage();
        End_Game end = new End_Game();

        //Declares all of the private variables to be used within this class.
        private static bool smoker_killed = false;
        private bool loop1 = true;

        public void Back_Description()
        {
            //Prints the current description of the room as well as the player's current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Back Entrance");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("\n- The back entrance is sheltered with steps leading up to the entrance door.");
            Console.WriteLine("- It still close to the alley so the horrible smell still lingers, however now mixed with the smell of cigarette smoke.");
            if (smoker_killed == false)
            {
                Console.WriteLine("- A staff member stands by the door smoking.\n");
            }
            else
            {
                Console.WriteLine("- The body of a staff member lays by the door, wishing it was smoking.\n");
            }
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            Console.WriteLine("(1) - Inventory");
            Console.WriteLine("(2) - Side Alley");
            if (Inventory_Manage.Player_Inventory.Contains("Back Entrance Key") == false)
            {
                Console.WriteLine("(3) - Back Corridor [LOCKED]");
            }
            else
            {
                Console.WriteLine("(3) - Back Corridor");
            }
            if (smoker_killed == false)
            {
                Console.WriteLine("(4) - Staff Member");
            }
            else
            {
                if (Inventory_Manage.Player_Inventory.Contains("Back Entrance Key") == false)
                {
                    Console.WriteLine("(4) - Staff Member's Body");
                }
                else
                {
                    Console.WriteLine("(4) - Staff Member's Body [LOOTED]");
                }
            }
            Back_Choice();
        }

        public void Back_Choice()
        {
            stand.player_input = Console.ReadLine();
            if (stand.player_input.ToUpper() == "INVENTORY" || stand.player_input == "1")
            {
                //Displays players inventory.
                inventory.Inventory_List();
                Back_Description();
            }
            else if (stand.player_input.ToUpper() == "SIDE ALLEY" || stand.player_input == "2")
            {
                //Sends player to side alley.
                travel.Alley_Travel();
            }
            else if (stand.player_input.ToUpper() == "BACK CORRIDOR" || stand.player_input == "3")
            {
                //Sends player to bacl corridor if they have the back entrance key.
                if (Inventory_Manage.Player_Inventory.Contains("Back Entrance Key") == false)
                {
                    Console.WriteLine("!- You do not have the key to go through this door yet.");
                    Console.WriteLine("\nPlease enter another choice:");
                    Back_Choice();
                }
                else
                {
                    travel.Corridor2_Travel();
                }    
            }
            else if (stand.player_input.ToUpper() == "STAFF MEMBER" || stand.player_input == "4")
            {
                Smoker_Description();
            }
            else
            {
                Console.WriteLine("!- You did not enter one of the choices.");
                Console.WriteLine("\nPlease enter another choice:");
                Back_Choice();
            }
        }

        private void Smoker_Description()
        {
            //Displays the current information about the staff member and the players current choices.
            Console.Clear();
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            Console.WriteLine("Location: Back Entrance");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
            if (smoker_killed == false)
            {
                Console.WriteLine("\n- The staff's mind seems vacant while they smoke their cigarette.\n");
            }
            else
            {
                Console.WriteLine("\n- The staff's mind is vacant while they lie on the floor knocked out.\n");
            }
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
            Console.WriteLine("Please enter one of the following:");
            if (smoker_killed == false)
            {
                Console.WriteLine("(1) - Talk to Staff Member");
                Console.WriteLine("(2) - Attack Staff Member");
            }
            else
            {
                Console.WriteLine("(1) - Examine Staff Member's Body");
                if (Inventory_Manage.Player_Inventory.Contains("Back Entrance Key") == false)
                {
                    Console.WriteLine("(2) - Loot Staff Member's Body");
                }
                else
                {
                    Console.WriteLine("(2) - Loot Staff Member's Body [LOOTED]");
                }
            }
            Console.WriteLine("(3) - Back");
            Smoker_Choice();
        }
        private void Smoker_Choice()
        {
            stand.player_input = Console.ReadLine();
            //Checks if the staff member is not dead and if not the player talks to them.
            if (smoker_killed == false)
            {
                if (stand.player_input.ToUpper() == "TALK" || stand.player_input == "1")
                {
                    Console.WriteLine("- You initiate a conversation with the staff member.");
                    Console.WriteLine("- You learn that they are a new member of staff and this is their first day.");
                    Console.WriteLine("Press enter to continue:");
                    Console.ReadLine();
                    Smoker_Description();
                }
                //Attacls the staff member.
                else if (stand.player_input.ToUpper() == "ATTACK" || stand.player_input == "2")
                {
                    while (loop1 == true)
                    {
                        if (Global_Variables.combat_power <= 3)
                        {
                            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->");
                            Console.WriteLine("- You need a combat power above 3 to guarantee winning this fight, instead you have a {0}0% chance of winning this fight.", Global_Variables.combat_power);
                            Console.WriteLine("- Are you sure you want to continue?");
                            Console.WriteLine("<--------------------------------------------------------------------------------------------------------------------->\n");
                            Console.WriteLine("Please enter one of the following:");
                            Console.WriteLine("(Y) - Yes");
                            Console.WriteLine("(N) - No");
                            stand.player_input = Console.ReadLine();
                            if (stand.player_input.ToUpper() == "YES" || stand.player_input.ToUpper() == "Y")
                            {
                                //Generates a random number between 1 and 10.
                                stand.random_num = stand.rng.Next(11);
                                if (Global_Variables.combat_power < stand.random_num)
                                {
                                    Console.WriteLine("You lost the fight.");
                                    end.Game_Lose();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("- You knock out the Staff member with a struggle.");
                                    smoker_killed = true;
                                    Console.WriteLine("Press enter to continue:");
                                    Console.ReadLine();
                                    Smoker_Description();
                                    break;
                                }
                            }
                            else if (stand.player_input.ToUpper() == "NO" || stand.player_input.ToUpper() == "N")
                            {
                                Smoker_Description();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("!- You did not enter one of the choices.");
                                Console.WriteLine("\nPlease enter another choice:");
                                Smoker_Choice();
                            }
                        }
                        else
                        {
                            Console.WriteLine("- You knock out the Staff member with a swift blow.");
                            smoker_killed = true;
                            Console.WriteLine("Press enter to continue:");
                            Console.ReadLine();
                            Smoker_Description();
                        }
                    }
                    
                }
                else if (stand.player_input.ToUpper() == "BACK" || stand.player_input == "3")
                {
                    Back_Description();
                }
                else
                {
                    Console.WriteLine("!- You did not enter one of the choices.");
                    Console.WriteLine("\nPlease enter another choice:");
                    Smoker_Choice();
                }
            }
            else
            {
                if (stand.player_input.ToUpper() == "EXAMINE" || stand.player_input == "1")
                {
                    Console.WriteLine("- The Staff Member is out cold.");
                    Console.WriteLine("- He still has a cigarette in his mouth.");
                    Console.WriteLine("Press enter to continue:");
                    Console.ReadLine();
                    Smoker_Description();
                }
                else if (stand.player_input.ToUpper() == "LOOT" || stand.player_input == "2")
                {
                    //Checks if the player has the back entrance key in their inventory, if so they have looted the body.
                    if (Inventory_Manage.Player_Inventory.Contains("Back Entrance Key") == false)
                    {
                        Inventory_Manage.new_item = "Back Entrance Key";
                        Inventory_Manage.item_desc = "Grants back entrance access";
                        inventory.Item_Add();
                        Inventory_Manage.added_cash = 15.00f;
                        inventory.Money_Add();
                        Console.WriteLine("Press enter to continue:");
                        Console.ReadLine();
                        Smoker_Description();
                    }
                    else
                    {
                        Console.WriteLine("!- The body has already been looted.");
                        Console.WriteLine("\nPlease enter another choice:");
                        Smoker_Choice();
                    }
                    
                }
                else if (stand.player_input.ToUpper() == "BACK" || stand.player_input == "3")
                {
                    Back_Description();
                }
                else
                {
                    Console.WriteLine("!- You did not enter one of the choices.");
                    Console.WriteLine("\nPlease enter another choice:");
                    Smoker_Choice();
                }
            }
            
        }
    }
}

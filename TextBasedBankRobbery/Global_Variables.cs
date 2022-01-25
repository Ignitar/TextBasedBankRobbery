using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery
{
    class Global_Variables
    {
        //Declares all of the global variables which are to be used throughout the whole program.
        public static string current_room = " ";
        public static int combat_power = 1;
        public static bool desk_killed = false;
        public static bool know_deposit = false;
        public string player_input;
        public Random rng = new Random();
        public int random_num;
    }
}

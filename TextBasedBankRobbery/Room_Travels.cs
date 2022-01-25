using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedBankRobbery
{
    class Room_Travels
    {
        //All of the below performs everything needed to change rooms.
        public void Outside_Travel()
        {
            Console.Clear();
            Rooms.Bank_Outside outside = new Rooms.Bank_Outside();
            Global_Variables.current_room = "Bank Outside";
            outside.Outside_Description();
        }
        public void Front_Travel()
        {
            Console.Clear();
            Rooms.Front_Entrance front = new Rooms.Front_Entrance();
            Global_Variables.current_room = "Front Entrance";
            front.Front_Description();
        }
        public void Lobby_Travel()
        {
            Console.Clear();
            Rooms.Front_Lobby lobby = new Rooms.Front_Lobby();
            Global_Variables.current_room = "Lobby";
            lobby.Lobby_Description();
        }
        public void Corridor1_Travel()
        {
            Console.Clear();
            Rooms.Back_Corridor1 corridor1 = new Rooms.Back_Corridor1();
            Global_Variables.current_room = "Corridor";
            corridor1.Corridor1_Description();
        }
        public void Corridor2_Travel()
        {
            Console.Clear();
            Rooms.Back_Corridor2 corridor2 = new Rooms.Back_Corridor2();
            Global_Variables.current_room = "Corridor";
            corridor2.Corridor2_Description();
        }
        public void Back_Travel()
        {
            Console.Clear();
            Rooms.Back_Entrance back = new Rooms.Back_Entrance();
            Global_Variables.current_room = "Back Entrance";
            back.Back_Description();
        }
        public void Alley_Travel()
        {
            Console.Clear();
            Rooms.Side_Alley alley = new Rooms.Side_Alley();
            Global_Variables.current_room = "Side Alley";
            alley.Alley_Description();
        }
        public void Vault_Travel()
        {
            Console.Clear();
            Rooms.Bank_Vault vault = new Rooms.Bank_Vault();
            Global_Variables.current_room = "The Vault";
            vault.Vault_Description();
        }
        public void Deposit_Travel()
        {
            Console.Clear();
            Rooms.Deposit_Room deposit = new Rooms.Deposit_Room();
            Global_Variables.current_room = "Deposit Room";
            deposit.Deposit_Description();
        }
        public void Desk_Travel()
        {
            Console.Clear();
            Rooms.Front_Desk desk = new Rooms.Front_Desk();
            Global_Variables.current_room = "Front Desk";
            desk.Desk_Description();
        }
        public void Staff_Travel()
        {
            Console.Clear();
            Rooms.Staff_Room staff = new Rooms.Staff_Room();
            Global_Variables.current_room = "Staff Room";
            staff.Staff_Description();
        }
        public void Office1_Travel()
        {
            Console.Clear();
            Rooms.Office_1 office1 = new Rooms.Office_1();
            Global_Variables.current_room = "Office";
            office1.Office1_Description();
        }
        public void Office2_Travel()
        {
            Console.Clear();
            Rooms.Office_2 office2 = new Rooms.Office_2();
            Global_Variables.current_room = "Office";
            office2.Office2_Description();
        }
        public void Office3_Travel()
        {
            Console.Clear();
            Rooms.Office_3 office3 = new Rooms.Office_3();
            Global_Variables.current_room = "Office";
            office3.Office3_Description();
        }

    }
}

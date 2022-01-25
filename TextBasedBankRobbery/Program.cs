using System;

namespace TextBasedBankRobbery
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calls the beggining room where the player starts.
            Rooms.Bank_Outside begin = new Rooms.Bank_Outside();

            begin.Outside_Description();
            begin.Outside_Choice();
        }
    }
}

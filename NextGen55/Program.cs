using System;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace NextGen55
{
    class Program
    {

        public static int? Targaryen = 110;
        public static int? Starks = 0;
        public static int? Lannister = 0;
        public static int? Tyrells = 0;
        static int housesAlive = 0;

        static void Main(string[] args)
        {            
            //Don't try to do any actions with a house that doesn't exist anymore, it will crash
            
            addArmy("Targaryen", 300);
            addArmy("Tyrells", 200);
            attack("Targaryen", "Tyrells");
            addArmy("Lannister", 800);
            addArmy("Targaryen", 500);
            addArmy("Starks", 200);
            join("Starks", "Targaryen");
            attack("Targaryen", "Lannister");
            Console.ReadLine();
        }

        static void addArmy(string name, int troopCount) => typeof(Program).GetField(name).SetValue(null, (int)typeof(Program).GetField(name).GetValue(null) + troopCount);

        static void join(string house1, string house2)
        {
            int house1num = (int)typeof(Program).GetField(house1).GetValue(null);
            int house2num = (int)typeof(Program).GetField(house2).GetValue(null);
            if (house1num > house2num)
            {
                typeof(Program).GetField(house1).SetValue(null, house1num + house2num);
                typeof(Program).GetField(house2).SetValue(null, null);
            }
            else
            {
                typeof(Program).GetField(house1).SetValue(null, null);
                typeof(Program).GetField(house2).SetValue(null, house1num + house2num);
            }
        }

        static void attack(string house1, string house2)
        {
            int house1num = (int)typeof(Program).GetField(house1).GetValue(null);
            int house2num = (int)typeof(Program).GetField(house2).GetValue(null);

            if (house1num > house2num)
            {
                typeof(Program).GetField(house1).SetValue(null, house1num * 2/3);
                typeof(Program).GetField(house2).SetValue(null, null);
                if (warOver()) Console.WriteLine(house1 + " wins the war");
            }
            else
            {
                typeof(Program).GetField(house1).SetValue(null, null);
                typeof(Program).GetField(house2).SetValue(null, house1num * 2 / 3);
                if (warOver()) Console.WriteLine(house2 + " wins the war");
            }
        }

        static bool warOver()
        {
            for (int i = 0; i < 4; i++) if (typeof(Program).GetFields()[i].GetValue(null) != null) housesAlive++;
            if (housesAlive == 1) return true;
            else
            {
                housesAlive = 0;
                return false;
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale
{
   static class Tools
    {
        public static void  WaitInput()
        {
            Console.ReadKey();
        }
        public static bool Luck(int luck, Random randomNum, int chance)
        {
            int yourLuck = luck;
            int karma = randomNum.Next(chance);
            bool result = false;

            if (luck >= karma)
            { result = true; }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale
{
    internal abstract class Character :  ILuckable, Inameable
    {
              
        public static int points = 0;

       

        public string CharacterName { get; set; } = "Void";

        public  bool Luck(int luck, Random randomNum)
        {
            int yourLuck = luck;
            int karma = randomNum.Next(11);
            bool result = false;

            if (luck >= karma)
            { result = true; }

            return result;
        }

       
    }
}

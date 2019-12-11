using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale
{
    class Character : IEateble
    {
        static Random randomNum = new Random();
        const int luck = 5;
        public static int points = 0;
        public string CharacterName { get; set; } = "Void";

        public static bool Luck()
        {

            int karma = randomNum.Next(11);
            bool result = false;

            if (luck >= karma)
            { result = true; }

            return result;
        }

        public void EatCharacter()
        {
            throw new NotImplementedException();
        }
    }
}

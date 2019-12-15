using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FairyTale
{
    class Program
    {

        static void Main(string[] args)
        {
            Character lis = new Character() { CharacterName = "Лис Хитрый" };
            Character kaban = new Character() { CharacterName = "Кабан" };
            Character zayac = new Character() { CharacterName = "Заяц" };
            Character medved = new Character() { CharacterName = "Медведь" };
            List<Character> characters = new List<Character>() { lis, kaban, zayac, medved };
            try
            {
                StoryTeller.EndlessStory(characters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException);
            }
            


            
        }
    }
}

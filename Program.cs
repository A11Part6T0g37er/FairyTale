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
            ArrayList characters = new ArrayList() {  "Lis", "Kaban", "zayac", "Medved" };
            
            Console.WriteLine("Start Text");
            Tools.WaitInput();
            Console.WriteLine($"{characters[0]} met  {characters[1]}" );
            
            Console.WriteLine($"{characters[0]} ate  {characters[1]}");
            characters.Remove(characters[1]);

            Console.WriteLine($"They left {characters.Count}");
           foreach (string charact in characters)
            {
                Console.WriteLine(charact);
            }
            Character lis = new Character() { CharacterName = "Lis" };
           Console.WriteLine( Character.points);

            for (int i = 0; i < 20; i++)
            {

                if (Character.Luck())
                {
                    Console.WriteLine("Your luck has gained you another point!");
                    Character.points++;
                }
                else
                {
                    Console.WriteLine("Your luck has failed.... you've lost a point.");
                    Character.points--;
                }
            }
            Console.WriteLine("Your points: " + Character.points);
            Tools.WaitInput();
        }
    }
}

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
            Console.WriteLine("Как-то шли");

           foreach (var charact in characters)
            {
                Console.Write(charact.CharacterName);
                Console.Write(" ");
            }
            Console.Write("по лесу, и увидели спереди яму. Попытались они перепрыгнуть её.\n");


            List<Character> trapedOnes = new List<Character>();
            foreach (var charact in characters)
            {
                Console.Write($"{charact.CharacterName} попробовал ");
                if (Character.Luck(9))
                {
                    Console.WriteLine("но не получилось!");
                    trapedOnes.Add(charact);
                }
                else
                {
                    Console.WriteLine("и удалось избежать ловушки и сразу скрылся из ввиду.");
                   
                }
            }
            Console.WriteLine($"Итак {trapedOnes.Count} из них осталось в яме. Среди них были ");
            foreach (var trapped in trapedOnes)
            {
                Console.Write($"{trapped.CharacterName} ");
            }
            Tools.WaitInput();
            Console.WriteLine("Долго ли коротко сидели и проголодались аж выть хотелось.");
            Console.WriteLine($"Предложил {trapedOnes[0].CharacterName} запеть, и хто хуже споет того и съедят.\n И так пока выход не найдут.");

            while (trapedOnes.Count > 1)
            {


                for (int i = 0; i < trapedOnes.Count; i++)
                {


                    Console.Write($"Запели они но пение {trapedOnes[i].CharacterName} оказалось хуже всех и на него тут же набросились. ");
                    Console.WriteLine("Но голод не отступал.");
                    trapedOnes.RemoveAt(i);
                }
            } 
            if (trapedOnes.Count == 1)
            {
                Console.WriteLine("to be continue ...");
                //    Game.Scene("drozd");
            }
            Tools.WaitInput();
        }
    }
}

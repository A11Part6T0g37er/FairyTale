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
            Random randomNum = new Random();

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
                if (Character.Luck(9, randomNum))
                {
                    Console.WriteLine("но не получилось!");
                    trapedOnes.Add(charact);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("и удалось избежать ловушки и он сразу скрылся из ввиду.");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
            Console.WriteLine($"Итак {trapedOnes.Count} из них осталось в яме. Среди них были ");
            foreach (var trapped in trapedOnes)
            {
                Console.Write($"{trapped.CharacterName} ");
            }
            Console.WriteLine();
            Tools.WaitInput();
         
            Console.WriteLine("Долго ли коротко сидели и проголодались аж выть хотелось.");
            Console.WriteLine($"Предложил {trapedOnes[0].CharacterName} запеть, и хто хуже споет того и съедят.\n И так пока выход не найдут.");

            while (trapedOnes.Count > 1)
            {


                for (int i = 0; i < trapedOnes.Count; i++)
                {
                    int prey = randomNum.Next(trapedOnes.Count);

                    Console.Write($"Запели они но так плохо, как  {trapedOnes[prey].CharacterName} никто больше не пел и на него тот час набросились.\n");
                    Console.WriteLine("Но голод через некоторое время опять дал о себе знать.");
                    trapedOnes.RemoveAt(prey);
                }
            }
            Tools.WaitInput();


                Character lastHero = trapedOnes[0];
            //    StoryFlow.Scene("drozd");
            Console.WriteLine("Но вот к яме прилетел дрозд и стал вить гнездо. ");
            Console.WriteLine($"Обратился {lastHero.CharacterName} к нему \"Спаси меня, дрозд, а не то я твоих детей съем. \" ");
            if (Character.Luck(5, randomNum))
            {
                Console.WriteLine($"Дрозд решил все же спасти {lastHero.CharacterName}.\n Но злой {lastHero.CharacterName} продалжал угрожать птенцам,\n и лишь в обмен на еду соглашался пойти прочь.");
                if (Character.Luck(3, randomNum))
                {
                    Console.WriteLine($"Дрозд пообещал накормить и {lastHero.CharacterName} остался ждать.\n Он полетел в ближайшее село и, притворившись раненым, привел за собой стаю собак,\n которые отбили насмерть желание обижать слабых и {lastHero.CharacterName} не стал спорить.");
                    if( lastHero.CharacterName == "Лис Хитрый")
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine("Achievemnt unlocked: Ended like in the story");
                        Console.WriteLine("Achievemnt unlocked: Ended like in the story");
                    }
                }
                else
                {
                    Console.WriteLine($"Дрозд пообещал накормить {lastHero.CharacterName} остался ждать.\n Но сам улетел прочь от этого опасного участка леса.");
                }
            }
            else
            {
                Console.WriteLine($" Но дрозд решил не рисковать и свить гнездо подальше от\n злочастной ямы, где остался {lastHero.CharacterName}.");
            }
            Tools.WaitInput();
        }
    }
}

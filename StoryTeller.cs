using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale
{
    public static  class StoryTeller
    { 
      static  Random randomNum = new Random();

      internal  static void EndlessStory(List<Character> characters)
        {
            Console.WriteLine("Press ESC to stop");

        //    if ((Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
          //  {
                
           // }
           while (!( Console.ReadKey(false).Key == ConsoleKey.Escape)) {
              Start(characters);
            }
              Environment.Exit(0);
        }
        /// <summary>
        /// Initialization point
        /// </summary>
        internal static void Start(List<Character> characters)
        {
            Console.Title = "Whoever and Drozd";
            Console.WriteLine("Как-то шли");

            foreach (var charact in characters)
            {
                Console.Write(charact.CharacterName);
                Console.Write(" ");
            }
            Console.Write("по лесу, и увидели спереди яму. Попытались они перепрыгнуть её.\n");
            List<Character> trapedOnes = new List<Character>();
            Tools.WaitInput();
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



            Console.Title = "Enter the pit";
            // Story flows into pit scene and sequently returns only one hero from hunger time
            Character lastHero = PitTap(trapedOnes);
            //    StoryFlow.Scene("drozd");
            Console.Title = "Drozd has come";
            DrozdHasCome(lastHero);
        }

        internal static Character PitTap(List<Character> trapedOnes)
        {
            if ( trapedOnes.Count == 0)
                throw new ArgumentNullException() ;

            Console.Write($"Итак {trapedOnes.Count} из них осталось в яме. Среди них были ");
            for (int i = 0; i < trapedOnes.Count; i++)
            {
                Console.Write($"{trapedOnes[i].CharacterName}");
                if (i + 1 < trapedOnes.Count)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.Write(". ");
                }
            }
            Console.WriteLine();
            Tools.WaitInput();
            if (trapedOnes.Count > 0)
                return HungerComes(trapedOnes);
            else throw new ArgumentNullException();
        }
        /// <summary>
        /// Returns the luckiest one after hunger 
        /// </summary>
        /// <param name="trapedOnes"></param>
        /// <returns></returns>
        internal static Character HungerComes(List<Character> trapedOnes)
        {
            Console.WriteLine("Долго ли коротко сидели и проголодались аж выть хотелось.");
          int whoTells = TryLuck(trapedOnes);
            Console.WriteLine($"Предложил {trapedOnes[whoTells].CharacterName} запеть, и хто хуже споет того и съедят.\n И так пока выход не найдут.");

            while (trapedOnes.Count > 1)
            {


                for (int i = 0; i < trapedOnes.Count; i++)
                {
                    int prey = TryLuck(trapedOnes);

                    Console.Write($"Запели они но так плохо, как  {trapedOnes[prey].CharacterName} никто больше не пел и на него тот час набросились.\n");
                    Console.WriteLine("Но голод через некоторое время опять дал о себе знать.");
                    trapedOnes.RemoveAt(prey);
                }
            }
            Tools.WaitInput();

            return trapedOnes[0];
        }

        private static int TryLuck(List<Character> trapedOnes)
        {
           return randomNum.Next(trapedOnes.Count);
        }

        /// <summary>
        /// End of story
        /// </summary>
        /// <param name="lastHero"></param>
        private static void DrozdHasCome(Character lastHero)
    {
            Console.WriteLine("Но вот к яме прилетел дрозд и стал вить гнездо. ");
            Console.WriteLine($"Обратился {lastHero.CharacterName} к нему \"Спаси меня, дрозд, а не то я твоих детей съем. \" ");
            if (Character.Luck(5, randomNum))
            {
                Console.WriteLine($"Дрозд решил все же спасти {lastHero.CharacterName}.\n Но злой {lastHero.CharacterName} продалжал угрожать птенцам,\n и лишь в обмен на еду соглашался пойти прочь.");
                if (Character.Luck(3, randomNum))
                {
                    Console.WriteLine($"Дрозд пообещал накормить и {lastHero.CharacterName} остался ждать.\n Он полетел в ближайшее село и, притворившись раненым, привел за собой стаю собак,\n которые отбили насмерть желание обижать слабых и {lastHero.CharacterName} не стал спорить.");
                    if (lastHero.CharacterName == "Лис Хитрый")
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine("Achievemnt unlocked: Ended like in the story");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Tools.WaitInput();

                    }
                }
                else
                {
                    Console.WriteLine($"Дрозд пообещал накормить и {lastHero.CharacterName} остался его ждать.\n Но сам улетел прочь от этого опасного участка леса.");
                    Tools.WaitInput();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale
{
    public static class StoryTeller
    {
        delegate void SpeechVisualizer();
        static Random randomNum = new Random();
        
        internal static void EndlessStory(List<ILuckable> characters)
        {
            Console.WriteLine("Press ESC to stop");

           
           while (!(Console.ReadKey(false).Key == ConsoleKey.Escape)) {
                try
                {
                    Start(characters);
                }
                catch (EmptyPitException ex)
                {
                    Console.WriteLine(ex.Message, "Яма вновь ждет своих героев...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
                }
           
            // Environment.Exit(0);
        }
        /// <summary>
        /// Initialization point of story
        /// </summary>
        internal static void Start(List<ILuckable> characters)
        {
            Console.Title = "Whoever and Drozd";
           
SpeechVisualizer speechInit = () => Console.WriteLine("Как-то шли");
            speechInit();
            foreach (var charact in characters)
            {
                Console.Write(charact.CharacterName);
                Console.Write(" ");
            }
            Console.Write("по лесу, и увидели спереди яму. Попытались они перепрыгнуть её.\n");
            List<ILuckable> trapedOnes = new List<ILuckable>();
            Tools.WaitInput();
            foreach (var charact in characters)
            {
                Console.Write($"{charact.CharacterName} попробовал ");
                if (charact.Luck(9, randomNum))
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
            try
            {
                ILuckable lastHero = PitTap(trapedOnes);
           
                if (lastHero == null) throw new EmptyPitException("Дрозд больше никуда не прилетал и не вил гнезда.");
            Console.Title = "Drozd has come";
            DrozdHasCome(lastHero); 
            }
            catch (EmptyPitException ex)
            {
               Console.WriteLine(ex.Message);
                throw new EmptyPitException("Сказка возвращается к исходной точке.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException, ex.StackTrace);
            }
            //    StoryFlow.Scene("drozd");
           
        }
        /// <summary>
        /// Some percatage of rescued others will be traped
        /// </summary>
        /// <param name="trapedOnes"></param>
        /// <returns></returns>
        internal static ILuckable PitTap(List<ILuckable> trapedOnes)
        {
           
                if (trapedOnes.Count == 0)
                    Console.WriteLine("Никто в яму не попался.");
            
           
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
            try
            {

            
            if (Tools.Luck(20, randomNum, 100))
            {
                   
                    trapedOnes.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Внезапно начавшееся землятрясене изменило навегда ландшафт леса.\nВ яме оказалось {trapedOnes.Count} живых заложников.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    throw new EmptyPitException("Внезапно все проснулись. Никто никогда не видел ямы. Оказалось это был просто сон ...");
                  
                }
            else if (trapedOnes.Count > 0)
            {
                return HungerComes(trapedOnes);
            }

            else if (trapedOnes.Count <= 0)
            {
                throw new ArgumentNullException("Но никого не оказалось");
            }
           
            }
            catch (EmptyPitException ex)
            {
                Console.WriteLine(ex.Message,"Pit is a cake" );
            }
            return null; 
        }
        /// <summary>
        /// Returns the luckiest one after hunger 
        /// </summary>
        /// <param name="trapedOnes"></param>
        /// <returns></returns>
        internal static ILuckable HungerComes(List<ILuckable> trapedOnes)
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

        private static int TryLuck(List<ILuckable> trapedOnes)
        {
           return randomNum.Next(trapedOnes.Count);
        }

        /// <summary>
        /// End of story
        /// </summary>
        /// <param name="lastHero"></param>
        private static void DrozdHasCome(ILuckable lastHero)
    {
            Console.WriteLine("Через какое-то время к яме прилетел дрозд и стал вить гнездо. ");
            Console.WriteLine($"Обратился {lastHero.CharacterName} к нему \"Спаси меня, дрозд, а не то я твоих детей съем. \" ");
            if (lastHero.Luck(5, randomNum))
            {
                Console.WriteLine($"Дрозд решил все же спасти {lastHero.CharacterName}.\n Но злой {lastHero.CharacterName} продалжал угрожать птенцам,\n и лишь в обмен на еду соглашался пойти прочь.");
                if (lastHero.Luck(3, randomNum))
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
                    if (Tools.Luck(90, randomNum, 10))
                    {
                        throw new Exception("Внезапно все проснулись. Оказалось это был просто сон ...");
                    }
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

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
            Fox lis =  new Fox() { CharacterName = "Лис Хитрый" };
            Boar kaban = new Boar() { CharacterName = "Кабан" };
            Hare zayac = new Hare() { CharacterName = "Заяц" };
            Bear medved = new Bear() { CharacterName = "Медведь" };
            List<ILuckable> characters = new List<ILuckable>() { lis, kaban, zayac, medved };


            CloseApp closeApp = new CloseApp();
            var doesClosing = new DoesClosing();
          //  closeApp.closingAppEvent += Tools.CloseApp_closingApp;
            closeApp.closingAppEvent += doesClosing.OnProgramShutDown;
            closeApp.ClosingApp();

            try 
            {
                StoryTeller.EndlessStory(characters);
            }
            catch (EmptyPitException ex)
            {
                Console.WriteLine("Непредвиденная ошибка - пустая локация яма.");
                Console.WriteLine(ex.Message, ex.InnerException, ex.Data);
                Tools.WaitInput();
                StoryTeller.EndlessStory(characters);

            }
            catch (Exception ex) when (ex is EmptyPitException)
            {
                Console.WriteLine("Outer exception");
                Console.WriteLine(ex.Message, ex.InnerException, ex.StackTrace);
                Tools.WaitInput();
            }
            finally {
                Console.WriteLine("Кто-то сказочку сломал и об этом промолчал ...");
                Tools.WaitInput();

            }
               
        }

        
    }
}

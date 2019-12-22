using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale
{
    class Tools
    {
     public static   CloseApp closeApp = new CloseApp();
     static   DoesClosing doesClosing = new DoesClosing();
       
        internal static void CloseApp_closingApp()
        {
            Console.WriteLine("Delegate Cath`a");
         
           Environment.Exit(0);
            
        }

        public static void  WaitInput()
        {
            Console.WriteLine("Just waitipt");
            
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                closeApp.closingAppEvent += doesClosing.OnProgramShutDown;
                closeApp.ClosingApp(true);
             //   Environment.Exit(0);
            }
          
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

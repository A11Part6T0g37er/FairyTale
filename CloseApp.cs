using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyTale
{
    class CloseApp
    {
        public delegate void ClosingAppEventHandler(object source, EventArgs Args);
        public event ClosingAppEventHandler closingAppEvent;
       /// <summary>
       /// Publisher
       /// </summary>
        public void ClosingApp()
        {
            Console.WriteLine("Publisher");
            
            if ( Console.ReadKey().Key == ConsoleKey.Escape)
            { 
              Console.WriteLine("CConsiole is being terminated ...");
            closingAppEvent?.Invoke(this , EventArgs.Empty); // call event 
             //   Environment.Exit(0);
            }
            
        }
    }
}

using System;

namespace FairyTale
{
    public class DoesClosing
    {
       
            public void OnProgramShutDown(object source, EventArgs e)
            {
                Console.WriteLine("Is closing");
            Console.WriteLine("Delegate Cath`a");
            Environment.Exit(0);
            Console.ReadKey();
        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Interfaces.MainMenu interfacesMenu = new Interfaces.MainMenu();
            Console.WriteLine(interfacesMenu.GetType().Name);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~");
            interfacesMenu.Show();
            Console.ReadKey();
        }
    }
}

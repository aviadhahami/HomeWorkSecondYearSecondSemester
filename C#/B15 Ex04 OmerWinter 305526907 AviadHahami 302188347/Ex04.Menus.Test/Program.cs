using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");
            Console.ReadKey();
            Interfaces.MainMenu interfacesMenu = new Interfaces.MainMenu();
            Console.WriteLine(interfacesMenu.MethodsMenu);
            Console.ReadKey();
        }
    }
}

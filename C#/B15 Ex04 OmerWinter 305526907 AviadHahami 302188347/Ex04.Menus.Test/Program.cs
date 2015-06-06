using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display informatic message
            Console.WriteLine("Welcome, you're going to use interfaces based menue");
            Console.ReadLine();
            Console.Clear();

            // Initiate the interfaces menu
            //Interfaces.MainMenu interfacesMenu = new Interfaces.MainMenu();
            Ex04.Menus.Interfaces.MainMenu interfacesMain = new Interfaces.MainMenu("Main Menu");
            interfacesMain.Show();

            // Display informatic message
            Console.WriteLine("You're switching to Delegations based menues");
            Console.ReadLine();
        }
    }
}

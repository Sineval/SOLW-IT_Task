using System;
using Solwit_Task.Task_01;
using Solwit_Task.Task_02;
using Solwit_Task.Task_03;

namespace Solwit_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;

            do
            {
                Console.WriteLine("Zadania rekrutacyjne: ");
                Console.WriteLine("1. 'Serwis pojazdów'");
                Console.WriteLine("2. 'Książka telefoniczna'");
                Console.WriteLine("3. 'Aglorytm'\n");
                Console.WriteLine("4. Wyjście");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        ServiceCenter task1 = new ServiceCenter();
                        task1.RunTask();
                        break;
                    case "2":
                        Console.Clear();
                        PhoneBook task2 = new PhoneBook();
                        task2.Initialize();
                        task2.RunTask();
                        break;
                    case "3":
                        Console.Clear();
                        PowerCalc task3 = new PowerCalc();
                        task3.Initialize();
                        task3.RunTask();
                        break;
                    default:
                        Console.WriteLine("Opcja o podanym numerze nie istnieje.");
                        break;
                }
            } while (choice != "4");
        }
    }
}

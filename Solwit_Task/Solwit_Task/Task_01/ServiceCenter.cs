using System;

namespace Solwit_Task.Task_01
{
    public class ServiceCenter
    {
        CarServices cServices = new CarServices();
        MotorcycleServices mServices = new MotorcycleServices();

        string choice;
        
        public void RunTask()
        {
            do
            {
                Console.WriteLine("Witaj na stacji obsługi. Czym przyjechałeś?");
                Console.WriteLine("1. Samochód");
                Console.WriteLine("2. Motocykl");
                Console.WriteLine("3. Niczym :(");

                choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Wykonane usługi z pakietu 'Samochód': \n");
                        cServices.WlejPaliwo();
                        cServices.Zmien4Opony();
                        cServices.UmyjKola();
                        cServices.UmyjWnetrze();
                        Console.WriteLine("\nDziękujemy za skorzystanie z naszych usług.");
                        EndStuff();
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Wykonane usługi z pakietu 'Motocykl': \n");
                        mServices.WlejPaliwo();
                        mServices.Zmien2Opony();
                        mServices.UmyjKola();
                        Console.WriteLine("\nDziękujemy za skorzystanie z naszych usług.");
                        EndStuff();
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Opcja o podanym numerze nie istnieje.");
                        EndStuff();
                        break;
                }

            } while (choice != "3");

            Console.WriteLine();
            Console.WriteLine("Szerokiej drogi.");
            EndStuff();
        }

        private void EndStuff()
        {
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }
    }
}

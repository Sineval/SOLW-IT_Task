using System;
using System.Collections.Generic;

namespace Solwit_Task.Task_03
{
    public class PowerCalc
    {
        List<Variables> data = new List<Variables>();
        CalculatePower power = new CalculatePower();
        int index = 0;

        public void Initialize()
        {
            data.Clear();
            double[] theBases = { 2, 5, 3, 23, -2 };
            double[] theExponents = { 2, 4, 6, 582, 5 };

            for (int i = 0; i < theBases.Length; i++)
            {
                var temp = new Variables
                {
                    TheBase = theBases[i],
                    TheExponent = theExponents[i]
                };

                data.Add(temp);
            }
        }

        public void RunTask()
        {
            string choice;

            do
            {
                Console.WriteLine("Witaj w kalkulatorze potęg. Co chcesz zrobić?");
                Console.WriteLine("1. Ustaw dane");
                Console.WriteLine("2. Wybierz poprzedni zestaw danych");
                Console.WriteLine("3. Wybierz następny zestaw danych\n");
                Console.WriteLine("4. Oblicz potęgę 'rekurencyjnie'");
                Console.WriteLine("5. Oblicz potęgę 'iteracyjnie'");
                Console.WriteLine("6. Oblicz potęgę 'biblioteką Math'\n");
                Console.WriteLine("7. Wyjście");

                Console.WriteLine("\nAktualne dane wejściowe");
                Console.WriteLine("- Podstawa: " + data[index].TheBase);
                Console.WriteLine("- Wykładnik: " + data[index].TheExponent);

                choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        SetData();                       
                        break;
                    case "2":
                        SwitchActiveData("-");
                        break;
                    case "3":
                        SwitchActiveData("+");
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine(string.Format("Wynik obliczenia 'rekurencyjnego': {0}", power.CalculateRecursive(data[index].TheBase, data[index].TheExponent)));
                        Console.Write(string.Format("Czas potrzebny na wykonanie obliczenia: ~{0} ms", power.GetTime()));
                        EndStuff();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine(string.Format("Wynik obliczenia 'iteracyjnego': {0}", power.CalculateIterative(data[index].TheBase, data[index].TheExponent)));
                        Console.Write(string.Format("Czas potrzebny na wykonanie obliczenia: ~{0} ms", power.GetTime()));
                        EndStuff();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine(string.Format("Wynik obliczenia 'biblioteką Math': {0}", power.CalculateSmartly(data[index].TheBase, data[index].TheExponent)));
                        Console.Write(string.Format("Czas potrzebny na wykonanie obliczenia: ~{0} ms", power.GetTime()));
                        EndStuff();
                        break;
                    case "7":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opcja o podanym numerze nie istnieje.");
                        break;
                }

            } while (choice != "7");
        }

        private void SwitchActiveData(string move)
        {
            int tempIndex = index;
            
            if(move == "+")
            {
                tempIndex++;
                if (tempIndex < data.Count)
                {
                    index = tempIndex;
                    Console.Clear();
                    RunTask();
                }
                index = 0;
                Console.Clear();
                RunTask();
            }

            tempIndex--;

            if(tempIndex < 0)
            {
                index = data.Count - 1;
                Console.Clear();
                RunTask();
            }
            index = tempIndex;
            Console.Clear();
            RunTask();
        }

        private void SetData()
        {
            string choice;

            Console.Clear();

            Console.WriteLine("Możliwe opcje:");
            Console.WriteLine("1. Wyświetl zapisane zestawy danych");
            Console.WriteLine("2. Dodaj nowy zestaw danych");
            Console.WriteLine("3. Usuń zestaw danych");
            Console.WriteLine("4. Ustaw aktywne dane\n");
            Console.WriteLine("5. Powrót");

            choice = Console.ReadLine();

            do
            {
                switch (choice)
                {
                    case "1":
                        ShowData();
                        break;
                    case "2":
                        AddData();
                        SetData();
                        break;
                    case "3":
                        RemoveData();
                        SetData();
                        break;
                    case "4":
                        ActiveData();
                        SetData();
                        break;
                    case "5":
                        Console.Clear();
                        RunTask();
                        break;
                    default:
                        Console.WriteLine("Opcja o podanym numerze nie istnieje.");
                        break;
                }
            } while (choice != "5");

            EndStuff();
        }

        private void ShowData()
        {
            Console.Clear();

            Console.WriteLine("Zapisane zestawy danych\n");
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine("Zestaw #" + (i + 1));
                Console.WriteLine(string.Format("Podstawa: {0}", data[i].TheBase));
                Console.WriteLine(string.Format("Wykładnik: {0}\n", data[i].TheExponent));
            }
            EndStuff();
        }

        private void AddData()
        {
            Console.Clear();

            var temp = new Variables();
            Console.Write("Podaj podstawę: ");
            temp.TheBase = Convert.ToDouble(Console.ReadLine());
            Console.Write("Podaj wykładnik: ");
            temp.TheExponent = Convert.ToDouble(Console.ReadLine());

            data.Add(temp);

            Console.Clear();
        }

        private void RemoveData()
        {
            bool done = false;
            int tempIndex = 0;
            Console.Clear();

            ShowDataSimply();

            do
            {
                Console.Write("\nPodaj 'Index' zestawu danych do usunięcia: ");
                tempIndex = Convert.ToInt32(Console.ReadLine());
                if (IndexCheck(tempIndex))
                {
                    data.RemoveAt(tempIndex - 1);
                    Console.WriteLine("Zestaw danych został usunięty");
                    done = true;
                }

            } while (!done);
            
            EndStuff();
        }

        private void ActiveData()
        {
            bool done = false;
            int tempIndex = 0;

            Console.Clear();
            ShowDataSimply();
            
            do
            {
                Console.Write("\nPodaj 'Index' zestawu danych, które mają być aktywne: ");
                tempIndex = Convert.ToInt32(Console.ReadLine());
                if (IndexCheck(tempIndex))
                {
                    index = tempIndex - 1;
                    Console.WriteLine("Nowe dane zostały ustawione jako aktywne");
                    done = true;
                }

            } while (!done);
            
            EndStuff();
        }

        private bool IndexCheck(int tempIndex)
        {
            if (tempIndex > data.Count || tempIndex < 1)
            {
                Console.WriteLine("Nie ma takiego zestawu danych w bazie");
                return false;
            }
            return true;
        }

        private void ShowDataSimply()
        {
            Console.WriteLine("Zapisane zestawy danych\n");
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine(string.Format("Zestaw #{0}: Podstawa: {1}, Wykładnik: {2}", i + 1, data[i].TheBase, data[i].TheExponent));
            }
        }

        private void EndStuff()
        {
            Console.ReadKey();
            Console.Clear();
        }

        private struct Variables
        {
            public double TheBase { get; set; }
            public double TheExponent { get; set; }
        }
    }
}

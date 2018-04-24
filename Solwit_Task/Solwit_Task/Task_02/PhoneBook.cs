using System;
using System.Collections.Generic;
using System.Linq;

namespace Solwit_Task.Task_02
{
    public class PhoneBook
    {
        List<Osoba> phonebook = new List<Osoba>();

        public void Initialize()
        {
            phonebook.Clear();
            string[] names = { "Jan", "Kuba", "Anna", "Elżbieta", "Adam" };
            string[] lNames = { "Kowalski", "Nowakowski", "Maj", "Kowalczyk", "Gruz" };
            string[] numbers = { "212", "323", "444", "512", "612" };

            for (int i = 0; i < 5; i++)
            {
                var temp = new Osoba
                {
                    Name = names[i],
                    LName = lNames[i],
                    Number = numbers[i]
                };

                phonebook.Add(temp);
            }
        }

        public void RunTask()
        {
            string choice;

            do
            {
                Console.WriteLine("Witaj w książce telefonicznej. Co chcesz zrobić? ");
                Console.WriteLine("1. Wyświetl wszystkie rekordy");
                Console.WriteLine("2. Wyświetl dane rekordu po numerze");
                Console.WriteLine("3. Sortuj rekordy");
                Console.WriteLine("4. Dodaj rekord");
                Console.WriteLine("5. Usuń rekord\n");
                Console.WriteLine("6. Wyjście");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowRecords();
                        break;
                    case "2":
                        Console.Write("Podaj numer: ");
                        ShowSingleRecord(Console.ReadLine());
                        break;
                    case "3":
                        SortBy();
                        break;
                    case "4":
                        AddRecord();
                        break;
                    case "5":
                        RemoveRecord();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opcja o podanym numerze nie istnieje.");
                        break;
                }
            } while (choice != "6");
        }

        private void AddRecord()
        {
            Console.Clear();
            var temp = new Osoba();
            Console.Write("Podaj imię: ");
            temp.Name = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            temp.LName = Console.ReadLine();
            Console.Write("Podaj numer telefonu: ");
            temp.Number = Console.ReadLine();

            phonebook.Add(temp);
            Console.Clear();
        }

        private void RemoveRecord()
        {
            int index;
            int record;
            bool done = false;

            Console.Clear();
            Console.WriteLine("Lista rekordów (format: 'ID' | 'Imię' | 'Nazwisko' | 'Numer telefonu')\n");
            for (index = 0; index < phonebook.Count; index++)
            {
                Console.WriteLine(string.Format("{0} | {1} | {2} | {3}", index + 1, phonebook[index].Name, phonebook[index].LName, phonebook[index].Number));
            }
            Console.Write("\nPodaj 'ID' rekordu do usunięcia: ");
            record = Convert.ToInt32(Console.ReadLine());

            do
            {
                if (record > index || record < 1)
                {
                    Console.WriteLine("Nie ma takiego rekordu w bazie");
                    Console.Write("\nPodaj 'ID' rekordu do usunięcia: ");
                    record = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    phonebook.RemoveAt(record - 1);
                    Console.WriteLine("Rekord został usunięty");
                    done = true;
                }

            } while (!done);

            EndStuff();
        }
        
        private void ShowRecords()
        {
            Console.Clear();
            Console.WriteLine("Lista rekordów (format: 'ID' | 'Imię' | 'Nazwisko' | 'Numer telefonu')\n");
            for (int i = 0; i < phonebook.Count; i++)
            {
                Console.WriteLine(string.Format("{0} | {1} | {2} | {3}", i + 1, phonebook[i].Name, phonebook[i].LName, phonebook[i].Number));
            }
            EndStuff();
        }

        private void ShowSingleRecord(string byNumber)
        {
            Console.Clear();
            if(phonebook.Any(record => record.Number == byNumber))
            {
                var temp = phonebook.Find(record => record.Number == byNumber);
                Console.WriteLine(string.Format("Rekord odpowiadający numerowi '{0}' to: {1} {2}", byNumber, temp.Name, temp.LName));
            }
            else
            {
                Console.WriteLine(string.Format("W książce nie ma zapisanego rekordu odpowiadającemu podanemu numerowi."));
            }
            EndStuff();
        }

        private void Sorter(string asc_desc, string choice)
        {
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    if (asc_desc == "A")
                    {
                        phonebook.Sort((o1, o2) => o1.Name.CompareTo(o2.Name));
                        Console.Write("Rekordy zostały posortowane po 'Imię' zaczynając od 'A'\n");
                    }
                    else if (asc_desc == "Z")
                    {
                        phonebook.Sort((o1, o2) => o2.Name.CompareTo(o1.Name));
                        Console.Write("Rekordy zostały posortowane po 'Imię' zaczynając od 'Z'\n");
                    }
                    else
                    {
                        Console.Write("Nie ma takiej opcji");
                    }
                    break;
                case "2":
                    if (asc_desc == "A")
                    {
                        phonebook.Sort((l1, l2) => l1.LName.CompareTo(l2.LName));
                        Console.Write("Rekordy zostały posortowane po 'Nazwisko' zaczynając od 'A'\n");
                    }
                    else if (asc_desc == "Z")
                    {
                        phonebook.Sort((l1, l2) => l2.LName.CompareTo(l1.LName));
                        Console.Write("Rekordy zostały posortowane po 'Nazwisko' zaczynając od 'A'\n");
                    }
                    else
                    {
                        Console.Write("Nie ma takiej opcji");
                    }
                    break;
                default:
                    break;
            }
        }

        private void SortBy()
        {
            string choice;
            string asc_desc;
            Console.Clear();
            Console.WriteLine("Opcje sortowania:");
            Console.WriteLine("1. Sortowanie po 'Imie'");
            Console.WriteLine("2. Sortowanie po 'Nazwisko'\n");
            Console.WriteLine("3. Powrót");

            choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    Console.Write("\nCzy sortować od 'A' czy od 'Z'? ");
                    Sorter(Console.ReadLine(), choice);
                    break;
                case "2":
                    Console.Write("\nCzy sortować od 'A' czy od 'Z'? ");
                    Sorter(asc_desc = Console.ReadLine(), choice);
                    break;
                case "3":
                    Console.Clear();
                    RunTask();
                    break;
                default:
                    Console.WriteLine("Opcja o podanym numerze nie istnieje");
                    EndStuff();
                    SortBy();
                    break;
            }
            EndStuff();
        }

        private void EndStuff()
        {
            Console.ReadKey();
            Console.Clear();
        }

        private struct Osoba
        {
            public string Name { get; set; }
            public string LName { get; set; }
            public string Number { get; set; }
        }
    }
}

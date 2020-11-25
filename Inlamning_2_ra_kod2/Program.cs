using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning_2_ra_kod2
{
    /* CLASS: Person   
     * PURPOSE: Used for making identities which is name, address, telephone, and email.
     */
    class Person
    {
        public string name, address, telephone, email;
        public Person(string N, string A, string T, string E)
        {
            name = N; address = A; telephone = T; email = E;
        }
        /* METHOD: Print
         * PURPOSE: Prints name, address, telephone, and email. 
         * PARAMETERS: --   
         * RETURN VALUE: Returns 1 line of Person list 
         */
        public void Print()
        {
            Console.WriteLine($"{name}, {address}, {telephone}, {email}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> Dict = new List<Person>();

            Console.Write("Laddar adresslistan ... ");
            using (StreamReader fileStream = new StreamReader(@"C:\Users\Arvid\address.lis"))
            {
                while (fileStream.Peek() >= 0)
                {
                    string line = fileStream.ReadLine();
                    // Console.WriteLine(line);
                    string[] word = line.Split('#');
                    // Console.WriteLine("{0}, {1}, {2}, {3}", word[0], word[1], word[2], word[3]);
                    Person P = new Person(word[0], word[1], word[2], word[3]);
                    Dict.Add(P);
                }
            }
            Console.WriteLine("klart!");
            Console.WriteLine("Hej och välkommen till adresslistan");
            Console.WriteLine("Skriv 'sluta' för att sluta!");
            string command;
            int found;

            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                switch (command)
                {
                    case "sluta":
                        Console.WriteLine("Hej då!");
                        break;
                    case "ny":
                        Dict.AddRange(NewPerson());
                        break;
                    case "ta bort":
                        Console.Write("Vem vill du ta bort (ange namn): ");
                        string requestToRemove = Console.ReadLine();
                        found = -1;
                        for (int i = 0; i < Dict.Count(); i++)
                        {
                            if (Dict[i].name == requestToRemove) found = i;
                        }
                        switch (found)
                        {
                            case -1:
                                Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", requestToRemove);
                                break;
                            default:
                                Dict.RemoveAt(found);
                                break;
                        }
                        break;
                    case "visa":
                        PrintA(Dict);
                        break;
                    case "ändra":///////////////////////////////////////////////////////////////// TAG BORT ALLA IF ELSE-- titta på upgift papret
                        PrintA(Dict);
                        Console.Write("Vem vill du ändra (ange namn): ");
                        string changeRequest = Console.ReadLine();
                        found = -1;
                        for (int i = 0; i < Dict.Count(); i++)
                        {
                            if (Dict[i].name == changeRequest) found = i;
                        }
                        switch (found)
                        {
                            case -1:
                                Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", changeRequest);
                                break;
                            default:
                                Console.Write("Vad vill du ändra (namn, adress, telefon eller email): ");
                                string feldToChange = Console.ReadLine();
                                Console.Write("Vad vill du ändra {0} på {1} till: ", feldToChange, changeRequest);
                                string nyttVärde = Console.ReadLine();
                                switch (feldToChange)
                                {
                                    case "namn": Dict[found].name = nyttVärde; break;
                                    case "adress": Dict[found].address = nyttVärde; break;
                                    case "telefon": Dict[found].telephone = nyttVärde; break;
                                    case "email": Dict[found].email = nyttVärde; break;
                                    default: break;
                                }
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Okänt kommando: {0}", command);
                        break;
                }
            } while (command != "sluta");
        }
        /* METHOD: PrintA (static)   
         * PURPOSE: Prints out the contens of List<Person> Dict on Main. 
         * PARAMETERS: cycles through List<Person> Dict from main   
         * RETURN VALUE: Returns the whole list of person 
         */
        private static void PrintA(List<Person> Dict)
        {
            for (int i = 0; i < Dict.Count(); i++)
            {
                Person P = Dict[i];
                P.Print();
            }
        }
        /* METHOD: NewPerson (static)   
         * PURPOSE: Adds new Person to address list on main.  
         * PARAMETERS: Gets name, address, telephone, email, and adds it to newP   
         * RETURN VALUE: returns a new Person's name, address, telephone, email in form of a List   
         */
        private static List<Person> NewPerson()
        {
            string[] nATE = new string[4]; // n[0] = name, A[1] = address, T[2] = telephone, E[3] = email
            List<Person> Dict = new List<Person>();
            Console.WriteLine("Lägger till ny person");
            Console.Write("  1. ange namn:    ");
            nATE[0] = Console.ReadLine();
            Console.Write("  2. ange adress:  ");
            nATE[1] = Console.ReadLine();
            Console.Write("  3. ange telefon: ");
            nATE[2] = Console.ReadLine();
            Console.Write("  4. ange email:   ");
            nATE[3] = Console.ReadLine();
            Person newP = new Person(nATE[0], nATE[1], nATE[2], nATE[3]);
            Dict.Add(newP);
            return Dict;
        }
    }
}
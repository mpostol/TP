using LinqToObjectsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjectsApp
{
    class LinqToObjectsConsoleApp
    {
        static DataService service = new DataService();

        static void Main(string[] args)
        {
            PrepareData();

            Person[] all = service.GetAllPersons();
            Display("All persons", all);

            Console.WriteLine();

            const string lastName = "Person";
            const int minAge = 25;

            Display("With last name '" + lastName + "' / ForEach", service.FilterPersonsByLastName_ForEach(lastName));
            Display("With last name '" + lastName + "' / Extension", service.FilterPersonsByLastName_ExtensionMethod(lastName));
            Display("With last name '" + lastName + "' / LINQ", service.FilterPersonsByLastName(lastName));

            Console.WriteLine();

            Display("After finishing studies", service.FilterPersonsByMinAge(minAge));

            Console.ReadLine();
        }

        static void Display(string title, IEnumerable<Person> data)
        {
            Console.WriteLine("*** {0} ***", title);
            foreach (Person p in data)
            {
                Console.WriteLine("Person: {0} {1}, age {2}", p.FirstName, p.LastName, p.Age);
            }
        }

        static void PrepareData()
        {
            service.AddPerson(new Person("First", "Person", 20));
            service.AddPerson(new Person("Second", "Person", 30));
            service.AddPerson(new Person("Mister", "Clever", 42));
        }
    }
}

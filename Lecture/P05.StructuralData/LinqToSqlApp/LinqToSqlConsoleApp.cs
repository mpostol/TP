//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using LinqToSqlLib;
using System;
using System.Collections.Generic;

namespace LinqToSqlApp
{
  internal class LinqToSqlConsoleApp
  {
    private static void Main(string[] args)
    {
      //// Connection string defined in LinqToSqlApp project settings.
      //string connectionString = global::LinqToSqlApp.Properties.Settings.Default.PersonDataConnectionString;
      //using (PersonService service = new PersonService(connectionString))
      //{
      //  IEnumerable<Person> all = service.GetAllPersons();
      //  Display("Everyone", all);
      //  Console.WriteLine();
      //  const string lastName = "Kowalski";
      //  const int minAge = 25;
      //  const int change = 11;
      //  Display("With last name '" + lastName + "'", service.FilterPersonsByLastName(lastName));
      //  Console.WriteLine();
      //  Display("After finishing studies", service.FilterPersonsByMinAge(minAge));
      //  Display("Forward " + change + " years", service.ChangeAgeThenFilterPersonsByMinAge(change, minAge));
      //  Display("And back " + change + " years", service.ChangeAgeThenFilterPersonsByMinAge(-change, minAge));
      //}
      //Console.ReadLine();
    }
    private static void Display(string title, IEnumerable<Person> data)
    {
      Console.WriteLine("*** {0} ***", title);
      foreach (Person p in data)
        Console.WriteLine("Person: {0} {1}, age {2}", p.FirstName, p.LastName, p.Age);
    }
  }
}

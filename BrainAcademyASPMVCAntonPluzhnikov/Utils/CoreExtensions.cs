using BrainAcademyASPMVCAntonPluzhnikov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrainAcademyASPMVCAntonPluzhnikov.Utils
{
    public static class CoreExtensions
    {
        public static void Add(this IList<Person> Persons, string name) {
            int id = 1;
            if (Persons!=null && Persons.Count > 0)
            {
                id = Persons.Max(x => x.Id)+1;
            }
            Persons.Add(new Person { Name = name, Id = id });
        }

        public static void Add(this IList<Book> Books, string autor, string title, string isbn) {
            int id = 1;
            if (Books != null && Books.Count > 0)
            {
                id = Books.Max(x => x.Id) + 1;
            }
            Books.Add(new Book { Id = id, Author = autor, Title = title, ISBN = isbn });
        }
    }
}
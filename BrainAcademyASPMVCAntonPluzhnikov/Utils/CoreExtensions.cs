﻿using BrainAcademyASPMVCAntonPluzhnikov.Models;
using DataObjectsLayer.Models;
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
            Books.Add(new Book { Id = id, Title = title, ISBN = isbn });
        }

        public static void Add(this IList<Book> Books, Library library) {
            int id = 1;
            if (Books != null && Books.Count > 0)
            {
                id = Books.Max(x => x.Id) + 1;
            }
            Books.Add(library.Book);
            //Books.Add (new Book { Id = id, Title = title, ISBN = isbn });
        }


        public static string GetHitsStatistics(this List<Hit> hits) {
            var statistic = string.Empty;

            var dt = new Google.DataTable.Net.Wrapper.DataTable();
            dt.AddColumn(new Google.DataTable.Net.Wrapper.Column(Google.DataTable.Net.Wrapper.ColumnType.String, "Date", "Date"));
            dt.AddColumn(new Google.DataTable.Net.Wrapper.Column(Google.DataTable.Net.Wrapper.ColumnType.Number, "Count", "Count"));

            foreach (var hit in hits)
            {
                var row = dt.NewRow();
                row
                    .AddCellRange(new Google.DataTable.Net.Wrapper.Cell[] 
                    {
                        new Google.DataTable.Net.Wrapper.Cell(hit.Date),
                        new Google.DataTable.Net.Wrapper.Cell(hit.Count)
                    }
                    );
                dt.AddRow(row);
            }

            statistic = dt.GetJson();

            return statistic;
        }
        
                
    }
}
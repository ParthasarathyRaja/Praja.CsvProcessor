using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Praja.CsvProcessor.Library;
using Praja.CsvProcessor.Models;

namespace Praja.CsvProcessor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           Database.SetInitializer<CsvContext>(new CsvEntityMapper());
           CsvContext context = new CsvContext();
           Console.WriteLine("Please wait while PrajaCSVDB is created and populated");
           context.Database.Initialize(true);
           Console.WriteLine("Complete! Press any key to exit.");
           Console.ReadLine();
        }
    }
}

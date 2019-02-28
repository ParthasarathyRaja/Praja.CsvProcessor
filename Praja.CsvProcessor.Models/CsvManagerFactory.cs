using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Praja.CsvProcessor.Library;

namespace Praja.CsvProcessor.Models
{
    //this is a factory class which generates classes for csv managers
    class CsvManagerFactory
    {
        public static CsvManager<IRESSSuperTransaction> GetIRESSManager()
        {
            //NOTE: For easy debugging for the reviewer, I have put the CSV file inside the bin folder
            return new CsvManager<IRESSSuperTransaction>("IRESSSuperTransactions.csv", true);
        }

        public static CsvManager<AustralianSuperTransaction> GetAustralianSuperManager()
        {
            //NOTE: For easy debugging for the reviewer, I have put the CSV file inside the bin folder
            return new CsvManager<AustralianSuperTransaction>("AustralianSuperTransactions.csv", true);
        }
        public static CsvManager<ClassSuperTransaction> GetClassSuperManager()
        {
            //NOTE: For easy debugging for the reviewer, I have put the CSV file inside the bin folder
            return new CsvManager<ClassSuperTransaction>(@"c:\temp\ClassSuperTransactions.csv", true);
        }
    }
}

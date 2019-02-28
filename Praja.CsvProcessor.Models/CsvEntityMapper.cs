using Praja.CsvProcessor.Library;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Praja.CsvProcessor.Models
{
    
    /// <summary>
    /// This class maps diffent types of CSV file with different entity types
    /// </summary>
    public class CsvEntityMapper : DropCreateDatabaseIfModelChanges<CsvContext>
    {
        private static List<IRESSSuperTransaction> LoadIRESSSuperTransaction()
        {
            //Inversion of control (IOC): Responsibility of creating CsvManager instance has been moved to factory. 
            CsvManager<IRESSSuperTransaction> IRESSManager = CsvManagerFactory.GetIRESSManager();
            IRESSManager.SetField(x=> x.MemberId,0);
            IRESSManager.SetField(x => x.CustomerName, 1);
            IRESSManager.SetField(x => x.FundABN, 2);
            IRESSManager.SetField(x => x.Contribution, 3);
            IRESSManager.SetField(x => x.ContributionDate, 4);
            IRESSManager.SetField(x => x.FundSPINorUSI, 5);
            var iressResult = IRESSManager.GetObjectList();

            return iressResult;
        }

        private static List<AustralianSuperTransaction> LoadAustralianSuperTransactions()
        {
            //Inversion of control (IOC): Responsibility of creating CsvManager instance has been moved to factory. 
            CsvManager<AustralianSuperTransaction> ASuperManager = CsvManagerFactory.GetAustralianSuperManager();
            ASuperManager.SetField(x => x.MemberId, 0);
            ASuperManager.SetField(x => x.CustomerName, 1);
            ASuperManager.SetField(x => x.FundABN, 2);
            ASuperManager.SetField(x => x.Contribution, 3);
            ASuperManager.SetField(x => x.ContributionDate, 4);
            ASuperManager.SetField(x => x.FundSPINorUSI, 5);
            List<AustralianSuperTransaction> aSuperResult = ASuperManager.GetObjectList();

            return aSuperResult;
        }

        private static List<ClassSuperTransaction> LoadClassSuperTransactions()
        {
            //Inversion of control (IOC): Responsibility of creating CsvManager instance has been moved to factory. 
            CsvManager<ClassSuperTransaction> classManager = CsvManagerFactory.GetClassSuperManager();
            classManager.SetField(x => x.MemberId, 0);
            classManager.SetField(x => x.CustomerName, 1);
            classManager.SetField(x => x.FundABN, 2);
            classManager.SetField(x => x.Contribution, 3);
            classManager.SetField(x => x.ContributionDate, 4);
            classManager.SetField(x => x.FundSPINorUSI, 5);
            List<ClassSuperTransaction> classResult = classManager.GetObjectList();

            return classResult;
        }


        protected override void Seed(CsvContext context)
        {
            var iressRecords = LoadIRESSSuperTransaction();
            iressRecords.ForEach(iress => context.IRESSSuperTransactions.Add(iress));
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            

            var ausSuperRecords = LoadAustralianSuperTransactions();
            ausSuperRecords.ForEach(aussuper => context.AustralianSuperTransactions.Add(aussuper));
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            var classSuperRecords = LoadClassSuperTransactions();
            classSuperRecords.ForEach(classsuper => context.ClassSuperTransactions.Add(classsuper));
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}

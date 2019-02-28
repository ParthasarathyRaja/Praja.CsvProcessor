using System;

namespace Praja.CsvProcessor.Models
{
    interface ISuperTransaction
    {
        int Id { get; set; }
        int MemberId { get; set; }
        string CustomerName { get; set; }
        string FundABN { get; set; }
        decimal Contribution { get; set; }
        DateTime ContributionDate { get; set; }
        string FundSPINorUSI { get; set; }
    }
}

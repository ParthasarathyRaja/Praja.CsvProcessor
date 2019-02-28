using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Praja.CsvProcessor.Models
{
    public class AustralianSuperTransaction : ISuperTransaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string CustomerName { get; set; }
        public string FundABN { get; set; }
        public decimal Contribution { get; set; }
        public DateTime ContributionDate { get; set; }
        public string FundSPINorUSI { get; set; }
    }
}

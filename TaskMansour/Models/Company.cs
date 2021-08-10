using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskMansour.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        public int CompanySEQ { get; set; }
        [ForeignKey("SalesRep")]
        public int SalesRepID { get; set; }
        public SalesRep SalesRep { get; set; }
    }
}

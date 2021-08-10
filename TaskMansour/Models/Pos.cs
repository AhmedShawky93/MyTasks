using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskMansour.Models
{
    public class Pos
    {
        [Key]
        public int? PosID { get; set; }
        [Required]
        [Display(Name = "pos Name")]
        public string PosName { get; set; }
        [Required]
        public string PosCode { get; set; }
        public DateTime VisitStart { get; set; }
        public DateTime VisitEnd { get; set; }
        [ForeignKey("SalesRep")]
        public int SalesRepId { get; set; }
        public SalesRep SalesRep { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskMansour.Models
{
    public class SalesRep
    {
        [Key]
        public int SalesRepID { get; set; }
        [Required]
        [Display(Name = "Sales_Rep Name")]
        public string SalesRepName { get; set; }
        public virtual ICollection<Pos> pos { get; set; } = new HashSet<Pos>();
        public virtual ICollection<Company> Companies { get; set; } = new HashSet<Company>();

    }
}

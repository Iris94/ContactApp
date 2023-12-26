using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactApp.Models
{
    public class StateDb
    {
        [Key]
        public int StateID { get; set; }
        public string? StateName { get; set; }


        public virtual ICollection<CityDb>? Cities { get; set; }
    }
}

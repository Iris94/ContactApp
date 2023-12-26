using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactApp.Models
{
    public class CityDb
    {
        [Key]
        public int CityID { get; set; }
        public string? CityName { get; set; }

        
        public int StateID { get; set; }
        [ForeignKey("StateID")]
        public StateDb? StateDb { get; set; }
    }
}

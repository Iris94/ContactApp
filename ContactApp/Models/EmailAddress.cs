using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactApp.Models
{
    public class EmailAddress
    {
        [Key]
        public int EmailID { get; set; }
        public string? Email { get; set; }

        
        public int PersonID { get; set; }
        [ForeignKey("PersonID")]
        public Person? Person { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactApp.Models
{
    public class PhoneNumber
    {
        [Key]
        public int PhoneID { get; set; }
        public string? Phone {  get; set; }


        public int PersonID { get; set; }
        [ForeignKey("PersonID")]
        public Person? Person { get; set; }
    }
}

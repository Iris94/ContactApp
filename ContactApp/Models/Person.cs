using System.ComponentModel.DataAnnotations;

namespace ContactApp.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Sex")]
        public Gender Sex { get; set; }

        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }




        [Display(Name = "Phone Numbers")]
        public virtual List<PhoneNumber> PhoneNumbers { get; set; }

        [Display(Name = "Email Addresses")]
        public virtual List<EmailAddress> EmailAddresses { get; set; }

    }


    public enum Gender
    {
        Male,
        Female
    }
}

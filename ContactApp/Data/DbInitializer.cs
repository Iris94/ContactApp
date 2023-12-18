using ContactApp.Models;


namespace ContactApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ContactContext context)
        {
            context.Database.EnsureCreated();
            if (context.Persons.Any())
            {
                return;
            }

            var persons = new Person[]
            {
                new Person
                {
                    FirstName = "Harry",
                    LastName = "Potter",
                    Sex = Gender.Male,
                    State = "England",
                    City = "London",
                    Birthday = DateTime.Parse("1991-08-09"),
                    PhoneNumbers = new List<PhoneNumber>
                    {
                        new PhoneNumber {Phone = "034/235/123"},
                        new PhoneNumber {Phone = "033/111/999"}
                    },
                    EmailAddresses = new List<EmailAddress>
                    {
                        new EmailAddress {Email = "harry@hogwarts.com"}
                    }
                },
                new Person
                {
                    FirstName = "Luke",
                    LastName = "Skywalker",
                    Sex = Gender.Male,
                    State = "England",
                    City = "London",
                    Birthday = DateTime.Parse("1972-05-21"),
                    PhoneNumbers = new List<PhoneNumber>
                    {
                        new PhoneNumber {Phone = "034/235/123"}
                    },
                    EmailAddresses = new List<EmailAddress>
                    {
                        new EmailAddress {Email = "luke@force.com"},
                        new EmailAddress {Email = "lukeSky@jedi.com"}
                    }
                },
                new Person
                {
                    FirstName = "Lara",
                    LastName = "Croft",
                    Sex = Gender.Female,
                    State = "England",
                    City = "London",
                    Birthday = DateTime.Parse("1981-02-01"),
                    PhoneNumbers = new List<PhoneNumber>
                    {
                        new PhoneNumber {Phone = "034/235/123"}
                    },
                    EmailAddresses = new List<EmailAddress>
                    {
                        new EmailAddress {Email = "lara@croftestate.com"}
                    }
                },
                new Person
                {
                    FirstName = "Frodo",
                    LastName = "Baggins",
                    Sex = Gender.Male,
                    State = "England",
                    City = "London",
                    Birthday = DateTime.Parse("2000-04-02"),
                    PhoneNumbers = new List<PhoneNumber>
                    {
                        new PhoneNumber {Phone = "066/619/619"}
                    },
                    EmailAddresses = new List<EmailAddress>
                    {
                        new EmailAddress {Email = "ringBearer@shire.com"}
                    }
                }
            };
            foreach (Person p in persons)
            {
                context.Persons.Add(p);
            }
            context.SaveChanges();
        }
    }
}


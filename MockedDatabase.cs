using AssignmentForKYC360.Models;

namespace AssignmentForKYC360
{
    public class MockedDatabase
    {
        private List<Entity> entities;

        public MockedDatabase()
        {
            entities =
            [
                new Entity
                {
                    Id = "1",
                    Names = [new Name { FirstName = "reshma", Surname = "salake" }],
                    Addresses = [new Address { AddressLine = "warje", City = "pune", Country = "India" }],
                    Dates = [new Date { DateType="dob",DateValue=DateTime.Parse("2001-11-20 15:30:00") }],
                    Gender="Female"
                },

                 new Entity
                {
                    Id = "2",
                    Names = [new Name { FirstName = "ved", Surname = "kandekar" }],
                    Addresses = [new Address { AddressLine = "Kothrud", City = "Pune", Country = "India" }],
                    Dates = [new Date { DateType="dob",DateValue=DateTime.Parse("2001-03-16 15:30:00") }],
                    Gender="Female"
                 },

                new Entity
                {
                    Id = "3",
                    Names = [new Name { FirstName = "Harsh", Surname = "kandekar" }],
                    Addresses = [new Address { AddressLine = "Nagar", City = "A.Nagar", Country = "India" }],
                    Dates = [new Date { DateType="dob",DateValue=DateTime.Parse("2006-03-16 15:30:00") }],
                    Gender="Male"
                },
                 new Entity
                {
                    Id = "4",
                    Names = [new Name { FirstName = "Pratik", Surname = "Yelwande" }],
                    Addresses = [new Address { AddressLine = "Karve Nagar", City = "Pune", Country = "India" }],
                    Dates = [new Date { DateType="dob",DateValue=DateTime.Parse("1999-03-16 15:30:00") }],
                    Gender="Male"
                },
                 new Entity
                {
                    Id = "5",
                    Names = [new Name { FirstName = "Om", Surname = "Wakhare" }],
                    Addresses = [new Address { AddressLine = "Karve Nagar", City = "Pune", Country = "India" }],
                    Dates = [new Date { DateType="dob",DateValue=DateTime.Parse("2001-03-16 15:30:00") }],
                    Gender="Male"
                },
            ];

        }

        public IEnumerable<Entity> GetAllEntities()
        {
            return entities;
        }

        public Entity GetEntityById(string id)
        {
            return entities.Find(e => e.Id == id);
        }
    }
}
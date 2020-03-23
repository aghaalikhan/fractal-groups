using System;

namespace FractalGroupsApi.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset CreatedDate { get; set; }        
        public PersonGroup PersonGroup { get; set; }
    }
}

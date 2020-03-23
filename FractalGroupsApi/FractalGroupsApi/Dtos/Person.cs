using System;
using System.ComponentModel.DataAnnotations;

namespace FractalGroupsApi.Dtos
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int GroupId { get; set; }
        
        public DateTimeOffset CreatedDate { get; set; }
    }
}

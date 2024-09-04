using System;
using System.ComponentModel.DataAnnotations;

namespace DbProject.Models
{
    public class CustomPerson
    {
        [Key]
        public int CustomPersonID { get; set; }

        [StringLength(8, ErrorMessage = "Title cannot be longer than 8 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        public string LastName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int EmailPromotion { get; set; }
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
    }
}
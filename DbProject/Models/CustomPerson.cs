using System;
using System.ComponentModel.DataAnnotations;

namespace DbProject.Models
{
    public class CustomPerson
    {
        [Key]
        public int CustomPersonID { get; set; }  // New primary key instead of BusinessEntityID

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int EmailPromotion { get; set; }
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
    }
}
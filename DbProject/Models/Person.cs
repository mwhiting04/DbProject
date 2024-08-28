//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace DbProject.Models
//{
//    public class Person
//    {
//        [Key, ForeignKey("BusinessEntity")]
//        public int BusinessEntityID { get; set; }

//        public string Title { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public DateTime ModifiedDate { get; set; }
//        public int EmailPromotion { get; set; }
//        public string PersonType { get; set; }
//        public bool NameStyle { get; set; }


//        // Navigation property
//        public virtual BusinessEntity BusinessEntity { get; set; }
//    }

//}

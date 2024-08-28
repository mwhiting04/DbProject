//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace DbProject.Models
//{
//    public class EmailAddressModel
//    {
//        [Key, Column(Order = 0)]
//        public int EmailAddressID { get; set; }

//        [Key, Column(Order = 1)]
//        public int BusinessEntityID { get; set; }

//        [ForeignKey("BusinessEntityID")]
//        public virtual Person Person { get; set; }

//        [ForeignKey("BusinessEntityID")]
//        public virtual BusinessEntity BusinessEntity { get; set; }


//        public string EmailAddress { get; set; }
//    }

//}
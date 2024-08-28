////using System;
////using System.Collections.Generic;
////using System.ComponentModel.DataAnnotations;
////using System.ComponentModel.DataAnnotations.Schema;

////namespace DbProject.Models
////{
////    public class BusinessEntity
////    {
////        [Key]
////        public int BusinessEntityID { get; set; }

////        public virtual Person Person { get; set; }


////    }
//    //public class BusinessEntityAddress
//    //{
//    //    [Key]
//    //    public int BusinessEntityID { get; set; }
//    //    public int AddressID { get; set; }
//    //    public int AddressTypeID { get; set; }
//    //    public DateTime ModifiedDate { get; set; }

//    //    // Navigation property
//    //    [ForeignKey("BusinessEntityID")]
//    //    public virtual BusinessEntity BusinessEntity { get; set; }
//    //}

//    //public class BusinessEntityContact
//    //{
//    //    [Key]
//    //    public int BusinessEntityID { get; set; }
//    //    public int ContactTypeID { get; set; }
//    //    public int PersonID { get; set; }
//    //    public DateTime ModifiedDate { get; set; }

//    //    // Navigation property
//    //    [ForeignKey("BusinessEntityID")]
//    //    public virtual BusinessEntity BusinessEntity { get; set; }
//    //}

//    //public class Store
//    //{
//    //    [Key]
//    //    public int BusinessEntityID { get; set; }
//    //    public string Name { get; set; }
//    //    public int SalesPersonID { get; set; }
//    //    public DateTime ModifiedDate { get; set; }

//    //    // Navigation property
//    //    [ForeignKey("BusinessEntityID")]
//    //    public virtual BusinessEntity BusinessEntity { get; set; }
//    //}

//    //public class Vendor
//    //{
//    //    [Key]
//    //    public int BusinessEntityID { get; set; }
//    //    public string AccountNumber { get; set; }
//    //    public string Name { get; set; }
//    //    public DateTime ModifiedDate { get; set; }

//    //    // Navigation property
//    //    [ForeignKey("BusinessEntityID")]
//    //    public virtual BusinessEntity BusinessEntity { get; set; }

//    //}
//}
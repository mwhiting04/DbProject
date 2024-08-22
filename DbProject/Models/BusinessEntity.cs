using System.ComponentModel.DataAnnotations;

namespace DbProject.Models
{
    public class BusinessEntity
    {
        [Key]
        public int BusinessEntityID { get; set; }

        public virtual Person Person { get; set; }

        //public virtual ICollection<EmailAddressModel> EmailAddresses { get; set; }
    }

}
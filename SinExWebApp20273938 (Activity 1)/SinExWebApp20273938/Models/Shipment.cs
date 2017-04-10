using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinExWebApp20273938.Models
{
    [Table("Shipment")]
    public class Shipment
    {   
        // 11 attributes
        [Key]
        public virtual int WaybillId { get; set; }
        public virtual string ReferenceNumber { get; set; }     //this attribute is not displayed in the webpage but needed for data retrieval.
        public virtual string ServiceType { get; set; }
        public virtual DateTime ShippedDate { get; set; }
        public virtual DateTime DeliveredDate { get; set; }
        public virtual string RecipientName { get; set; }
        public virtual int NumberOfPackages { get; set; }
        public virtual string Origin { get; set; }
        public virtual string Destination { get; set; }
        public virtual string Status { get; set; }           //this attribute is not displayed in the webpage but needed for data retrieval.

        // public virtual int ShippingAccountId { get; set; }

            //lab06 part 1
        //Navigation property to Shipment. 1 on the ShippingAccount side and N on the Shipment side
        // Foreign key references ShippingAccount.
        //[ForeignKey("ShippingAccount")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int ShippingAccountId { get; set; }
        //Navigation property to ShippingAccount. 1 on the ShippingAccount side and N on the Shipment side
        public virtual ShippingAccount ShippingAccount { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinExWebApp20273938.Models
{
    [Table("ServiceType")]
    public class ServiceType
    {
        public virtual int ServiceTypeID { get; set; }
        public virtual string Type { get; set; }
        public virtual string CutoffTime { get; set; }
        public virtual string DeliveryTime { get; set; }
        //Navigation property to ServicePackageFee.
        public virtual ICollection<ServicePackageFee> ServicePackageFees { get; set; }
    }
}
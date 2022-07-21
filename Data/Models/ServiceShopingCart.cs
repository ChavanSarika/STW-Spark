using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace  STW_Spark.Data.Models
{
    public class ServiceShopingCart
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ServiceTypeId { get; set; }

        [ForeignKey("CarId")]
        public Car car { get; set; }
        [ForeignKey("ServiceTypeId ")]
        public ServiceType serviceType { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  STW_Spark.Data.Models
{
    public class SerivceCarVM
    {
        public Car car { get; set; }
        public ServiceHeader serviceHeader { get; set; }
        public ServiceDetails serviceDetails { get; set; }

        public List<ServiceType> serviceTypes { get; set; }
        public List<ServiceShopingCart> serviceShopingCarts { get; set; }
    }
}

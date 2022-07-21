using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  STW_Spark.Data.Models
{
    public class CarsCustomerVM
    {
        public ApplicationUser user { get; set; }
        public IEnumerable<Car> cars { get; set; } 
    }
}

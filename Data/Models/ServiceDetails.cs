using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace  STW_Spark.Data.Models
{
    public class ServiceDetails
    {
        public int Id { get; set; }
        public int ServiceheaderId { get; set; }
        [ForeignKey("ServiceheaderId")]
        public ServiceHeader serviceHeader { get; set; }
        [Display(Name="Service")]
        public int ServiceTypeId { get; set; }
        [ForeignKey("ServiceTypeId")]
        public ServiceType serviceType { get; set; }

        public double ServicePrice { get; set; }
        public string ServiceName { get; set; }
    }
}

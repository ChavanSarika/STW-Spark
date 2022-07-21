using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace  STW_Spark.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public double Miles { get; set; }

        public string Style { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser user { get; set; }

    }
}

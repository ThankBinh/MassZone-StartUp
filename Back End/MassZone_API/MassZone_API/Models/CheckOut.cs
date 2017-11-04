using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassZone_API.Models
{
    public class CheckOut
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ckId { get; set; }
        public int quantity { get; set; }
        [DataType(DataType.Date)]
        public DateTime ckTime { get; set; }
        public int status { get; set; }

        
        public int? userId { get; set; }
        [ForeignKey("userId")]
        public virtual User Users { get; set; }
        public int? proId { get; set; }
        [ForeignKey("proId")]
        public virtual Product Products { get; set; }
    }
}
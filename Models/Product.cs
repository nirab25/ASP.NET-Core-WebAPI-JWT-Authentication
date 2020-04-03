using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreJWTAuth.Models
{
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}

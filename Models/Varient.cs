using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeConService.Models
{
    public class Varient
    {
        [Key]
        public string OVarient { get; set; }
        [Required]
        public bool IsTrue { get; set; }
    }
}

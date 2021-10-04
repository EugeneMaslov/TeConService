using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeConService.Models
{
    public class Varient
    {
        [Key]
        public string OVarient { get; set; }
        public bool IsTrue { get; set; }
    }
}

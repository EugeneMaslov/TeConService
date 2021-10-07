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
        public int Id { get; set; }
        public string OVarient { get; set; }
        public bool IsTrue { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}

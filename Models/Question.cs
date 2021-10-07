using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
namespace TeConService.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OQuestion { get; set; }
        public int? TestId { get; set; }
        public Test Test { get; set; }
    }
}

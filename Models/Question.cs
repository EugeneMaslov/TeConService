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
        public int Id { get; set; }
        public string OQuestion { get; set; }
        public List<Varient> Varient { get; set; }
        public int TestId { get; set; }
        public virtual Test Test { get; set; }
    }
}

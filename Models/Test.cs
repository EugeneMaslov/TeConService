using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace TeConService.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public List<Result> Results { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using TeConService.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeConService.Models
{
    [Keyless]
    public class Tests
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public ObservableCollection<QuestionViewModel> Questions { get; set; }
        [NotMapped]
        public QuestionViewModel questionViewModel { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

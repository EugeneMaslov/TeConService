using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using TeConService.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeConService.Models
{
    public class Question
    {
        [Key]
        public string OQuestion { get; set; }
        [NotMapped]
        public ObservableCollection<VarientViewModel> Varients { get; set; }
        [NotMapped]
        public VarientViewModel varientViewModel { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TeConService.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TeConService.ViewModels
{
    public class QuestionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Question Question { get; private set; }

        public QuestionViewModel()
        {
            Question = new Question();
        }
        public string OQuestion
        {
            get { return Question.OQuestion; }
            set
            {
                if (Question.OQuestion != value)
                {
                    Question.OQuestion = value;
                    OnPropertyChanged("OQuestion");
                }
            }
        }
        public ObservableCollection<VarientViewModel> Varients
        {
            get { return Question.Varients; }
            set
            {
                if (Question.Varients != value)
                {
                    Question.Varients = value;
                    OnPropertyChanged("Varients");
                }
            }
        }
        public VarientViewModel varientViewModel
        {
            get { return Question.varientViewModel; }
            set
            {
                if (Question.varientViewModel != value)
                {
                    Question.varientViewModel = value;
                    OnPropertyChanged("varientViewModel");
                }
            }
        }
        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(OQuestion.Trim());
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}

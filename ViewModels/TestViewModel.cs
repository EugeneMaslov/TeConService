using System;
using System.Collections.Generic;
using System.Text;
using TeConService.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace TeConService.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Tests Test { get; private set; }

        public TestViewModel()
        {
            Test = new Tests();
        }
        public string Name
        {
            get { return Test.Name; }
            set
            {
                if (Test.Name != value)
                {
                    Test.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public ObservableCollection<QuestionViewModel> Questions
        {
            get { return Test.Questions; }
            set
            {
                if (Test.Questions != value)
                {
                    Test.Questions = value;
                    OnPropertyChanged("Questions");
                }
            }
        }
        public QuestionViewModel questionViewModel
        {
            get { return Test.questionViewModel; }
            set
            {
                if (Test.questionViewModel != value)
                {
                    Test.questionViewModel = value;
                    OnPropertyChanged("questionViewModel");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Name.Trim());
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}

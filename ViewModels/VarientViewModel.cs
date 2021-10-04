using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using TeConService.Models;

namespace TeConService.ViewModels
{
    public class VarientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Varient Varient { get; private set; }
        public VarientViewModel()
        {
            Varient = new Varient();
        }

        public string OVarient
        {
            get { return Varient.OVarient; }
            set
            {
                if (Varient.OVarient != value)
                {
                    Varient.OVarient = value;
                    OnPropertyChanged("OVarient");
                }
            }
        }
        public bool IsTrue
        {
            get { return Varient.IsTrue; }
            set
            {
                if (Varient.IsTrue != value)
                {
                    Varient.IsTrue = value;
                    OnPropertyChanged("IsTrue");
                }
            }
        }
        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(OVarient.Trim());
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}

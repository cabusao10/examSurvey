using Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace examSurvey
{
    /// <summary>
    /// Interaction logic for Question.xaml
    /// </summary>
    public partial class Question : Page, INotifyPropertyChanged
    {
        public string type;
        public string[] curOptions;
        private string _title;
        public string pTitle
        {
            get { return _title; }
            set { _title = value;
                OnPropertyChanged(nameof(pTitle));
            }
        }
        public Question(Questions questions)
        {
            type = questions.Type;
            pTitle = questions.Title;
            curOptions = questions.Options;
            InitializeComponent();
            ProcessUI(questions.Type, questions.Options);
        }
        private void ProcessUI(string type, string[] options)
        {
            switch (type) {
                case "textbox":
                    {
                        fOptions.Content = new QuestionTypes.pTextbox();
                    }
                    break;
                case "radiobutton": 
                    {
                        fOptions.Content = new QuestionTypes.pRadioButton(options[0], options[1]);
                    }
                    break;
                case "checkbox":
                    {
                        fOptions.Content = new QuestionTypes.pCheckbox(options);
                    }
                    break;
                case "dropdownlist":
                    {
                        fOptions.Content = new QuestionTypes.pDropdownlist(options.ToList());
                    }
                    break;

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

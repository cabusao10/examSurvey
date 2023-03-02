using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace examSurvey.QuestionTypes
{
    /// <summary>
    /// Interaction logic for pCheckbox.xaml
    /// </summary>
    public partial class pCheckbox : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private string _opt1;
        public string Option1
        {
            get { return _opt1; }
            set { _opt1 = value;
            OnPropertyChanged(nameof(Option1));
            }
        }

        private string _opt2;
        public string Option2
        {
            get { return _opt2; }
            set
            {
                _opt2= value;
                OnPropertyChanged(nameof(Option2));
            }
        }
        private string _opt3;
        public string Option3
        {
            get { return _opt3; }
            set
            {
                _opt3 = value;
                OnPropertyChanged(nameof(Option3));
            }
        }

        private string _opt4;
        public string Option4
        {
            get { return _opt4; }
            set
            {
                _opt4 = value;
                OnPropertyChanged(nameof(Option4));
            }
        }

        private string _opt5;
        public string Option5
        {
            get { return _opt5; }
            set
            {
                _opt5 = value;
                OnPropertyChanged(nameof(Option5));
            }
        }

        private string _opt6;
        public string Option6
        {
            get { return _opt6; }
            set
            {
                _opt6 = value;
                OnPropertyChanged(nameof(Option6));
            }
        }


        private string _opt7;
        public string Option7
        {
            get { return _opt7; }
            set
            {
                _opt7 = value;
                OnPropertyChanged(nameof(Option7));
            }
        }

        private string _opt8;
        public string Option8
        {
            get { return _opt8; }
            set
            {
                _opt8= value;
                OnPropertyChanged(nameof(Option8));
            }
        }

        private string _opt9;
        public string Option9
        {
            get { return _opt9; }
            set
            {
                _opt9 = value;
                OnPropertyChanged(nameof(Option9));
            }
        }
        public pCheckbox(string[] options)
        {

            InitializeComponent();

            Option1 = options[0];
            Option2 = options[1];
            Option3 = options[2];
            Option4 = options[3];
            Option5 = options[4];
            Option6 = options[5];
            Option7 = options[6];
            Option8 = options[7];
            Option9 = options[8];



        }
    }
}

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
    /// Interaction logic for pRadioButton.xaml
    /// </summary>
    public partial class pRadioButton : Page, INotifyPropertyChanged
    {

        private string _option1;
        public string Option1
        {
            get { return _option1; }
            set { _option1 = value;
                OnPropertyChanged(nameof(Option1));
            }
        }


        private string _option2;
        public string Option2
        {
            get { return _option2; }
            set { _option2 = value;
                OnPropertyChanged(nameof(Option2));
            }
        }

        public pRadioButton(string opt1,string opt2)
        {

            Option1 = opt1;
            Option2 = opt2;
            InitializeComponent();
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

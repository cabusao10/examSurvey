using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace examSurvey.QuestionTypes
{
    /// <summary>
    /// Interaction logic for pDropdownlist.xaml
    /// </summary>
    public partial class pDropdownlist : Page, INotifyPropertyChanged
    {

        private string _selected;
        public string Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;

                OnPropertyChanged(nameof(Selected));
            }
        }

        private  List<string> _options = new List<string>();
        public List<string> Options
        {
            get { return _options; }
            set
            {
                _options = value;
                OnPropertyChanged(nameof(Options));
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
        public pDropdownlist(List<string> options)
        {
            Options = options;
            InitializeComponent();
        }
    }
}

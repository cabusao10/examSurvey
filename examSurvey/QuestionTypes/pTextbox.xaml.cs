using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for pTextbox.xaml
    /// </summary>
    public partial class pTextbox : Page, INotifyPropertyChanged
    {
        private string _answer;
        public string Answer
        {
            get { return _answer; }
            set
            {
                _answer = value;
                OnPropertyChanged(nameof(Answer));
            }
        }

        public pTextbox()
        {
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

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {

                Answer = this.txtInput.Text;
            }
        }
    }
}

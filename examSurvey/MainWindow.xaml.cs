using Services;
using Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int QuestionIndex = 0;
        private readonly Database database;


       
        private Survey _survey;
        public Survey CurrentSurvey
        {
            get { return _survey; }
            set
            {
                _survey = value;
                OnPropertyChanged(nameof(CurrentSurvey));
            }
        }
        private Questions[] _questions;

        private Question[] PageQuestions { get; set; }
        //private Question _currentQuestion = new Question();
        //public Question CurrentQuestion
        //{
        //    get { return _currentQuestion; }
        //    set
        //    {
        //        _currentQuestion = value;
        //        OnPropertyChanged(nameof(CurrentQuestion));
        //    }
        //}

        public MainWindow()
        {
            database = new Database(@"Data source=DESKTOP-8PT6N5V\SQLEXPRESS;Initial Catalog=WPFSurvey;User Id=user1;Password=Password1");
            ProcessData();
            InitializeComponent();
            fQUestion.Content = PageQuestions[QuestionIndex];

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void ProcessData()
        {
            _survey = database.GetTable("select * from tblSurvey where id = 1").MapSurvey();
            _questions = database.GetTable("select * from tblQuestionaires where surveyId = 1").MapQuestionaires();
            PageQuestions = _questions.Select(x=> new Question(x)).ToArray();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            NavigateQuestions(e);

        }
    
        //private void FinishSurvey()
        //{
        //    var answer1 = GetAnswer(PageQuestions[0]);
        //    var answer2 = GetAnswer(PageQuestions[1]);
        //    var answer3 = GetAnswer(PageQuestions[2]);
        //    var answer4 = GetAnswer(PageQuestions[3]);
        //    var answer5 = GetAnswer(PageQuestions[4]);
        //    database.ExecuteNonQuery($"insert into tblUserAnswers (surveyid,Answer1,Answer2,Answer3,Answer4,Answer5) values(@p1,@p2,@p3,@p4,@p5,@p6)",
        //        _survey.Id,
        //        answer1,answer2,answer3,answer4,answer5

        //        );
        //}
        private void NavigateQuestions(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    {

                        // Previous
                        if (QuestionIndex - 1 == -1) return;
                        QuestionIndex--;
                        fQUestion.Content = PageQuestions[QuestionIndex];
                    }
                    break;
                case Key.Enter:
                case Key.Right:
                    {
                        // Next
                        if (QuestionIndex + 1 > _questions.Length -1)
                        {
                            fQUestion.Content = new EndOfSurvey(PageQuestions,database,_survey.Id);
                            //FinishSurvey();
                            return;
                        }
                        QuestionIndex++;
                        fQUestion.Content = PageQuestions[QuestionIndex];

                    }
                    break;
            }
            
        }
    }
}

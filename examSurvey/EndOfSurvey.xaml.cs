using Services.Models;
using Services;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for EndOfSurvey.xaml
    /// </summary>
    public partial class EndOfSurvey : Page
    {
        protected Database database;
        private int surveyid;
        public EndOfSurvey(Question[] PageQuestions, Database databae, int surveyid )
        {

            InitializeComponent();
            
            this.database = databae;
            this.surveyid = surveyid;
            FinishSurvey(PageQuestions);
        }
        public string GetAnswer(Question question)
        {

            var answer = "";
            switch (question.type)
            {
                case "textbox":
                    {
                        answer = ((QuestionTypes.pTextbox)question.fOptions.Content).Answer;

                    }
                    break;
                case "radiobutton":
                    {
                        answer = ((QuestionTypes.pRadioButton)question.fOptions.Content).option1.IsChecked.HasValue ? question.curOptions[0] : question.curOptions[1];

                    }
                    break;
                case "checkbox":
                    {
                        List<string> tmpanswer = new List<string>();
                        var frm = ((QuestionTypes.pCheckbox)question.fOptions.Content);
                        if (((bool)frm.opt1.IsChecked))
                        {
                            tmpanswer.Add(frm.Option1);
                        }
                        if (((bool)frm.opt2.IsChecked))
                        {
                            tmpanswer.Add(frm.Option2);
                        }
                        if (((bool)frm.opt3.IsChecked))
                        {
                            tmpanswer.Add(frm.Option3);
                        }
                        if (((bool)frm.opt4.IsChecked))
                        {
                            tmpanswer.Add(frm.Option4);
                        }
                        if (((bool)frm.opt5.IsChecked))
                        {
                            tmpanswer.Add(frm.Option5);
                        }
                        if (((bool)frm.opt6.IsChecked))
                        {
                            tmpanswer.Add(frm.Option6);
                        }
                        if (((bool)frm.opt7.IsChecked))
                        {
                            tmpanswer.Add(frm.Option7);
                        }
                        if (((bool)frm.opt8.IsChecked))
                        {
                            tmpanswer.Add(frm.Option8);
                        }
                        if (((bool)frm.opt9.IsChecked))
                        {
                            tmpanswer.Add(frm.Option9);
                        }
                        answer = string.Join(";", tmpanswer.ToArray());
                        //fOptions.Content = new QuestionTypes.pCheckbox(options);
                    }
                    break;
                case "dropdownlist":
                    {
                        answer = ((QuestionTypes.pDropdownlist)question.fOptions.Content).Selected;

                    }
                    break;
            }

            return answer;
        }
        private void FinishSurvey(Question[] PageQuestions )
        {
            var answer1 = GetAnswer(PageQuestions[0]);
            var answer2 = GetAnswer(PageQuestions[1]);
            var answer3 = GetAnswer(PageQuestions[2]);
            var answer4 = GetAnswer(PageQuestions[3]);
            var answer5 = GetAnswer(PageQuestions[4]);
            database.ExecuteNonQuery($"insert into tblUserAnswers (surveyid,Answer1,Answer2,Answer3,Answer4,Answer5) values(@p1,@p2,@p3,@p4,@p5,@p6)",
                surveyid,
                answer1, answer2, answer3, answer4, answer5

                );
        }
    }
}

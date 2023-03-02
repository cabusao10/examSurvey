using Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class Extension
    {

        public static Survey MapSurvey(this DataTable data)
        {

            return new Survey()
            {
                Id = Convert.ToInt32(data.Rows[0]["id"]),
                Title = (string)data.Rows[0]["title"],
                Description = (string)data.Rows[0]["description"],
            };


        }
       
        public static Questions[] MapQuestionaires(this DataTable data)
        {
            List<Questions> list = new List<Questions>();
            for (int x = 0; x < data.Rows.Count; x++)
            {

                list.Add(new Questions()
                {
                    Id = (int)data.Rows[x]["id"],
                    SurveyId = (int)data.Rows[x]["surveyid"],
                    Title = (string)data.Rows[x]["title"],
                    Type = (string)data.Rows[x]["type"],
                    Options = (data.Rows[x]["options"] == DBNull.Value ? new string[0] : ((string)data.Rows[x]["options"]).Split(';')),

                });
            }
            return list.ToArray();
        }
    }
}

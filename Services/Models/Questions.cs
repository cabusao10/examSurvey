using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string[] Options { get; set; }

    }
}

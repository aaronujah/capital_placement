using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capital_Placement.Models
{
    public class Question
    {
        public string QuestionTitle { get; set; } = string.Empty;
        public QuestionType Type { get; set; }
        public List<string>? MultipleChoice { get; set; } 
        public Boolean? Other { get; set; }
        public int MaxChoice { get; set; }
    }

    public enum QuestionType{
        Paragraph,
        YesNo,
        DropDown,
        Date,
        Number
    }
}
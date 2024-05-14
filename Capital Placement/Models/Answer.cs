using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capital_Placement.Models
{
    public class Answer
    {
        public string QuestionTitle { get; set; } = string.Empty;
        [Required, EnumDataType(typeof(QuestionType))]
        public QuestionType Type { get; set; }
        public string ParagraphAnswer { get; set; } = string.Empty;
        public Boolean YesNoAnswer { get; set; }
        public List<string> DropDownAnswer { get; set; } = [];
        public DateTime DateTimeAnswer { get; set; }
        public int NumberAnswer { get; set; }
    }
}
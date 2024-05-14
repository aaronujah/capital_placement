using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Capital_Placement.Models
{
    public class Question
    {
        public string QuestionTitle { get; set; } = string.Empty;
        [Required, EnumDataType(typeof(QuestionType))]
        public QuestionType Type { get; set; }
        public List<string>? MultipleChoice { get; set; } 
        public Boolean? Other { get; set; }
        public int? MaxChoice { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QuestionType{
        Paragraph = 1,
        YesNo,
        DropDown,
        Date,
        Number
    }
}
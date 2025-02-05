using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Capital_Placement.Models
{
    public class Application
    {
         public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string CurrentResidence { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public DateTime? DOB { get; set; } 
        [Required, EnumDataType(typeof(Gender))]
        public Gender? Gender { get; set; }
        public List<Answer> PersonalQuestions { get; set; } = [];
        public List<Answer> CustomQuestions { get; set; } = [];
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender{
        Male=1,
        Female,
        Other
    }
}
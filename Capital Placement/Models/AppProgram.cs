using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capital_Placement.Models
{
    public class AppProgram
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public PersonalInfo Phone { get; set; } = new PersonalInfo();
        public PersonalInfo Nationality { get; set; } = new PersonalInfo();
        public PersonalInfo CurrentResidence { get; set; } = new PersonalInfo();
        public PersonalInfo IdNumber { get; set; } = new PersonalInfo();
        public PersonalInfo DOB { get; set; } = new PersonalInfo();
        public PersonalInfo Gender { get; set; } = new PersonalInfo();
        public List<Question> PersonalQuestions { get; set; } = [];
        public List<Question> CustomQuestions { get; set; } = [];
    }

    public class PersonalInfo {
        public Boolean Internal { get; set; }
        public Boolean Hide { get; set; }
    }
}
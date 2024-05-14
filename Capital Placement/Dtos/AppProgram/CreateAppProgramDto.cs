using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Capital_Placement.Models;

namespace Capital_Placement.Dtos.AppProgram
{
    public class CreateAppProgramDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be at least 5 characters")]
        [MaxLength(120, ErrorMessage ="Title cannot be over 120 characters")]
        public string Title { get; set; } = string.Empty;
       
        [MinLength(5, ErrorMessage = "Description must be at least 5 characters")]
        [MaxLength(300, ErrorMessage ="Description cannot be over 300 characters")]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public PersonalInfo Phone { get; set; } = new PersonalInfo();
        [Required]
        public PersonalInfo Nationality { get; set; } = new PersonalInfo();
        [Required]
        public PersonalInfo CurrentResidence { get; set; } = new PersonalInfo();
        [Required]
        public PersonalInfo IdNumber { get; set; } = new PersonalInfo();
        [Required]
        public PersonalInfo DOB { get; set; } = new PersonalInfo();
        [Required]
        public PersonalInfo Gender { get; set; } = new PersonalInfo();
        public List<Question> PersonalQuestions { get; set; } = [];
        public List<Question> CustomQuestions { get; set; } = [];
    }
}
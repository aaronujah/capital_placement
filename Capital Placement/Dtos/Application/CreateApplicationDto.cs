using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Capital_Placement.Models;

namespace Capital_Placement.Dtos.Application
{
    public class CreateApplicationDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "First name must be at least 1 characters")]
        [MaxLength(52, ErrorMessage ="First name cannot be over 52 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "Last name must be at least 1 characters")]
        [MaxLength(52, ErrorMessage ="Last name cannot be over 52 characters")]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        public string Phone { get; set; } = string.Empty;
        
        [MinLength(1, ErrorMessage = "Nationality name must be at least 1 characters")]
        [MaxLength(52, ErrorMessage ="Nationality name cannot be over 52 characters")]
        public string Nationality { get; set; } = string.Empty;
        
        [MinLength(1, ErrorMessage = "Current residence name must be at least 1 characters")]
        [MaxLength(52, ErrorMessage ="Current residence name cannot be over 52 characters")]
        public string CurrentResidence { get; set; } = string.Empty;
        
        [MinLength(1, ErrorMessage = "Id Number name must be at least 1 characters")]
        [MaxLength(52, ErrorMessage ="Id Number name cannot be over 52 characters")]
        public string IdNumber { get; set; } = string.Empty;
        
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; } 
        
        [EnumDataType(typeof(Gender))]
        public Gender? Gender { get; set; }
        public List<Answer> PersonalQuestions { get; set; } = [];
        public List<Answer> CustomQuestions { get; set; } = [];
    }
}
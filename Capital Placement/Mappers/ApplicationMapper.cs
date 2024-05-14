using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capital_Placement.Dtos.Application;
using Capital_Placement.Models;

namespace Capital_Placement.Mappers
{
    public static class ApplicationMapper
    {
        public static Application ToApplicationDto(this Application application){
            return new Application
            {
                Id = application.Id,
                FirstName = application.FirstName,
                LastName = application.LastName,
                Email = application.Email,
                Phone = application.Phone,
                Nationality = application.Nationality,
                CurrentResidence = application.CurrentResidence,
                IdNumber = application.IdNumber,
                DOB = application.DOB,
                Gender = application.Gender,
                PersonalQuestions = application.PersonalQuestions,
                CustomQuestions = application.CustomQuestions
            };
        }

        public static Application ToApplicationFromCreateDto(this CreateApplicationDto applicationDto){
            //Remove unnnecessary values if the question type is not DropDown
            var personalQuestions = AcceptValidAnswers(applicationDto.PersonalQuestions);
           
           //Remove unnnecessary values if the question type is not DropDown
            var customQuestions = AcceptValidAnswers(applicationDto.CustomQuestions);

            return new Application
            {
                FirstName = applicationDto.FirstName,
                LastName = applicationDto.LastName,
                Email = applicationDto.Email,
                Phone = applicationDto.Phone,
                Nationality = applicationDto.Nationality,
                CurrentResidence = applicationDto.CurrentResidence,
                IdNumber = applicationDto.IdNumber,
                DOB = applicationDto.DOB,
                Gender = applicationDto.Gender,
                PersonalQuestions = personalQuestions,
                CustomQuestions = customQuestions,
            };
        }
       
        public static Application ToApplicationFromUpdateDto(this UpdateApplicationDto applicationDto){
           //Remove unnnecessary values if the question type is not DropDown
            var personalQuestions = AcceptValidAnswers(applicationDto.PersonalQuestions);
           
           //Remove unnnecessary values if the question type is not DropDown
            var customQuestions = AcceptValidAnswers(applicationDto.CustomQuestions);

            return new Application
            {
                FirstName = applicationDto.FirstName,
                LastName = applicationDto.LastName,
                Email = applicationDto.Email,
                Phone = applicationDto.Phone,
                Nationality = applicationDto.Nationality,
                CurrentResidence = applicationDto.CurrentResidence,
                IdNumber = applicationDto.IdNumber,
                DOB = applicationDto.DOB,
                Gender = applicationDto.Gender,
                PersonalQuestions = personalQuestions,
                CustomQuestions = customQuestions,
            };
        }

        public static List<Answer> AcceptValidAnswers(List<Answer> answers){
            return answers.Select(question => {
                var newQuestion = new Answer{
                    QuestionTitle = question.QuestionTitle,
                    Type = question.Type
                };
                
                switch (question.Type)
                {
                    case QuestionType.Paragraph:
                        newQuestion.ParagraphAnswer = question.ParagraphAnswer;
                        break;
                    case QuestionType.YesNo:
                        newQuestion.YesNoAnswer = question.YesNoAnswer;
                        break;
                    case QuestionType.DropDown:
                        newQuestion.DropDownAnswer = question.DropDownAnswer;
                        break;
                    case QuestionType.Date:
                        newQuestion.DateTimeAnswer = question.DateTimeAnswer;
                        break;
                    case QuestionType.Number:
                        newQuestion.NumberAnswer = question.NumberAnswer;
                        break;                
                }
                return newQuestion;
            }).ToList();
        }
    }
}
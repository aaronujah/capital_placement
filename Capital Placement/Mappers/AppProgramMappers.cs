using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capital_Placement.Dtos.AppProgram;
using Capital_Placement.Models;

namespace Capital_Placement.Mappers
{
    public static class AppProgramMappers
    {
        public static AppProgram ToAppProgramDto(this AppProgram appProgram){
            return new AppProgram
            {
                Id = appProgram.Id,
                Title = appProgram.Title,
                Description = appProgram.Description,
                Phone = appProgram.Phone,
                Nationality = appProgram.Nationality,
                CurrentResidence = appProgram.CurrentResidence,
                IdNumber = appProgram.IdNumber,
                DOB = appProgram.DOB,
                Gender = appProgram.Gender,
                PersonalQuestions = appProgram.PersonalQuestions,
                CustomQuestions = appProgram.CustomQuestions
            };
        }

        public static AppProgram ToAppProgramFromCreateDto(this CreateAppProgramDto appProgramDto){
           //Remove unnnecessary values if the question type is not DropDown
            var personalQuestions = appProgramDto.PersonalQuestions.Select(question => {
                if (question.Type != QuestionType.DropDown){
                    question.MaxChoice = null;
                    question.MultipleChoice = null;
                    question.Other = null;
                }
                return question;
            }).ToList();
           
           //Remove unnnecessary values if the question type is not DropDown
            var customQuestions = appProgramDto.CustomQuestions.Select(question => {
                if (question.Type != QuestionType.DropDown){
                    question.MaxChoice = null;
                    question.MultipleChoice = null;
                    question.Other = null;
                }
                return question;
            }).ToList();

            return new AppProgram
            {
                Title = appProgramDto.Title,
                Description = appProgramDto.Description,
                Phone = appProgramDto.Phone,
                Nationality = appProgramDto.Nationality,
                CurrentResidence = appProgramDto.CurrentResidence,
                IdNumber = appProgramDto.IdNumber,
                DOB = appProgramDto.DOB,
                Gender = appProgramDto.Gender,
                PersonalQuestions = personalQuestions,
                CustomQuestions = customQuestions,
            };
        }
       
        public static AppProgram ToAppProgramFromUpdateDto(this UpdateAppProgramDto appProgramDto){
            //Remove unnnecessary values if the question type is not DropDown
            var personalQuestions = appProgramDto.PersonalQuestions.Select(question => {
                if (question.Type != QuestionType.DropDown){
                    question.MaxChoice = null;
                    question.MultipleChoice = null;
                    question.Other = null;
                }
                return question;
            }).ToList();
           
           //Remove unnnecessary values if the question type is not DropDown
            var customQuestions = appProgramDto.CustomQuestions.Select(question => {
                if (question.Type != QuestionType.DropDown){
                    question.MaxChoice = null;
                    question.MultipleChoice = null;
                    question.Other = null;
                }
                return question;
            }).ToList();

            return new AppProgram
            {
                Title = appProgramDto.Title,
                Description = appProgramDto.Description,
                Phone = appProgramDto.Phone,
                Nationality = appProgramDto.Nationality,
                CurrentResidence = appProgramDto.CurrentResidence,
                IdNumber = appProgramDto.IdNumber,
                DOB = appProgramDto.DOB,
                Gender = appProgramDto.Gender,
                PersonalQuestions = personalQuestions,
                CustomQuestions = customQuestions,
            };
        }
    }
}
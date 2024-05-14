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
                PersonalQuestions = appProgramDto.PersonalQuestions,
                CustomQuestions = appProgramDto.CustomQuestions
            };
        }
       
        public static AppProgram ToAppProgramFromUpdateDto(this UpdateAppProgramDto appProgramDto){
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
                PersonalQuestions = appProgramDto.PersonalQuestions,
                CustomQuestions = appProgramDto.CustomQuestions
            };
        }
    }
}
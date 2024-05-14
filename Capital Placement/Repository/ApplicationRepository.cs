using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capital_Placement.Data;
using Capital_Placement.Interfaces;
using Capital_Placement.Models;
using Microsoft.EntityFrameworkCore;

namespace Capital_Placement.Repository
{
    public class ApplicationRepository: IApplicationRepository
    {
        private readonly CapitalPlacementContext _context;
        public ApplicationRepository(CapitalPlacementContext context)
        {
            _context = context;
        }

        public async Task<Application> Create(Application application)
        {
            await _context.Applications.AddAsync(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<bool> Delete(Guid applicationId)
        {
            var application = await _context.Applications.FirstOrDefaultAsync(x => x.Id == applicationId);

            if (application == null)
            {
                return false;
            }

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Application>> GetAll()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application?> GetById(Guid applicationId)
        {
            return await _context.Applications.FirstOrDefaultAsync(i => i.Id == applicationId);
        }

        public async Task<Application?> Update(Guid applicationId, Application application)
        {
            var existingApplication = await _context.Applications.FirstOrDefaultAsync(x => x.Id == applicationId);

            if (existingApplication == null)
            {
                return null;
            };
                existingApplication.FirstName = application.FirstName;
                existingApplication.LastName = application.LastName;
                existingApplication.Email = application.Email;
                existingApplication.Phone = application.Phone;
                existingApplication.Nationality = application.Nationality;
                existingApplication.CurrentResidence = application.CurrentResidence;
                existingApplication.IdNumber = application.IdNumber;
                existingApplication.DOB = application.DOB;
                existingApplication.Gender = application.Gender;
                existingApplication.PersonalQuestions = application.PersonalQuestions;
                existingApplication.CustomQuestions = application.CustomQuestions;

            await _context.SaveChangesAsync();

            return existingApplication;
        }
    }
}
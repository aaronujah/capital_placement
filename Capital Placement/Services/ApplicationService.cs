using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capital_Placement.Interfaces;
using Capital_Placement.Models;

namespace Capital_Placement.Services
{
    public class ApplicationService: IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<List<Application>> GetAll()
        {
            var applications = await _applicationRepository.GetAll();

            return applications;
        }
    
        public async Task<Application?> GetById(Guid applicationId)
        {
            var application = await _applicationRepository.GetById(applicationId);

            return application;
        }

        public async Task<Application> Create(Application application)
        {
            await _applicationRepository.Create(application);

            return application;
        }

        public async Task<Application?> Update(Guid applicationId, Application application)
        {
            var result = await _applicationRepository.Update(applicationId, application);

            return result;
        }

        public async Task<bool> Delete(Guid applicationId)
        {
            var result = await _applicationRepository.Delete(applicationId);

            return result;
        }
    }
}
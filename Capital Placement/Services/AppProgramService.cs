using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capital_Placement.Interfaces;
using Capital_Placement.Models;

namespace Capital_Placement.Services
{
    public class AppProgramService: IAppProgramService
    {
        private readonly IAppProgramRepository _appProgramRepository;

        public AppProgramService(IAppProgramRepository appProgramRepository)
        {
            _appProgramRepository = appProgramRepository;
        }

        public async Task<List<AppProgram>> GetAll()
        {
            var appPrograms = await _appProgramRepository.GetAll();

            return appPrograms;
        }
    
        public async Task<AppProgram?> GetById(Guid appProgramId)
        {
            var appProgram = await _appProgramRepository.GetById(appProgramId);

            return appProgram;
        }

        public async Task<AppProgram> Create(AppProgram appProgram)
        {
            await _appProgramRepository.Create(appProgram);

            return appProgram;
        }

        public async Task<AppProgram?> Update(Guid appProgramId, AppProgram appProgram)
        {
            var result = await _appProgramRepository.Update(appProgramId, appProgram);

            return result;
        }

        public async Task<bool> Delete(Guid appProgramId)
        {
            var result = await _appProgramRepository.Delete(appProgramId);

            return result;
        }
    }
}
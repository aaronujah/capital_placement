using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capital_Placement.Models;

namespace Capital_Placement.Interfaces
{
    public interface IAppProgramService
    {
        Task<AppProgram> Create(AppProgram appProgram);
        Task<List<AppProgram>> GetAll();
        Task<AppProgram?> GetById(Guid appProgramId);
        Task<AppProgram?> Update(Guid appProgramId, AppProgram appProgram);
        Task<bool> Delete(Guid appProgramId);
    }
}
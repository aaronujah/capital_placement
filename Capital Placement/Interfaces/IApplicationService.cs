using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capital_Placement.Models;

namespace Capital_Placement.Interfaces
{
    public interface IApplicationService
    {
        Task<Application> Create(Application application);
        Task<List<Application>> GetAll();
        Task<Application?> GetById(Guid applicationId);
        Task<Application?> Update(Guid applicationId, Application application);
        Task<bool> Delete(Guid applicationId);
    }
}
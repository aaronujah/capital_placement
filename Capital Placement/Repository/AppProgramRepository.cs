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
    public class AppProgramRepository : IAppProgramRepository
    {
        private readonly CapitalPlacementContext _context;
        public AppProgramRepository(CapitalPlacementContext context)
        {
            _context = context;
        }

        public async Task<AppProgram> Create(AppProgram appProgram)
        {
            await _context.AppPrograms.AddAsync(appProgram);
            await _context.SaveChangesAsync();
            return appProgram;
        }

        public async Task<bool> Delete(Guid appProgramId)
        {
            var appProgram = await _context.AppPrograms.FirstOrDefaultAsync(x => x.Id == appProgramId);

            if (appProgram == null)
            {
                return false;
            }

            _context.AppPrograms.Remove(appProgram);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<AppProgram>> GetAll()
        {
            return await _context.AppPrograms.ToListAsync();
        }

        public async Task<AppProgram?> GetById(Guid appProgramId)
        {
            return await _context.AppPrograms.FirstOrDefaultAsync(i => i.Id == appProgramId);
        }

        public async Task<AppProgram?> Update(Guid appProgramId, AppProgram appProgram)
        {
            var existingStock = await _context.AppPrograms.FirstOrDefaultAsync(x => x.Id == appProgramId);

            if (existingStock == null)
            {
                return null;
            }

            await _context.SaveChangesAsync();

            return existingStock;
        }
    }
}
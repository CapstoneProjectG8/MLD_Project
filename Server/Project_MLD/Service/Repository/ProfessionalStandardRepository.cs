using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class ProfessionalStandardRepository : IProfessionalStandardRepository
    {
        private readonly MldDatabaseContext _context;

        public ProfessionalStandardRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ProfessionalStandard> AddProfessionalStandard(ProfessionalStandard ProfessionalStandard)
        {
            _context.ProfessionalStandards.Add(ProfessionalStandard);
            await _context.SaveChangesAsync();
            return ProfessionalStandard;
        }

        public async Task<bool> DeleteProfessionalStandard(int id)
        {
            var ProfessionalStandard = await GetProfessionalStandardById(id);
            if (ProfessionalStandard == null)
            {
                return false;
            }
            _context.ProfessionalStandards.Remove(ProfessionalStandard);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProfessionalStandard>> GetAllProfessionalStandard()
        {
            return await _context.ProfessionalStandards.ToListAsync();
        }

        public async Task<ProfessionalStandard> GetProfessionalStandardById(int id)
        {
            return await _context.ProfessionalStandards.FindAsync(id);
        }

        public async Task<bool> UpdateProfessionalStandard(ProfessionalStandard ProfessionalStandard)
        {
            var existProfessionalStandard = await GetProfessionalStandardById(ProfessionalStandard.Id);
            if (existProfessionalStandard == null)
            {
                return false;
            }

            _context.Entry(existProfessionalStandard).CurrentValues.SetValues(ProfessionalStandard);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

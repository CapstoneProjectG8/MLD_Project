using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class SpecialTeamRepository : ISpecialTeamRepository
    {
        private readonly MldDatabaseContext _context;

        public SpecialTeamRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<SpecializedTeam> AddSpecialTeam(SpecializedTeam st)
        {
            _context.SpecializedTeams.Add(st);
            await _context.SaveChangesAsync();
            return st;
        }

        public async Task<bool> DeleteSpecialTeam(int id)
        {
            var existSpecialTeam = await GetSpecialTeamById(id);
            if (existSpecialTeam == null)
            {
                return false;
            }
            _context.SpecializedTeams.Remove(existSpecialTeam);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SpecializedTeam>> GetAllSpecialTeams()
        {
            return await _context.SpecializedTeams.ToListAsync();
        }

        public async Task<SpecializedTeam> GetSpecialTeamById(int id)
        {
            return await _context.SpecializedTeams.FindAsync(id);
        }

        public async Task<bool> UpdateSpecialTeam(SpecializedTeam st)
        {
            var existSpecialTeam = await GetSpecialTeamById(st.Id);
            if (existSpecialTeam == null)
            {
                return false;
            }

            _context.Entry(existSpecialTeam).CurrentValues.SetValues(st);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

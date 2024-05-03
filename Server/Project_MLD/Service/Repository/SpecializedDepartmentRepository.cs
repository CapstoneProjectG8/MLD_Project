using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class SpecializedDepartmentRepository : ISpecializedDepartmentRepository
    {
        private readonly MldDatabase2Context _context;

        public SpecializedDepartmentRepository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<SpecializedDepartment> AddSpecializedDepartment(SpecializedDepartment st)
        {
            _context.SpecializedDepartments.Add(st);
            await _context.SaveChangesAsync();
            return st;
        }

        public async Task<bool> DeleteSpecializedDepartment(int id)
        {
            var existSpecialTeam = await GetSpecializedDepartmentById(id);
            if (existSpecialTeam == null)
            {
                return false;
            }
            _context.SpecializedDepartments.Remove(existSpecialTeam);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SpecializedDepartment>> GetAllSpecializedDepartment()
        {
            return await _context.SpecializedDepartments.ToListAsync();
        }

        public async Task<SpecializedDepartment> GetSpecializedDepartmentById(int id)
        {
            return await _context.SpecializedDepartments.FindAsync(id);
        }

        public async Task<bool> UpdateSpecializedDepartment(SpecializedDepartment st)
        {
            var existSpecialTeam = await GetSpecializedDepartmentById(st.Id);
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

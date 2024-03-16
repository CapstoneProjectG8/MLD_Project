using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class TeachingEquipmentRepository : ITeachingEquipmentRepository
    {
        private readonly MldDatabaseContext _context;

        public TeachingEquipmentRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<TeachingEquipment> AddTeachingEquipment(TeachingEquipment te)
        {
            _context.TeachingEquipments.Add(te);
            await _context.SaveChangesAsync();
            return te;
        }

        public async Task<bool> DeleteTeachingEquipment(int id)
        {
            var existTeachingEquipment = await GetTeachingEquipmentById(id);
            if (existTeachingEquipment == null)
            {
                return false;
            }
            _context.TeachingEquipments.Remove(existTeachingEquipment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TeachingEquipment>> GetAllTeachingEquipments()
        {
            return await _context.TeachingEquipments.ToListAsync();
        }

        public async Task<TeachingEquipment> GetTeachingEquipmentById(int id)
        {
            return await _context.TeachingEquipments.FindAsync(id);
        }

        public async Task<bool> UpdateTeachingEquipment(TeachingEquipment te)
        {
            var existTeachingEquipment = await GetTeachingEquipmentById(te.Id);
            if (existTeachingEquipment == null)
            {
                return false;
            }

            _context.Entry(existTeachingEquipment).CurrentValues.SetValues(te);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

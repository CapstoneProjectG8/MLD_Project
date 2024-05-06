using Amazon.Runtime;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;
using System.Reflection.Metadata;

namespace Project_MLD.Service.Repository
{
    public class Document1TeachingEquipmentRepository : IDocument1TeachingEquipmentRepository
    {
        private readonly MldDatabase2Context _context;

        public Document1TeachingEquipmentRepository(MldDatabase2Context context)
        {
            _context = context;
        }
        public async Task DeleteDocument1TeachingEquipment(List<Document1TeachingEquipment> list)
        {
            if (list == null || !list.Any())
            {
                return; // Nothing to delete
            }

            foreach (var item in list)
            {
                var existingItem = await _context.Document1TeachingEquipments
                  .FindAsync(item.Document1Id, item.TeachingEquipmentId);

                if (existingItem != null)
                {
                    _context.Document1TeachingEquipments.Remove(existingItem);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocument1TeachingEquipmentByDoc1ID(int id)
        {
            var items = await _context.Document1TeachingEquipments.Where(x => x.Document1Id == id).ToListAsync();
            if(items != null)
            {
                _context.RemoveRange(items);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Document1TeachingEquipment>> GetTeachingEquipmentByDocument1Id(int id)
        {
            var te = await _context.Document1TeachingEquipments
                .Include(x => x.TeachingEquipment)
                .Include(x => x.Document1)
               .Where(x => x.Document1Id == id)
               .ToListAsync();
            return te;
        }

        public async Task AddDocument1TeachingEquipment(List<Document1TeachingEquipment> list)
        {
            try
            {
                foreach (var item in list)
                {
                    _context.Document1TeachingEquipments.Add(item);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while add Teaching Equipment.", ex);
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document1SubjectRoomsRepository : IDocument1SubjectRoomsRepository
    {
        private readonly MldDatabase2Context _context;

        public Document1SubjectRoomsRepository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Document1SubjectRoom>> GetSubjectRoomsByDocument1Id(int id)
        {
            var subjectRooms = await _context.Document1SubjectRooms
                .Include(x => x.Document1)
                .Include(x => x.SubjectRoom)
                .Where(x => x.Document1Id == id)
                .ToListAsync();
            return subjectRooms;
        }

        public async Task AddDocument1SubjectRoom(List<Document1SubjectRoom> list)
        {
            try
            {
                foreach (var item in list)
                {
                    _context.Document1SubjectRooms.Add(item);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while add Subject Room.", ex);
            }
        }

        public async Task DeleteDocument1SubjectRoom(List<Document1SubjectRoom> list)
        {
            if (list == null || !list.Any())
            {
                throw new Exception("An error occurred while delete Subject Room.");
            }

            foreach (var item in list)
            {
                var existingItem = await _context.Document1SubjectRooms
                  .FindAsync(item.Document1Id, item.SubjectRoomId);

                if (existingItem != null)
                {
                    _context.Document1SubjectRooms.Remove(existingItem);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocument1SubjectRoomByDoc1Id(int id)
        {
            var items = await _context.Document1SubjectRooms.Where(x => x.Document1Id == id).ToListAsync();
            if (items != null)
            {
                _context.RemoveRange(items);
            }
            await _context.SaveChangesAsync();
        }
    }
}

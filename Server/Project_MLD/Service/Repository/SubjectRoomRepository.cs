using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class SubjectRoomRepository : ISubjectRoomRepository
    {
        private readonly MldDatabaseContext _context;

        public SubjectRoomRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<SubjectRoom> AddSubjectRoom(SubjectRoom sr)
        {
            _context.SubjectRooms.Add(sr);
            await _context.SaveChangesAsync();
            return sr;
        }

        public async Task<bool> DeleteSubjectRoom(int id)
        {
            var existSubjectRoom = await GetSubjectRoomById(id);
            if (existSubjectRoom == null)
            {
                return false;
            }
            _context.SubjectRooms.Remove(existSubjectRoom);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SubjectRoom>> GetAllSubjectRooms()
        {
            return await _context.SubjectRooms.ToListAsync();
        }

        public async Task<SubjectRoom> GetSubjectRoomById(int id)
        {
            return await _context.SubjectRooms.FindAsync(id);
        }

        public async Task<bool> UpdateSubjectRoom(SubjectRoom sr)
        {
            var existSubjectRoom = await GetSubjectRoomById(sr.Id);
            if (existSubjectRoom == null)
            {
                return false;
            }

            _context.Entry(existSubjectRoom).CurrentValues.SetValues(sr);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly MldDatabaseContext2 _context;

        public SubjectRepository(MldDatabaseContext2 context)
        {
            _context = context;
        }

        public async Task<Subject> AddSubject(Subject Subject)
        {
            _context.Subjects.Add(Subject);
            await _context.SaveChangesAsync();
            return Subject;
        }

        public async Task<bool> DeleteSubject(int id)
        {
            var existSubject = await GetSubjectById(id);
            if (existSubject == null)
            {
                return false;
            }
            _context.Subjects.Remove(existSubject);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjects()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            return await _context.Subjects.FindAsync(id);
        }

        public async Task<bool> UpdateSubject(Subject sub)
        {
            var existSubject = await GetSubjectById(sub.Id);
            if (existSubject == null)
            {
                return false;
            }

            _context.Entry(existSubject).CurrentValues.SetValues(sub);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly MldDatabase2Context _context;

        public SubjectRepository(MldDatabase2Context context)
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

        public async Task<IEnumerable<Subject>> GetSubjectsByDepartmentId(int departmentId)
        {
            return await _context.Subjects
                .Where(x => x.DepartmentId == departmentId).ToListAsync();
        }

        public async Task<bool> UpdateSubject(Subject sub)
        {
            var existSubject = await GetSubjectById(sub.Id);
            if (existSubject == null)
            {
                return false;
            }

            var properties = typeof(Subject).GetProperties();
            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(sub);
                if (updatedValue != null)
                {
                    property.SetValue(existSubject, updatedValue);
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

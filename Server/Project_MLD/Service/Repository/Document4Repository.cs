    using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;
using System.Reflection.Metadata.Ecma335;

namespace Project_MLD.Service.Repository
{
    public class Document4Repository : IDocument4Repository
    {
        private readonly MldDatabase2Context _context;

        public Document4Repository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<Document4> AddDocument4(Document4 pl4)
        {
            _context.Document4s.Add(pl4);
            await _context.SaveChangesAsync();
            return pl4;
        }

        public async Task<bool> DeleteDocument4(int id)
        {
            var existDocument4 = await GetDocument4ById(id);
            if (existDocument4 == null)
            {
                return false;
            }
            _context.Document4s.Remove(existDocument4);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Document4>> GetAllDocument4s()
        {
            return await _context.Document4s
                .Include(x => x.TeachingPlanner)
                 .ThenInclude(x => x.User)
                 .Include(x => x.TeachingPlanner)
                 .ThenInclude(x => x.Class)
                 .Include(x => x.TeachingPlanner)
                 .ThenInclude(x => x.Subject)
                .ToListAsync();
        }

        public async Task<object> GetDoc4InformationByDoc4Id(int id)
        {
            var doc = await _context.Document4s
                .Include(x => x.TeachingPlanner)
                    .ThenInclude(tp => tp.Class)
                .Include(x => x.TeachingPlanner)
                    .ThenInclude(tp => tp.Subject)

                .Where(d => d.Id == id)
                .Select(x => new
                {
                    document4Id = id,
                    document4Name = x.Name,
                    className = x.TeachingPlanner.Class.Name,
                    subjectName = x.TeachingPlanner.Subject.Name
                }).FirstOrDefaultAsync();

            return doc;

        }

        public async Task<Document4> GetDocument4ById(int id)
        {
            return await _context.Document4s.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Document4> GetDoc4TeachingPlannerByDoc4Id(int id)
        {
            return await _context.Document4s
                .Include(x => x.TeachingPlanner)
                    .ThenInclude(tp => tp.Class)
                .Include(x => x.TeachingPlanner)
                    .ThenInclude(tp => tp.Subject)
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<IEnumerable<Document4>> GetDocument4sWithCondition(bool? status, int? isApprove)
        {
            IQueryable<Document4> query = _context.Document4s;
            if (status != null)
            {
                query = query.Where(x => x.Status == status);
            }
            if (isApprove != null)
            {
                query = query.Where(x => x.IsApprove == isApprove);
            }

            return await query
                .Include(x => x.TeachingPlanner)
                .ThenInclude(x => x.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Document4>> GetDocument4sByUserId(int userId, int approveid)
        {
            return await _context.Document4s
               .Include(x => x.TeachingPlanner)
               .Where(x => x.TeachingPlanner.UserId == userId && x.IsApprove == approveid)
               .ToListAsync();
        }

        public async Task<Document4> UpdateDocument4(Document4 pl4)
        {
            var existDocument4s = await GetDocument4ById(pl4.Id);
            if (existDocument4s == null)
            {
                return null;
            }

            var properties = typeof(Document4).GetProperties();
            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(pl4);
                if (updatedValue != null)
                {
                    property.SetValue(existDocument4s, updatedValue);
                }
            }
            await _context.SaveChangesAsync();
            return existDocument4s;
        }

        public async Task<IEnumerable<object>> GetDocument4ByUserSpecialiedDepartment(List<int> listId)
        {
            var result = new List<object>();
            foreach (var id in listId)
            {
                var documents = await _context.Document4s
                    .Include(x => x.TeachingPlanner)
                    .ThenInclude(x => x.User)
                    .Where(x => x.TeachingPlanner.User.DepartmentId == id && x.IsApprove == 3 && x.Status == true)
                    .ToListAsync();

                result.Add(new
                {
                    SpecializedDepartmentId = id,
                    Document4s = documents
                });
            }
            return result;
        }

        public async Task<IEnumerable<Document4>> GetDoc4sByDoc3Id(int doc3Id)
        {
            var doc3 = await _context.Document3s
                .Include(x => x.Document1)
                .FirstOrDefaultAsync(x => x.Id == doc3Id);

            if (doc3 == null)
                return Enumerable.Empty<Document4>();

            var classId = await ConvertSubjectNameToSubjectId(doc3.ClaasName);

            var doc4 = await _context.Document4s
                .Include(x => x.TeachingPlanner)
                .Where(x => x.TeachingPlanner.UserId == doc3.UserId &&
                            x.TeachingPlanner.ClassId == classId &&
                            x.TeachingPlanner.SubjectId == doc3.Document1.SubjectId && 
                            x.IsApprove == 3)
                .ToListAsync();

            return doc4;
        }

        public async Task<int> ConvertSubjectNameToSubjectId(string classname)
        {
            var @class = await _context.Classes
                .Where(x => x.Name == classname)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            return @class;
        }
    }
}

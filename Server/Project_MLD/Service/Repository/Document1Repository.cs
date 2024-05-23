using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document1Repository : IDocument1Repository
    {
        private readonly MldDatabase2Context _context;

        public Document1Repository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<Document1> AddDocument1(Document1 document1)
        {
            _context.Document1s.Add(document1);
            await _context.SaveChangesAsync();
            return document1;
        }

        public async Task<bool> DeleteDocument1(int id)
        {
            var document1 = await GetDocument1ById(id);
            if (document1 == null)
            {
                return false;
            }
            _context.Document1s.Remove(document1);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Document1>> GetAllDocument1s()
        {
            return await _context.Document1s
                .Include(x => x.Grade)
                .Include(x => x.Subject)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Document1>> GetAllDoc1sByUserIdAndApproveId(int userId, int approveId)
        {
            return await _context.Document1s
                .Include(x => x.Grade)
                .Include(x => x.Subject)
                .Include(x => x.User)
                .Where(x => x.UserId == userId && x.IsApprove == approveId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Document1>> FilterAllDoc1(int gradeId, int subjectId)
        {
            return await _context.Document1s
                .Include(x => x.User)
                .Include(x => x.Grade)
                .Include(x => x.Subject)
                .Where(x => x.GradeId == gradeId || x.SubjectId == subjectId)
                .ToListAsync();
        }

        public async Task<Document1> GetDocument1ById(int id)
        {
            var doc = await _context.Document1s
                .Include(x => x.User)
                .Include(x => x.Grade)
                .Include(x => x.Subject)
                .FirstOrDefaultAsync(x => x.Id == id);
            return doc;
        }

        public async Task<bool> UpdateDocument1(Document1 document1)
        {
            var existDocument1 = await _context.Document1s.FindAsync(document1.Id);
            if (existDocument1 == null)
            {
                return false;
            }

            var entityType = typeof(Document1);
            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                var newValue = property.GetValue(document1);
                if (newValue != null)
                {
                    property.SetValue(existDocument1, newValue);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<object>> GetDoc1ByUserDepartment(List<int> listID)
        {
            var listObject = new List<object>();

            foreach (var id in listID)
            {
                var documents = await _context.Document1s
                    .Include(x => x.User)
                    .Include(x => x.Grade)
                    .Include(x => x.Subject)
                    .Where(x => x.User.DepartmentId == id && x.Status == true && x.IsApprove == 3)
                    .ToListAsync();

                var anObject = new
                {
                    id = id,
                    document = documents
                };

                listObject.Add(anObject);
            }

            return listObject;
        }

        public async Task<IEnumerable<Document1>> GetAllDoc1sWithCondition(bool? status, int? isApprove)
        {
            IQueryable<Document1> query = _context.Document1s;

            if (status != null)
            {
                query = query.Where(x => x.Status == status);
            }

            if (isApprove != null)
            {
                query = query.Where(x => x.IsApprove == isApprove);
            }

            return await query
                .Include(x => x.User)
                .Include(x => x.Grade)
                .Include(x => x.Subject)
                .ToListAsync();
        }

        public async Task<IEnumerable<Document1>> GetAllDoc1sBySubjectId(int subjectId)
        {
            return await _context.Document1s
                .Include(x => x.User)
                .Include(x => x.Grade)
                .Include(x => x.Subject)
                .Where(x => x.SubjectId == subjectId && x.IsApprove == 3)
                .ToListAsync();

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document3Repository : IDocument3Repository
    {
        private readonly MldDatabase2Context _context;

        public Document3Repository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<Document3> AddDocument3(Document3 pl3)
        {
            _context.Document3s.Add(pl3);
            await _context.SaveChangesAsync();
            return pl3;
        }

        public async Task<bool> DeleteDocument3(int id)
        {
            var existDocument3 = await GetDocument3ById(id);
            if (existDocument3 == null)
            {
                return false;
            }
            _context.Document3s.Remove(existDocument3);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Document3>> GetAllDoc3sByDoc1Id(int doc1Id)
        {
            return await _context.Document3s
                .Include(x => x.User)
                .Include(x => x.Document1)
                .Where(x => x.Document1Id == doc1Id && x.IsApprove == 3)
                .ToListAsync();
        }

        public async Task<IEnumerable<Document3>> GetAllDoc3sWithCondition(bool? status, int? isApprove)
        {
            IQueryable<Document3> query = _context.Document3s;
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
               .Include(x => x.Document1)
               .ToListAsync();
        }

        public async Task<IEnumerable<Document3>> GetAllDocument3s()
        {
            return await _context.Document3s
                .Include(x => x.User)
                .Include(x => x.Document1)
                .ToListAsync();
        }

        public async Task<IEnumerable<Document3>> GetAllDocument3sByUserIdAndApproveId(int id, int approveId)
        {
            return await _context.Document3s
                .Include(x => x.User)
                .Include(x => x.Document1)
                .Where(x => x.UserId == id && x.IsApprove == approveId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Document3>> GetDocument3ByApprovalID(int id)
        {
            return await _context.Document3s
                .Include(x => x.User)
                .Include(x => x.Document1)
                .Where(x => x.IsApprove == id)
                .ToListAsync();
        }

        public async Task<Document3> GetDocument3ById(int id)
        {
            return await _context.Document3s
                .Include(x => x.Document1)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<object>> GetDocument3ByUserSpecialiedDepartment(List<int> listId)
        {
            var listObject = new List<object>();

            foreach (var id in listId)
            {
                var documents = await _context.Document3s
                .Include(x => x.User)

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

        public async Task<IEnumerable<Document3>> GetDocument3sByCondition(string condition)
        {
            return await _context.Document3s
                .Include(x => x.User)
                .Where(x => x.Name == condition ||
                x.User.FirstName.Contains(condition) ||
                x.User.LastName.Contains(condition))
                .ToListAsync();
        }

        public async Task<bool> UpdateDocument3(Document3 pl3)
        {
            var existDocument3s = await GetDocument3ById(pl3.Id);
            if (existDocument3s == null)
            {
                return false;
            }

            var properties = typeof(Document3).GetProperties();
            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(pl3);
                if (updatedValue != null)
                {
                    property.SetValue(existDocument3s, updatedValue);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}

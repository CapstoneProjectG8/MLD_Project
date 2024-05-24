using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document2Repository : IDocument2Repository
    {
        private readonly MldDatabase2Context _context;

        public Document2Repository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<Document2> AddDocument2(Document2 pl2)
        {
            _context.Document2s.Add(pl2);
            await _context.SaveChangesAsync();
            return pl2;
        }

        public async Task<bool> DeleteDocument2(int id)
        {
            var existDocument2 = await GetDocument2ById(id);
            if (existDocument2 == null)
            {
                return false;
            }
            _context.Document2s.Remove(existDocument2);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Document2>> GetAllDocument2s()
        {
            return await _context.Document2s
                .Include(x => x.User).ToListAsync();
        }

        public async Task<Document2> GetDocument2ById(int id)
        {
            return await _context.Document2s
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Document2>> GetDocument2ByCondition(string condition)
        {
            return await _context.Document2s
                .Include(x => x.User)
                .Where(x => x.Name == condition ||
                x.User.FirstName.Contains(condition) ||
                x.User.LastName.Contains(condition))
                .ToListAsync();
        }

        public async Task<bool> UpdateDocument2(Document2 pl2)
        {
            var existDocument2 = await GetDocument2ById(pl2.Id);
            if (existDocument2 == null)
            {
                return false;
            }

            var properties = typeof(Document2).GetProperties();
            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(pl2);
                if (updatedValue != null)
                {
                    property.SetValue(existDocument2, updatedValue);
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<object>> GetDocument2ByUserSpecialiedDepartment(List<int> listId)
        {
            var listObject = new List<object>();
            foreach (var id in listId)
            {
                var documents = await _context.Document2s
                .Include(x => x.User)
                .Where(x => x.Status == true && x.User.DepartmentId == id && x.IsApprove == 3)
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

        public async Task<IEnumerable<Document2>> GetAllDocument2sByUserIdAndApproveId(int id, int approveId)
        {
            return await _context.Document2s
                .Include(x => x.User)
                .Where(x => x.UserId == id && x.IsApprove == approveId)
                .ToListAsync();
        }

        public async Task<IEnumerable<int?>> GetListHostbyByIdOfUserByDoc2Id(int doc2Id)
        {
            var hostIds = await _context.Document2Grades
                .Where(x => x.Document2Id == doc2Id)
                .Select(x => x.HostBy)
                .Distinct()
                .ToListAsync();

            return hostIds;
        }

        public async Task<IEnumerable<Document2>> GetAllDoc2sByCondition(bool? status, int? isApprove)
        {
            IQueryable<Document2> query = _context.Document2s;
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
                .ToListAsync();
        }

        public async Task<IEnumerable<Document2>> GetDoc2sByDepId(int depId)
        {
            return await _context.Document2s
                .Include(x => x.User)
                .Where(x => x.User.DepartmentId == depId && x.IsApprove == 3)
                .ToListAsync();
        }
    }
}

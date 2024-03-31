using Project_MLD.Models;
using Project_MLD.Service.Interface;

using System.Drawing.Printing;

namespace Project_MLD.Service.Repository
{
    public class DocRepository : IDocRepository
    {
        private readonly MldDatabaseContext _context;

        public DocRepository(MldDatabaseContext context)
        {
            _context = context;
        }
        public Task<Doc> AddDoc(Doc d)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDoc(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Doc>> GetAllDocs()
        {
            throw new NotImplementedException();
        }

        public Task<Doc> GetDocById(int id)
        {
            throw new NotImplementedException();
        }

        public void ExportPDF(string html)
        {
            

        }
    }
}

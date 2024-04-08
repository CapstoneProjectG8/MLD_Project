using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document2GradeRepository : IDocument2GradeRepository
    {
        private readonly MldDatabaseContext _context;

        public Document2GradeRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public Task DeleteDocument2Grade(List<Document2Grade> list)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Document2Grade>> GetAllDocuemnt2Grades()
        {
            return await _context.Document2Grades.ToListAsync();
        }

        public async Task<IEnumerable<Document2Grade>> GetDocument2GradeByDocument2Id(int id)
        {
            return await _context.Document2Grades
                .Where(x => x.Document2Id == id).ToListAsync();
        }

        public async Task UpdateDocument2Grade(List<Document2Grade> list)
        {
            try
            {
                foreach (var item in list)
                {
                    var existDocument2Grade = await _context.Document2Grades
                        .FindAsync(item.Document2Id, item.GradeId);
                    if (existDocument2Grade == null)
                    {
                        var newItem = new Document2Grade
                        {
                            Document2Id = item.Document2Id,
                            GradeId = item.GradeId,
                            TitleName = item.TitleName,
                            Slot = item.Slot,
                            Time = item.Time,
                            Place = item.Place,
                            HostBy = item.HostBy,
                            Description = item.Description,
                            CollaborateWith = item.CollaborateWith,
                            Condition = item.Condition
                        };
                        _context.Document2Grades.Add(newItem);
                    }
                    else
                    {
                        existDocument2Grade.TitleName = item.TitleName;
                        existDocument2Grade.Slot = item.Slot;
                        existDocument2Grade.Time = item.Time;
                        existDocument2Grade.Place = item.Place;
                        existDocument2Grade.HostBy = item.HostBy;
                        existDocument2Grade.Description = item.Description;
                        existDocument2Grade.CollaborateWith = item.CollaborateWith;
                        existDocument2Grade.Condition = item.Condition;
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating Document2 Grades.", ex);
            }
        }
    }


}

using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document2GradeRepository : IDocument2GradeRepository
    {
        private readonly MldDatabaseContext2 _context;

        public Document2GradeRepository(MldDatabaseContext2 context)
        {
            _context = context;
        }

        public async Task<Document2Grade> AddDocument2Grade(Document2Grade document2Grade)
        {
            _context.Document2Grades.Add(document2Grade);
            await _context.SaveChangesAsync();
            return document2Grade;
        }

        public async Task DeleteDocument2Grade(List<Document2Grade> list)
        {
            if (list == null || !list.Any())
            {
                return; // Nothing to delete
            }

            foreach (var item in list)
            {
                var existingItem = await _context.Document2Grades
                  .FindAsync(item.Document2Id, item.GradeId);

                if (existingItem != null)
                {
                    _context.Document2Grades.Remove(existingItem);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocument2GradeByDoc2Id(int id)
        {
            var items = await _context.Document2Grades
                .Where(x => x.Document2Id == id).ToListAsync();
            if(items != null)
            {
                _context.RemoveRange(items);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Document2Grade>> GetAllDocuemnt2Grades()
        {
            return await _context.Document2Grades
                .Include(x => x.Grade)
                .Include(x => x.Document2)
                .ToListAsync();
        }

        public async Task<IEnumerable<Document2Grade>> GetDocument2GradeByDocument2Id(int id)
        {
            return await _context.Document2Grades
                .Include(x => x.Grade)
                .Include(x => x.Document2)
                .Where(x => x.Document2Id == id).ToListAsync();
        }

        public async Task UpdateDocument2Grade(List<Document2Grade> list)
        {
            try
            {
                foreach (var item in list)
                {
                    var existGrade = await _context.Grades.FindAsync(item.GradeId);
                    if (existGrade == null)
                    {
                        throw new Exception("There is no exist Grade");
                    }
                    var existDocument2Grade = await _context.Document2Grades
                        .FindAsync(item.Document2Id, existGrade.Id);
                    if (existDocument2Grade == null)
                    {
                        var newItem = new Document2Grade
                        {
                            Document2Id = item.Document2Id,
                            GradeId = existGrade.Id,
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
                throw new Exception(ex.Message);
            }
        }
    }


}

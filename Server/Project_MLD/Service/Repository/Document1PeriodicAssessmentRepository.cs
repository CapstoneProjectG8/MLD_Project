using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Project_MLD.Service.Repository
{
    public class Document1PeriodicAssessmentRepository : IDocument1PeriodicAssessmentRepository
    {
        private readonly MldDatabaseContext _context;

        public Document1PeriodicAssessmentRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PeriodicAssessment>> GetPeriodicAssessmentByDocument1Id(int id)
        {
            var pa = await _context.PeriodicAssessments
                .Where(x => x.Document1Id == id)
                .ToListAsync();
            return pa;
        }

        public async Task UpdateDocument1PeriodicAssessment(List<PeriodicAssessment> list)
        {
            try
            {
                foreach (var item in list)
                {
                    var existFormCategory = await _context.FormCategories.FindAsync(item.FormCategoryId);
                    if (existFormCategory == null)
                    {
                        throw new Exception("There is no exist Form Category");
                    }
                    var existTestingCategory = await _context.TestingCategories.FindAsync(item.TestingCategoryId);
                    if (existTestingCategory == null)
                    {
                        throw new Exception("There is no exist Testing Category");
                    }

                    var existPeriodicAssessment = await _context.PeriodicAssessments
                        .FindAsync(item.Document1Id, item.FormCategoryId,item.TestingCategoryId);
                    if (existPeriodicAssessment == null)
                    {
                        var newItem = new PeriodicAssessment
                        {
                            Document1Id = item.Document1Id,
                            TestingCategoryId = item.TestingCategoryId,
                            FormCategoryId = item.FormCategoryId,
                            Time = item.Time,
                            Date = item.Date,
                            Description = item.Description
                        };
                        _context.PeriodicAssessments.Add(newItem);
                    }
                    else
                    {
                        existPeriodicAssessment.Time = item.Time;
                        existPeriodicAssessment.Date = item.Date;
                        existPeriodicAssessment.Description = item.Description;
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating Periodic Assessments.", ex);
            }
        }

        public async Task DeleteDocument1PeriodicAssessment(List<PeriodicAssessment> list)
        {
            if (list == null || !list.Any())
            {
                throw new Exception("An error occurred while delete Periodic Assessments.");
            }

            foreach (var item in list)
            {
                var existingItem = await _context.Document1CurriculumDistributions
                  .FindAsync(item.Document1Id, item.FormCategoryId, item.TestingCategoryId);

                if (existingItem != null)
                {
                    _context.Document1CurriculumDistributions.Remove(existingItem);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PeriodicAssessment>> GetAllPeriodicAssessment()
        {
            var pa = await _context.PeriodicAssessments.ToListAsync();
            return pa;
        }
    }
}

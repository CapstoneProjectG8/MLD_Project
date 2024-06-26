﻿using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;
using System.Data;

namespace Project_MLD.Service.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly MldDatabase2Context _context;

        public ReportRepository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<Report> AddReport(Report cl)
        {
            _context.Reports.Add(cl);
            await _context.SaveChangesAsync();
            return cl;
        }

        public async Task<IEnumerable<Report>> GetAllReports()
        {
            return await _context.Reports.OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<Report> GetReportById(int id)
        {
            return await _context.Reports.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateReport(Report cl)
        {
            var existFB = await _context.Reports.FindAsync(cl.Id);
            if (existFB == null)
            {
                return false;
            }

            var entityType = typeof(Report);
            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                var newValue = property.GetValue(cl);
                if (newValue != null)
                {
                    property.SetValue(existFB, newValue);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}

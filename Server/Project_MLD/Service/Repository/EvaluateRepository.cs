using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class EvaluateRepository : IEvaluateRepository
    {
        private readonly MldDatabase2Context _context;

        public EvaluateRepository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<Evaluate> AddEvaluate(Evaluate acc)
        {
            _context.Evaluates.Add(acc);
            await _context.SaveChangesAsync();
            return acc;
        }

        public async Task<bool> DeleteEvaluate(int id)
        {
            var existEvaluate = await GetEvaluateById(id);
            if (existEvaluate == null)
            {
                return false;
            }
            _context.Evaluates.Remove(existEvaluate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Evaluate>> GetAllEvaluates()
        {
            return await _context.Evaluates.ToListAsync();
        }

        public async Task<Evaluate> GetEvaluateById(int id)
        {
            return await _context.Evaluates.FindAsync(id);
        }

        public async Task<bool> UpdateEvaluate(Evaluate eva)
        {
            var existEvaluate = await GetEvaluateById(eva.Id);
            if (existEvaluate == null)
            {
                return false;
            }
            var properties = typeof(Evaluate).GetProperties();
            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(eva);
                if (updatedValue != null)
                {
                    property.SetValue(existEvaluate, updatedValue);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class LevelOfTrainningRepository : ILevelOfTrainningRepository
    {
        private readonly MldDatabaseContext2 _context;

        public LevelOfTrainningRepository(MldDatabaseContext2 context)
        {
            _context = context;
        }

        public async Task<LevelOfTrainning> AddLevelOfTrainning(LevelOfTrainning lt)
        {
            _context.LevelOfTrainnings.Add(lt);
            await _context.SaveChangesAsync();
            return lt;
        }

        public async Task<bool> DeleteLevelOfTrainning(int id)
        {
            var existLt = await GetLevelOfTrainningById(id);
            if (existLt == null)
            {
                return false;
            }
            _context.LevelOfTrainnings.Remove(existLt);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<LevelOfTrainning>> GetAllLevelOfTrainnings()
        {
            return await _context.LevelOfTrainnings.ToListAsync();
        }

        public async Task<LevelOfTrainning> GetLevelOfTrainningById(int id)
        {
            return await _context.LevelOfTrainnings.FindAsync(id);
        }

        public async Task<bool> UpdateLevelOfTrainning(LevelOfTrainning lt)
        {
            var existLt = await GetLevelOfTrainningById(lt.Id);
            if (existLt == null)
            {
                return false;
            }

            _context.Entry(existLt).CurrentValues.SetValues(lt);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

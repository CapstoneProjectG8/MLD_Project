﻿using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly MldDatabaseContext _context;

        public GradeRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Grade> AddGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();
            return grade;
        }

        public async Task<bool> DeleteGrade(int id)
        {
            var existGrade = await GetGradeById(id);
            if (existGrade == null)
            {
                return false;
            }
            _context.Grades.Remove(existGrade);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Grade>> GetAllGrades()
        {
            return await _context.Grades.ToListAsync();
        }

        public async Task<Grade> GetGradeById(int id)
        {
            return await _context.Grades.FindAsync(id);
        }

        public async Task<bool> UpdateGrade(Grade grade)
        {
            var existGrade = await GetGradeById(grade.Id);
            if (existGrade == null)
            {
                return false;
            }

            _context.Entry(existGrade).CurrentValues.SetValues(grade);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetTotalClassByGradeId(int id)
        {
            var classes = await _context.Classes
                .Where(x => x.GradeId == id).CountAsync();
            return classes;
        }

        public async Task<int> GetTotalStudentByGradeId(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if(grade == null)
            {
                return 0;
            }
            var totalStudet = grade.TotalStudent;
            return (int)totalStudet;

        }

        public async Task<int> GetTotalStudentSelectedTopicsByGradeId(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
            {
                return 0;
            }
            var totalStudetSelected = grade.TotalStudentSelectedTopics;
            return (int)totalStudetSelected;

        }
    }
}

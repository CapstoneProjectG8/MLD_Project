﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly MldDatabase2Context _context;

        public GradeRepository(MldDatabase2Context context)
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

            var properties = typeof(Grade).GetProperties();
            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(grade);
                if (updatedValue != null)
                {
                    property.SetValue(existGrade, updatedValue);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetTotalClassByGradeId(int id)
        {
            var totalClass = await _context.Classes
                .Where(x => x.GradeId == id).CountAsync();

            return (int)totalClass;
        }

        public async Task<int> GetTotalStudentByGradeId(int id)
        {
            var totalStudent = await _context.Classes
                .Where(x => x.GradeId == id)
                .SumAsync(x => x.TotalStudent);

            return (int)totalStudent;

        }

        public async Task<int> GetTotalStudentSelectedTopicsByGradeId(int id)
        {
            var totalStudentSt = await _context.Classes
                .Where(x => x.GradeId == id)
                .SumAsync(x => x.TotalStudentSelectedTopics);

            return (int)totalStudentSt;
        }
    }
}

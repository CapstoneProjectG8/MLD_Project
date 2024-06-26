﻿using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class SelectedTopicRepository : ISelectedTopicsRepository
    {
        private readonly MldDatabase2Context _context;

        public SelectedTopicRepository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<SelectedTopic> AddSelectedTopic(SelectedTopic st)
        {
            _context.SelectedTopics.Add(st);
            await _context.SaveChangesAsync();
            return st;
        }

        public async Task<bool> DeleteSelectedTopic(int id)
        {
            var existSelectedTopic = await GetSelectedTopicById(id);
            if (existSelectedTopic == null)
            {
                return false;
            }
            _context.SelectedTopics.Remove(existSelectedTopic);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SelectedTopic>> GetAllSelectedTopics()
        {
            return await _context.SelectedTopics.ToListAsync();
        }

        public async Task<SelectedTopic> GetSelectedTopicById(int id)
        {
            return await _context.SelectedTopics.FindAsync(id);
        }

        public async Task<IEnumerable<SelectedTopic>> GetSelectedTopicsBySubjectId(int subjectId)
        {
            return await _context.SelectedTopics.Where(x => x.SubjectId == subjectId).ToListAsync();
        }

        public async Task<bool> UpdateSelectedTopic(SelectedTopic st)
        {
            var existSelectedTopic = await GetSelectedTopicById(st.Id);
            if (existSelectedTopic == null)
            {
                return false;
            }

            var properties = typeof(SelectedTopic).GetProperties();
            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(st);
                if (updatedValue != null)
                {
                    property.SetValue(existSelectedTopic, updatedValue);
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

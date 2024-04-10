﻿using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MldDatabaseContext _context;

        public AccountRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Account> AddAccount(Account acc)
        {
            _context.Accounts.Add(acc);
            await _context.SaveChangesAsync();
            return acc;
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var existAccount = await GetAccountById(id);
            if (existAccount == null)
            {
                return false;
            }
            _context.Accounts.Remove(existAccount);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetAccountById(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<bool> UpdateAccount(Account acc)
        {
            var existAccount = await GetAccountById(acc.AccountId);
            if (existAccount == null)
            {
                return false;
            }
            var properties = typeof(Account).GetProperties();
            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(acc);
                if (updatedValue != null)
                {
                    property.SetValue(existAccount, updatedValue);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public Account GetAccountByUsername(string username)
        {
            var existAccount = _context.Accounts.FirstOrDefault(x => x.Username == username);
            if (existAccount == null)
            {
                return null;
            }
            return existAccount;
        }
    }
}

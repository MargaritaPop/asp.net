using Lab4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Services
{
    public abstract class AbstractCrudDbDataStore<T> : IDataStore<T> where T : class
    {
        protected ApplicationContext applicationContext;

        public AbstractCrudDbDataStore(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public virtual async Task<bool> AddItemAsync(T item)
        {
            try
            {
                await applicationContext.AddAsync(item);
                await applicationContext.SaveChangesAsync();
                return await Task.FromResult(true);
            } catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }


        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            applicationContext.Remove(await GetItemAsync(id));
            await applicationContext.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await applicationContext.FindAsync<T>(id);
        }

        public virtual async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            return await applicationContext.Set<T>().ToListAsync();
        }

        public virtual async Task<bool> UpdateItemAsync(T item)
        {
            applicationContext.Update(item);
            await applicationContext.SaveChangesAsync();
            return await Task.FromResult(true);
        }
    }
}

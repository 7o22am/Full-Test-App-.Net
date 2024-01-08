using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Repository.Base;

namespace WebApplication1.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        public MainRepository(AppDbContext Context ) { 
        this.Context = Context; 
        
        }
        protected AppDbContext Context;
        public T FinedbyId(int id)
        {

            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public async Task<T> FinedbyIdAsync(int id)
        {
            return  await Context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }
    }
}

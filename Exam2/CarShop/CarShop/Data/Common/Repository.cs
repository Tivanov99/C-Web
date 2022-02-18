namespace CarShop.Data.Common
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class Repository : IRepository
    {
        private readonly ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            this.dbContext.Add<T>(entity);
            this.SaveChanges();
        }

        public IQueryable<T> All<T>() where T : class
        => DbSet<T>().AsQueryable();

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
        private DbSet<T> DbSet<T>() where T : class
        {
            return this.dbContext.Set<T>();
        }
    }
}

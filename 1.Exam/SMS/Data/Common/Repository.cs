namespace SMS.Data.Common
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class Repository : IRepository
    {
        private readonly SMSDbContext dbContext;

        public Repository(SMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            this.DbSet<T>().Add(entity);
            this.SaveChanges();
        }

        public IQueryable<T> All<T>() where T : class
           => this.DbSet<T>().AsQueryable();

        public int SaveChanges()
        => this.dbContext.SaveChanges();

        private DbSet<T> DbSet<T>() where T : class
        {
            return this.dbContext.Set<T>();
        }
    }
}

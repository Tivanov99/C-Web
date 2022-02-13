namespace Git.Repository
{
    using Git.Contracts;
    using Git.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class Repository : IRepository
    {
        private readonly ApplicationDbContext dbContext;
        public Repository(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            this.dbContext.Add<T>(entity);
            this.dbContext.SaveChanges();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }
        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
    }
}

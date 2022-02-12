namespace Git.Repository
{
    using Git.Contracts;
    using Git.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
            return this.dbContext.Set<T>();
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }
    }
}

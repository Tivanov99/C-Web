namespace Git.Repository
{
    using Git.Contracts;
    using Git.Data;
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
            return this.dbContext.Set<T>();
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }
    }
}

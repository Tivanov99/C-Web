namespace CarShop.Services
{
    using CarShop.Data;
    using CarShop.DTOS;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class IssueService : IIssueService
    {
        private ApplicationDbContext context;

        public IssueService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CreateCarIssue(string carId)
        {
            throw new System.NotImplementedException();
        }

        public List<IssueDTO> GetCarIssues(string carId)
        => this.context
            .Issues
            .AsNoTracking()
            .Where(i => i.CarId == carId)
            .Select(i => new IssueDTO()
            {
                Id = i.Id,
                Description = i.Description,
                IsFixed = i.IsFixed,
            })
            .ToList();
    }
}

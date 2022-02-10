namespace CarShop.Services
{
    using CarShop.Data;
    using CarShop.Data.DbModels;
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

        public void CreateCarIssue(string carId, string description)
        {
            this.context
               .Issues
               .Add(new Issue()
               {
                   CarId = carId,
                   Description = description,
                   IsFixed = false
               });

            this.context.SaveChanges();
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

        public IssueCarDto GetIssueCar(string carId)
        => this.context
            .Cars
            .Where(c => c.Id == carId)
            .Select(c => new IssueCarDto()
            {
                CarModel = c.Model,
                CarYear = c.Year,
            })
            .FirstOrDefault();
    }
}

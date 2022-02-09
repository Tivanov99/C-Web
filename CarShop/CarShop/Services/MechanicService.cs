namespace CarShop.Services
{
    using CarShop.Data;
    using CarShop.DTOS;
    using System.Collections.Generic;
    using System.Linq;

    public class MechanicService : IMechanicService
    {
        private ApplicationDbContext context;
        public MechanicService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void FixCarIssue(string issueId)
        {
            var issue = this.context
                  .Issues
                  .Where(i => i.Id == issueId)
                  .Select(i => i)
                  .FirstOrDefault();

            issue.IsFixed = true;

            this.context.SaveChanges();
        }

        public List<CarDetailsDTOModel> GetAllCarsWithUnfixedIssues()
        => this.context
            .Cars
            .Where(c => c.Issues.Any(i => i.IsFixed == false))
            .Select(c => new CarDetailsDTOModel()
            {
                Id = c.Id,
                Model = c.Model,
                Year = c.Year,
                PictureUrl = c.PictureUrl,
                PlateNumber = c.PlateNumber,
                Issues = c.Issues,
            })
            .ToList();
    }
}

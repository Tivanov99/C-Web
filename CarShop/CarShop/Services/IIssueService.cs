using CarShop.DTOS;
using System.Collections.Generic;

namespace CarShop.Services
{
    public interface IIssueService
    {
        List<IssueDTO> GetCarIssues(string carId);

        void CreateCarIssue(string carId);

        IssueCarDto GetIssueCar(string carId);
    }
}

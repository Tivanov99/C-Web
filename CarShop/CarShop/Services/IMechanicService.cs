using CarShop.DTOS;
using System.Collections.Generic;

namespace CarShop.Services
{
    public interface IMechanicService
    {
        List<CarDetailsDTOModel> GetAllCarsWithUnfixedIssues();

        void FixCarIssue(string issueId);
    }
}

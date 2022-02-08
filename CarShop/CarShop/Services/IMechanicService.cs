using CarShop.DTOS;
using System.Collections.Generic;

namespace CarShop.Services
{
    public interface IMechanicService
    {
        List<CarDTOModel> GetAllCarsWithUnfixedIssues();

        void FixCarIssue(string issueId);
    }
}

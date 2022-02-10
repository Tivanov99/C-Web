namespace CarShop.ViewModels
{
    using CarShop.DTOS;
    using System.Collections.Generic;

    public class AllIssuesModel
    {
        public AllIssuesModel()
        {
            Issues = new();
        }

        public List<IssueDTO> Issues { get; set; }

        public string CarId { get; set; }

        public string CarModel { get; set; }

        public int CarYear { get; set; }
    }
}

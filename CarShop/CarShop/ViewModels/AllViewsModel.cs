namespace CarShop.ViewModels
{
    using CarShop.DTOS;
    using System.Collections.Generic;

    public class AllViewsModel
    {
        public AllViewsModel()
        {
            Issues = new();
        }

        public List<IssueDTO> Issues { get; set; }
    }
}

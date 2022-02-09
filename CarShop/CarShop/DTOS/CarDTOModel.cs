namespace CarShop.DTOS
{
    public class CarDTOModel
    {
        public string Id { get; set; }

        public string PlateNumber { get; set; }

        public int RemainingIssues { get; set; }

        public int FixedIssues { get; set; }
    }
}

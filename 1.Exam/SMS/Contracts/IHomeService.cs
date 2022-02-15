namespace SMS.Contracts
{
    using SMS.Models;
    using System.Collections.Generic;
    public interface IHomeService
    {
        List<ProductViewModel> GetAll();
    }
}

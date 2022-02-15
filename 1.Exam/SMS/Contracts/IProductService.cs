namespace SMS.Contracts
{
    using SMS.Models;

    public interface IProductService
    {
        void Create(CreateProductModel createProductModel);
    }
}

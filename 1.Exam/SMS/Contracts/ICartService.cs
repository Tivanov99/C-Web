namespace SMS.Contracts
{
    using SMS.Models;
    using System.Collections.Generic;

    public interface ICartService
    {
        List<CartProductModel> AllProducts(string userId);

        void BuyAll(string userId);
    }
}

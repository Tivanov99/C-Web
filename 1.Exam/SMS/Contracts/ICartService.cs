namespace SMS.Contracts
{
    using SMS.Models;
    using System.Collections.Generic;

    public interface ICartService
    {
        List<CartProductModel> AllProducts();
        void BuyAll(string userId);
    }
}

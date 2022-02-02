using MyWebServer.Common;

namespace SMS.Validator
{
    public static class ItemDataValidator
    {
        public static bool IsValidItemData(string productName, decimal productPrice)
        {
            if (productName.Length < GlobalConstants.productNameMinLength ||
                productName.Length > GlobalConstants.productNameMaxLength)
            {
                return false;
            }

            if(productPrice<GlobalConstants.productMinPrice ||
                productPrice> GlobalConstants.productMaxPrice)
            {
                return false;
            }

            return true;
        }
    }
}

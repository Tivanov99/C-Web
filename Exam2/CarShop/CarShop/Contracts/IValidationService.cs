namespace CarShop.Contracts
{
    public interface IValidationService
    {
        (bool isValid, string error) Validate(object obj);
    }
}

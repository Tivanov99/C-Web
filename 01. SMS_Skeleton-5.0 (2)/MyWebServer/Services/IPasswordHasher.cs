namespace MyWebServer.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}

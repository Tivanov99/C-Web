namespace MyWebServer.Services
{
    using Git.Contracts;
    using Git.Data.Models;
    using MyWebServer.DataForm;
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UserService : IUserService
    {
        private readonly IRepository repository;
        public UserService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public void CreateUser(RegisterDataForm registerDataForm)
        {
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Username = registerDataForm.Username,
                Email = registerDataForm.Email,
                Password = registerDataForm.Password,
            };
            this.repository.Add<User>(user);
            this.repository.SaveChanges();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool IsUserExists(LoginDataForm loginDataForm)
         => this.repository.All<User>()
            .Any(x => x.Username == loginDataForm.Username &&
            x.Password == HashPassword(loginDataForm.Password));
    }
}

using Commander.Security.IService;

namespace Commander.Security.Service
{
    public class UserService : IUserService
    {
        public bool CheckUser(string username, string password)
        {
            return username.Equals("Glebyshka") && password.Equals("12345");
        }
    }
}

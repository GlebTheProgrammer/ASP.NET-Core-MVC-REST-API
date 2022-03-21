namespace Commander.Security.IService
{
    public interface IUserService
    {
        bool CheckUser(string username, string password);
    }
}

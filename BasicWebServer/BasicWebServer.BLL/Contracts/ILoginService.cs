namespace BasicWebServer.BLL.Contracts
{
    public interface ILoginService
    {
        void SetSession();

        void QueryUserData();
    }
}

using WorkshopTest.Models;

namespace WorkshopTest.Session
{
    public interface ISessionContext
    {
        //void SetCurrentUser(UserSessionModel model);
        //UserSessionModel GetCurrentUser();

        UserSessionModel CurrentUser { get; set; }

        void Logout();

    }
}

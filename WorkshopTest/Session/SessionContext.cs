using Microsoft.AspNetCore.Http;
using System;
using WorkshopTest.Extenstions;
using WorkshopTest.Models;

namespace WorkshopTest.Session
{
    public class SessionContext : ISessionContext
    {
        private readonly ISession session;

        public SessionContext(IHttpContextAccessor httpContextAccessor)
        {
            session = httpContextAccessor?.HttpContext?.Session;
        }

        public UserSessionModel GetCurrentUser()
        {
            return session.GetJson<UserSessionModel>(nameof(UserSessionModel));
        }

        public void SetCurrentUser(UserSessionModel model)
        {
            session.SetJson(nameof(UserSessionModel), model);
        }

        public UserSessionModel CurrentUser { 
            get => session.GetJson<UserSessionModel>(nameof(UserSessionModel));
            set => session.SetJson(nameof(UserSessionModel), value);
        }

        public void Logout()
        {
            session.Clear();
        }
    }
}

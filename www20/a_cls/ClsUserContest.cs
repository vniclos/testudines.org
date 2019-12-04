using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace testudines.cls
{


    public class ClsUserContest
    {
        private string m_UserName = "";
        private String m_UserRole = "";

        private bool m_IsApproved = false;
        private bool m_IsAdmin = false;
        private bool m_IsOnline = false;
        private String m_SessionId = "";
        public ClsUserContest()
        {
            FncGetUserCurrent();
        }
        private void FncGetUserCurrent()
        {
            m_UserName = string.Empty;
            m_IsApproved = false;
            m_IsAdmin = false;
            m_IsOnline = false;
            

            if (System.Web.HttpContext.Current != null &&
                System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                System.Web.Security.MembershipUser usr = Membership.GetUser();
                if (usr != null)
                {
                    m_UserName = usr.UserName.ToString();
                    m_IsApproved = usr.IsApproved;
                    m_IsAdmin = Roles.IsUserInRole("Admin");
                    m_IsOnline = usr.IsOnline;
                        m_SessionId = System.Web.HttpContext.Current.Session.SessionID;
                    }
            }

        }

       
    public bool IsAdmin { get{ return m_IsAdmin; } }
    public bool IsApproved { get { return m_IsApproved; } }
    public String UserName { get { return m_UserName; } }
        public bool IsOnline { get { return m_IsOnline; } } 
        public String SessionId { get { return m_SessionId; } }

        
       
    }
}
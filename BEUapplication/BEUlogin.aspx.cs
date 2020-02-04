using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace BEUapplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            dsUser dsUserlogin;

            string SecurityLevel;

            dsUserlogin = DataLayer.VerifyUser(Server.MapPath("BEUbusinessBB1.mdb"),
                            Login1.username);

            if (dsUser.admin.Count < 1)
            {
                e.Authenticated = false;

                if (clsBusinessLayer.SendEmail("youremail@yourdomain.com",
               "receiver@receiverdomain.com", "", "", "Login Incorrect",
               "The login failed for UserName: " + Login1.UserName +
               " Password: " + Login1.Password))
                {

                    Login1.FailureText = Login1.FailureText +
                    " Your incorrect login information was sent to receiver@receiverdomain.com";

                }



                return;
            }


            SecurityLevel = dsUser.admin[0].SecurityLevel.ToString();



            switch (SecurityLevel)
            {

                case "A":
                    e.Authenticated = true;
                    FormsAuthentication.RedirectFromLoginPage(Login1.username, false);
                    Session["SecurityLevel"] = "A";
                    break;
                case "U":
                    e.Authenticated = true;
                    FormsAuthentication.RedirectFromLoginPage(Login1.username, false);
                    Session["SecurityLevel"] = "U";
                    break;
                default:
                    e.Authenticated = false;
                    break;
            }
        }
    }
}
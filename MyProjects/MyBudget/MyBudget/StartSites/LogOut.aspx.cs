using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBudget.Common.PageHandler;
using System.Web.Security;

namespace MyBudget.StartSites
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logIn_Click(object sender, EventArgs e)
        {
            Response.Redirect(WebSitePageHandler.LogInPage, false);
        }
    }
}
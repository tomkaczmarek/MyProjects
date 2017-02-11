using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBudget.Common.PageHandler;
using MyBudget.Core.DataAccessObject;
using MyBudget.Core.DataTransferObject;
using MyBudget.Core.DataHelpers;

namespace MyBudget.Controls
{
    public partial class Header : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                userLogin.Text = (string)Session[Session.SessionID];
            }           
        }

        protected void logOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect(WebSitePageHandler.LogOutPage, false);
        }
    }
}
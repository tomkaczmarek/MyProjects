using MyBudget.Common.PageHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyBudget.AbstractPage
{
    public partial class AbstractBudgetPage : System.Web.UI.Page
    {
        #region ViewState

        public int UserId
        {
            get
            {
                return (int)ViewState["USER_ID"];
            }
            set
            {
                ViewState["USER_ID"] = value;
            }
        }

        public string UserName
        {
            get
            {
                return (string)ViewState["USER_NAME"];
            }
            set
            {
                ViewState["USER_NAME"] = value;
            }
        }

        #endregion

        #region Constants
        const string TITLE_PAGE = "Witaj i planuj";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session[Session.SessionID] == null)
            {
                Response.Redirect(WebSitePageHandler.LogInPage, false);
            }
            Page.Title = TITLE_PAGE;
        }
    }
}
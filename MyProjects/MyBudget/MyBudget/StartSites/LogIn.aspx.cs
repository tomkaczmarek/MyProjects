using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBudget.AbstractPage;
using MyBudget.ClientAuthorization;
using MyBudget.Core.DataTransferObject;
using MyBudget.Core.DataAccessObject;
using MyBudget.Core.NHibernate;
using NHibernate;
using MyBudget.Common.DataExchange;
using MyBudget.DataOperation.Operation;
using MyBudget.Core.Operation;
using MyBudget.Common.PageHandler;

namespace MyBudget.StartSites
{
    public partial class LogIn : AbstractBudgetPage
    {

        #region Constants
        const string TITLE_PAGE = "Witaj w Budżecie";
        #endregion

        #region DebugMode Const
        const string DEBUG_LOGIN = "DEBUG_LOGIN";
        #endregion


        #region PageLife

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = TITLE_PAGE;
        }

        #endregion

        protected void logButton_Click(object sender, EventArgs e)
        {
            LogUser(userLogin.Text, userPassword.Text);
        }

        private void LogUser(string login, string password)
        {
            OperationResult result = null;
            UserVector uservector = new UserVector();
            if (DebugMode.Checked)
            {
                result = new OperationResult();
                result.OperationStatus = Status.Success;
                result.UrlRedirect = WebSitePageHandler.MainOperationPage;
                uservector.Login = DEBUG_LOGIN;
            }
            else
            {
                uservector.Login = login;
                uservector.Password = password;
                result = OperationUser.LogUser(uservector);
            }
            
            if(result.OperationStatus == Status.Success && result.UrlRedirect != null)
            {
                Session[Session.SessionID] = uservector.Login;
                Response.Redirect(result.UrlRedirect, false);
            }
            else
            {
                msgLabel.Visible = true;
                msgLabel.Text = result.OperationMessage;
            }

        }
      
    }
}
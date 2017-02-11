using MyBudget.AbstractPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyBudget.ClientPages
{
    public partial class ConfigurePage : AbstractBudgetPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(this, e);
        }
    }
}
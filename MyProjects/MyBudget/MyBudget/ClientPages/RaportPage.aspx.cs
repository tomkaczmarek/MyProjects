using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBudget.AbstractPage;

namespace MyBudget.ClientPages
{
    public partial class RaportPage : AbstractBudgetPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(this, e);
        }
    }
}
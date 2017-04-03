using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INApi.Proxy;
using INApi.Helpers;
using INCommon.DataExchange;
using INApi.DataContent;
using System.Text;

namespace INWeb.Controls
{
    public partial class CompanyData : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetData_Click(object sender, EventArgs arg)
        {
            string headers = CreateHttpHeaderToLog(HttpContext.Current.Request);

            NumberProxy numberProxy = new NumberProxy();
            List<IMatchNumber> numberToCheck = new List<IMatchNumber>();
            numberToCheck.Add(new MatchRegonNumber());
            numberToCheck.Add(new MatchNIPNumber());
            numberToCheck.Add(new MatchKRSNumber());

            IDataContent<Company> companyContent;
            companyContent = numberProxy.GetCompanyData(numberToCheck, Number.Text, headers);

            if (companyContent.Data != null)
            {
                ErrorMessage.Text = string.Empty;
                ErrorMessage.Visible = false;
                Name.Text = companyContent.Data.Name;
                Street.Text = companyContent.Data.Street;
                Street_number.Text = companyContent.Data.StreetNumber;
                PostCode.Text = companyContent.Data.PostCode;
                City.Text = companyContent.Data.City;
            }
            else
            {
                ErrorMessage.Text = companyContent.Message;
                ErrorMessage.Visible = true;
                Name.Text = string.Empty;
                Street.Text = string.Empty;
                Street_number.Text = string.Empty;
                PostCode.Text = string.Empty;
                City.Text = string.Empty;
            }
        }

        private string CreateHttpHeaderToLog(HttpRequest request)
        {
            string headers = string.Empty;
            string key;
            for (int i = 0; i < request.Headers.Count; i++)
            {
                key = request.Headers.AllKeys[i];
                headers += String.Format("{0}={1}; ", key, request.Headers[key]);
            }

            return headers;
        }
    }
}
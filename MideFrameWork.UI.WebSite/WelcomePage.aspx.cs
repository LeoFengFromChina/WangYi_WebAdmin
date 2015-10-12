using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MideFrameWork.UI.WebSite
{

    public partial class WelcomePage : BaseForm
    {
        protected string UserName
        {
            get;
            set;
        }
        protected string SmsCount
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserName = CurrentUser.ChildAccount + "@" + CurrentUser.ParentAccount;
                SmsCount = CurrentUser.Balance.ToString();
            }
        }
    }
}
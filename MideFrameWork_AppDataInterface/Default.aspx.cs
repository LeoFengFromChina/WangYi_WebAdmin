using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MideFrameWork_AppDataInterface
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("GetRankList.ashx");
            //Response.Redirect("GetHelpRequestList.ashx");
            //Response.Redirect("GetGiftList.ashx");
            Response.Redirect("GetBannerPictures.ashx");
        }
    }
}

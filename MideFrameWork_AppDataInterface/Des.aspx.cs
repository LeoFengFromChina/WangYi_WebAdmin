using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Common.DBUtility;
namespace MideFrameWork_AppDataInterface
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_data.Text.Trim()) && !string.IsNullOrEmpty(txt_key.Text.Trim()))
            {
                //加密
                lbl_return.Text = DESEncrypt.Encrypt(txt_data.Text.Trim(), "WYGY_BQGZS");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_data.Text.Trim()) && !string.IsNullOrEmpty(txt_key.Text.Trim()))
                {
                    //解密
                    lbl_return.Text = DESEncrypt.Decrypt(txt_data.Text.Trim(), "WYGY_BQGZS");
                }
            }
            catch (Exception ex)
            {
                lbl_return.Text = "解密出错";
            }
        }
    }
}
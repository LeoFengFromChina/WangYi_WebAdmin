using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Common.DBUtility;
using System.Text;
using System.Security.Cryptography;
namespace MideFrameWork.UI.WebSite
{
    public partial class ExecProcGetReturn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////返回值
            //int returnValue = 0;
            ////执行行数
            //int effective = 0;
            //effective = DbHelperSQL.RunProcedure("[up_User_To_Engine]", null, out returnValue);

            #region 短信发送
            //定义请求头
            HuaXiaSms.RequestSoapHeader RequestHeader = new HuaXiaSms.RequestSoapHeader();
            string timeSpan = DateTime.Now.ToString("yyyyMMddHHmmss");
            string userName = "ceshi2013";
            string password = "123123";
            RequestHeader.UserName = userName;
            RequestHeader.Password = EncodePassword(userName, password, timeSpan);
            RequestHeader.Timestamp = timeSpan;

            //定义请求体
            HuaXiaSms.SM_MT SmMt = new HuaXiaSms.SM_MT();
            SmMt.Channel = 21;
            SmMt.ChannelSpecified = true;
            SmMt.Mobile = "18620426114;13430239925";
            SmMt.Content = "领导您好，我们正在与河南华夏公司商谈短信接口合作项目。有任何进展会及时与您联系。【八七工作室】";
            SmMt.SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SmMt.SeqID = 1001;
            SmMt.SubCode = "87studio";

            //定义返回头实体
            HuaXiaSms.ResponseSoapHeader ResponseHeader = new HuaXiaSms.ResponseSoapHeader();

            //定义返回实体
            HuaXiaSms.SM_MT_Result SmMtResult = new HuaXiaSms.SM_MT_Result();

            //定义客户的服务
            HuaXiaSms.smsServiceClient Sms = new HuaXiaSms.smsServiceClient("smsService");
            //开始请求
            ResponseHeader = Sms.SendSMS(RequestHeader, SmMt, out SmMtResult);



            #endregion

        }
        /// <summary>
        ///  加密密码
        /// </summary>
        /// <param name="username">登录名</param>
        /// <param name="password">密码</param>
        /// <param name="timeStamp"></param>
        /// <returns>加密后的面貌</returns>
        public static string EncodePassword(string name, string password, string timeStamp)
        {
            password = MD5_16(password);
            byte[] result = new byte[4 + name.Length + 8 + password.Length + 4];

            Encoding.Default.GetBytes("1858").CopyTo(result, 0);
            Encoding.Default.GetBytes(name).CopyTo(result, 4);
            (new byte[8]).CopyTo(result, 4 + name.Length);
            Encoding.Default.GetBytes(password).CopyTo(result, 4 + name.Length + 8);
            (new byte[4]).CopyTo(result, 4 + name.Length + 8 + password.Length);
            //return MD5_32(result).ToUpper();
            return MD5_32(MD5_32(result).ToUpper() + timeStamp);
        }

        public static string MD5_16(string src)
        {
            StringBuilder result = new StringBuilder("");
            MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
            byte[] value, hash;
            value = System.Text.Encoding.UTF8.GetBytes(src);
            hash = md.ComputeHash(value);
            md.Clear();
            for (int i = 4; i < 12; i++) //for (int i = 8; i < 16; i++)  modify by tangbaogui (old md32_16 error)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString().ToLower();
        }

        public static string MD5_32(byte[] src)
        {
            StringBuilder result = new StringBuilder("");
            MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
            byte[] value, hash;
            value = src;
            hash = md.ComputeHash(value);
            md.Clear();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            string hh = result.ToString().ToLower();
            return result.ToString().ToLower();
        }
        private static string MD5_32(string src)
        {
            StringBuilder result = new StringBuilder("");
            MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
            byte[] value, hash;
            value = System.Text.Encoding.UTF8.GetBytes(src);
            hash = md.ComputeHash(value);
            md.Clear();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            string hh = result.ToString().ToLower();
            return result.ToString().ToLower();
        }

    }
}
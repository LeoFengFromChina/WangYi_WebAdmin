using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using MideSms.Common.DailyUtility;
namespace MideSms.Common.DailyUtility
{
    public class HuaXiaSmsSendService
    {
        string UserName = ConfigurationManager.AppSettings["UserName"].Trim();
        string PassWord = ConfigurationManager.AppSettings["PassWord"].Trim();
        string ChannelID = ConfigurationManager.AppSettings["ChannelID"].Trim();
        string timeSpan = DateTime.Now.ToString("yyyyMMddHHmmss");

        //定义请求头
        static HuaXiaSms.RequestSoapHeader RequestHeader = new HuaXiaSms.RequestSoapHeader();
        //定义客户的服务
        HuaXiaSms.smsServiceClient Sms = new HuaXiaSms.smsServiceClient("smsService");
        //通用客户端
        HuaXiaSms.commonServiceClient comClient = new HuaXiaSms.commonServiceClient("commonService");
        //用户信息实体
        HuaXiaSms.UserInfo currUserInfo = new HuaXiaSms.UserInfo();

        public HuaXiaSmsSendService()
        {
            RequestHeader = GetRequestHeader();
        }

        private HuaXiaSms.RequestSoapHeader GetRequestHeader()
        {
            HuaXiaSms.RequestSoapHeader _RequestHeader = new HuaXiaSms.RequestSoapHeader();
            string timeSpan = DateTime.Now.ToString("yyyyMMddHHmmss");
            _RequestHeader.UserName = UserName;
            _RequestHeader.Password = HuaXiaMD5Encode.EncodePassword(UserName, PassWord, timeSpan);
            _RequestHeader.Timestamp = timeSpan;

            return _RequestHeader;
        }
        /// <summary>
        /// 华夏接口发送短信
        /// </summary>
        /// <param name="Phones">手机号码（用英文分号 ; 进行分割，建议最多1000个）</param>
        /// <param name="Contents">发送内容</param>
        /// <param name="UserID">用户自定义唯一值 [ 这里我们暂时尝试传递我们自有用户的ID ]</param>
        /// <param name="SubCode">扩展子号 [ 这里我们暂时尝试传递我们自有用户的完全账号 ]</param>
        public HuaXiaSms.SM_MT_Result SendSms(string Phones, string Contents, int UserID, string SubCode)
        {
            //定义请求体
            HuaXiaSms.SM_MT SmMt = new HuaXiaSms.SM_MT();
            SmMt.Channel = long.Parse(ChannelID);
            SmMt.ChannelSpecified = true;
            SmMt.Mobile = Phones;
            SmMt.Content = Contents;
            SmMt.SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SmMt.SeqID = UserID;
            SmMt.SubCode = SubCode;

            //定义返回头实体
            HuaXiaSms.ResponseSoapHeader ResponseHeader = new HuaXiaSms.ResponseSoapHeader();

            //定义返回实体
            HuaXiaSms.SM_MT_Result SmMtResult = new HuaXiaSms.SM_MT_Result();

            //开始请求
            ResponseHeader = Sms.SendSMS(RequestHeader, SmMt, out SmMtResult);

            return SmMtResult;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public HuaXiaSms.UserInfo GetUserInfo()
        {
            comClient.GetUserInfo(RequestHeader, out currUserInfo);
            return currUserInfo;
        }
    }
    public enum SM_Result
    {
        Success = 0,
        MobileError = 101,
        TimeFormatError = 102,
        KeyWordError = 103,
        BalanceOutError = 104,
        ChannelIDError = 105,
        MMSizeError = 106,
        UpLoadFileError = 107,
        SubmittingError = 198,
        UnknowError = 199
    }
}

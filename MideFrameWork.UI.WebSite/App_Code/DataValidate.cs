using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using System.Configuration;
using MideFrameWork.Common.DBUtility;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
namespace MideFrameWork.UI.WebSite
{
    public class DataValidate
    {
        int SingleSmsMaxLen = Convert.ToInt32(ConfigurationManager.AppSettings["SingleSmsMaxLength"]);
        int TotalSmsMaxLen = Convert.ToInt32(ConfigurationManager.AppSettings["TotalSmsMaxLen"]);
        int MaxPhoneCount = Convert.ToInt32(ConfigurationManager.AppSettings["MaxPhoneCount"]);
        string PhoneRegx = ConfigurationManager.AppSettings["PhoneRegx"];
        string KeyWordPro = ConfigurationManager.AppSettings["KeyWordPro"];


       

        /// <summary>
        /// 返回给User的XML
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="Result"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        public string GetReturnXML(int Code, string Result, string ErrorMsg)
        {

            XmlDocument xml = new XmlDocument();
            XmlElement root = xml.CreateElement("Root");

            XmlNode code = xml.CreateElement("Code");
            code.InnerText = Code.ToString();

            XmlNode result = xml.CreateElement("Result");
            result.InnerText = Result;

            XmlNode message = xml.CreateElement("Message");
            message.InnerText = ErrorMsg;

            xml.AppendChild(root);
            root.AppendChild(code);
            root.AppendChild(result);
            root.AppendChild(message);

            return xml.InnerXml;

        }

    }
}
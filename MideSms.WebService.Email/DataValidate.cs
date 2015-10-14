using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text.RegularExpressions;
namespace MideSms.WebService.Email
{
    public class DataValidate
    {
        string EmalRegx = ConfigurationManager.AppSettings["EmailRegx"];
        /// <summary>
        /// 验证多个邮件地址
        /// </summary>
        /// <param name="Emails">邮件地址，多个用英文分号;隔开</param>
        /// <returns>返回验证成功的邮件地址数组</returns>
        public int ValidateEmails(string Emails, out List<string> AnonymoustList, out  List<string> nonAnonymousList)
        {
            if (string.IsNullOrEmpty(Emails))
            {
                AnonymoustList = null;
                nonAnonymousList = null;
                return -1;
            }
            AnonymoustList = new List<string>();
            nonAnonymousList = new List<string>();
            string[] EmailArray = Emails.Split(';');
            foreach (string EmailStr in EmailArray)
            {
                if (string.IsNullOrEmpty(EmailStr) || !Regex.IsMatch(EmailStr, EmalRegx))
                    continue;
                if (EmailStr.Contains("@126") || EmailStr.Contains("@163"))
                    AnonymoustList.Add(EmailStr);
                else
                {
                    nonAnonymousList.Add(EmailStr);
                }
            }
            return AnonymoustList.Count + nonAnonymousList.Count;
        }

        /// <summary>
        /// 验证单个邮件地址
        /// </summary>
        /// <param name="Email">邮件地址</param>
        /// <returns>是否通过</returns>
        public bool ValidateEmail(string Email)
        {
            if (string.IsNullOrEmpty(Email) || !Regex.IsMatch(Email, @EmalRegx))
                return false;
            return true;
        }

        /// <summary>
        /// 验证发送者的名称
        /// </summary>
        /// <param name="EmailName">邮件显示名称</param>
        /// <returns>是否通过</returns>
        public bool ValidateEmaiName(string EmailName)
        {
            if (string.IsNullOrEmpty(EmailName) || EmailName.Length > 15)
                return false;
            return true;

        }
        /// <summary>
        /// 验证文本[主要控制是否为空]
        /// </summary>
        /// <param name="Text">要验证的文本</param>
        /// <returns>是否通过</returns>
        public bool ValidateText(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return false;
            return true;
        }
    }
}
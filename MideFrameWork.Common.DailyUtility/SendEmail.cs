using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace MideFrameWork.Common.DailyUtility
{
    public static class SendEmail
    {
        public static int SendEmailnonAnonymous(string FromAddress
                    , string FromName
                    , string Subject
                    , string Body
                    , List<string> toEmailList_nonAnonymous
                    , List<string> ccEmailList_nonAnonymous
                    , out string ErrorMsg
                    , string Account
                    , string Password)
        {
            SmtpClient smtp = new SmtpClient(); //实例化一个SmtpClient
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; //将smtp的出站方式设为 Network
            smtp.EnableSsl = false;//smtp服务器是否启用SSL加密
            smtp.Host = "smtp.126.com"; //指定 smtp 服务器地址
            smtp.Port = 25;             //指定 smtp 服务器的端口，默认是25，如果采用默认端口，可省去
            //如果你的SMTP服务器不需要身份认证，则使用下面的方式，不过，目前基本没有不需要认证的了
            smtp.UseDefaultCredentials = true;
            //如果需要认证，则用下面的方式
            smtp.Credentials = new NetworkCredential(Account, Password);
            MailMessage Message = new MailMessage(); //实例化一个邮件类
            // mm.Priority = MailPriority.High; //邮件的优先级，分为 Low, Normal, High，通常用 Normal即可
            Message.From = new MailAddress(Account, Account, Encoding.UTF8);
            //收件方看到的邮件来源；
            //第一个参数是发信人邮件地址
            //第二参数是发信人显示的名称
            //第三个参数是 第二个参数所使用的编码，如果指定不正确，则对方收到后显示乱码
            //936是简体中文的codepage值
            //注：上面的邮件来源，一定要和你登录邮箱的帐号一致，否则会认证失败

            //mm.ReplyTo = new MailAddress("test_box@gmail.com", "我的接收邮箱", Encoding.GetEncoding(936));
            //ReplyTo 表示对方回复邮件时默认的接收地址，即：你用一个邮箱发信，但却用另一个来收信
            //上面后两个参数的意义， 同 From 的意义
            //mm.CC.Add("a@163.com,b@163.com,c@163.com");
            //邮件的抄送者，支持群发，多个邮件地址之间用 半角逗号 分开
            if (toEmailList_nonAnonymous != null && toEmailList_nonAnonymous.Count > 0)
            {
                foreach (string toEmail in toEmailList_nonAnonymous)
                {
                    Message.To.Add(toEmail);
                }
            }
            if (ccEmailList_nonAnonymous != null && ccEmailList_nonAnonymous.Count > 0)
            {
                foreach (string ccEmail in ccEmailList_nonAnonymous)
                {
                    Message.CC.Add(ccEmail);
                }
            }
            //当然也可以用全地址，如下：
            //mm.CC.Add(new MailAddress("a@163.com", "抄送者A", Encoding.GetEncoding(936)));
            //mm.CC.Add(new MailAddress("b@163.com", "抄送者B", Encoding.GetEncoding(936)));
            //mm.CC.Add(new MailAddress("c@163.com", "抄送者C", Encoding.GetEncoding(936)));

            // mm.Bcc.Add("d@163.com,e@163.com");
            //邮件的密送者，支持群发，多个邮件地址之间用 半角逗号 分开

            //当然也可以用全地址，如下：
            //Message.CC.Add(new MailAddress("d@163.com", "密送者D", Encoding.GetEncoding(936)));
            //Message.CC.Add(new MailAddress("e@163.com", "密送者E", Encoding.GetEncoding(936)));
            //Message.Sender = new MailAddress("xxx@xxx.com", "邮件发送者", Encoding.GetEncoding(936));
            //可以任意设置，此信息包含在邮件头中，但并不会验证有效性，也不会显示给收件人
            //说实话，我不知道有啥实际作用，大家可不理会，也可不写此项
            //Message.To.Add("g@163.com,h@163.com");
            //邮件的接收者，支持群发，多个地址之间用 半角逗号 分开

            //当然也可以用全地址添加

            //Message.To.Add(new MailAddress("g@163.com", "接收者g", Encoding.GetEncoding(936)));
            //Message.To.Add(new MailAddress("h@163.com", "接收者h", Encoding.GetEncoding(936)));
            Message.Subject = Subject; //邮件标题
            Message.SubjectEncoding = Encoding.UTF8;
            // 这里非常重要，如果你的邮件标题包含中文，这里一定要指定，否则对方收到的极有可能是乱码。
            // 936是简体中文的pagecode，如果是英文标题，这句可以忽略不用
            Message.IsBodyHtml = true; //邮件正文是否是HTML格式

            Message.BodyEncoding = Encoding.UTF8;
            //邮件正文的编码， 设置不正确， 接收者会收到乱码

            Message.Body = @Body;
            //邮件正文
            // Message.Attachments.Add(new Attachment(@"d:a.doc", System.Net.Mime.MediaTypeNames.Application.Rtf));
            //添加附件，第二个参数，表示附件的文件类型，可以不用指定
            //可以添加多个附件
            //Message.Attachments.Add(new Attachment(@"d:b.doc"));
            try
            {
                smtp.Send(Message); //发送邮件，如果不返回异常， 则大功告成了。
                ErrorMsg = "发送成功！";
                return toEmailList_nonAnonymous.Count + ccEmailList_nonAnonymous.Count;
            }
            catch (Exception ex)
            {
                ErrorMsg = "发送过程中出现问题！详细如：" + ex.ToString();
                return -1;
                throw;
            }
            finally
            {
                toEmailList_nonAnonymous = null;
                ccEmailList_nonAnonymous = null;
            }
        }

        private static int SendEmailAnoymous(string FromAddress
            , string FromName
            , string Subject
            , string Body
            , List<string> toEmailList_Anonymous
            , List<string> ccEmailList_Anonymous
            , out string ErrorMsg)
        {
            SmtpClient SMTPClient = new SmtpClient();
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress(FromAddress, FromName);//必须是提供smtp服务的邮件服务器 

            if (toEmailList_Anonymous != null && toEmailList_Anonymous.Count > 0)
            {
                foreach (string toEmail in toEmailList_Anonymous)
                {
                    Message.To.Add(toEmail);
                }
            }
            if (ccEmailList_Anonymous != null && ccEmailList_Anonymous.Count > 0)
            {
                foreach (string ccEmail in ccEmailList_Anonymous)
                {
                    Message.CC.Add(ccEmail);
                }
            }
            Message.Subject = Subject;
            Message.IsBodyHtml = true;
            Message.BodyEncoding = System.Text.Encoding.UTF8;
            Message.Body = @Body;

            SMTPClient.EnableSsl = false; //必须经过ssl加密 
            try
            {
                SMTPClient.Send(Message);
                ErrorMsg = "发送成功!";
                return toEmailList_Anonymous.Count + ccEmailList_Anonymous.Count;//总共发送给了多少人
            }
            catch (Exception ex)
            {
                ErrorMsg = "邮件发送失败!具体原因：" + ex.ToString();
                return -1;
            }
            finally
            {
                //释放资源
                toEmailList_Anonymous = null;
                ccEmailList_Anonymous = null;
            }
        }
    }
}

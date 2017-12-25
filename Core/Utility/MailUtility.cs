using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MailUnity
{
    public class MailUtility
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="info">接收人信息 MailUnity.MailInfo </param>
        /// <param name="mailConfig">发件邮箱配置</param>
        /// <param name="message">默认为null。 System.Net.Mail.MailMessage </param>
        /// <param name="isSingleSend">是否群发单显。当邮件接收人为多个时，可选择该模式，即可对多个收件人分别发送，收件方不会知道这封邮件有多个收件人</param>
        public static void Send(MailConfig mailConfig, MailInfo info)
        {
            var message = new MailMessage();

            if(!string.IsNullOrEmpty(info.Replay)) message.ReplyTo = new MailAddress(info.Replay);

            var cc = string.Join(",", info.SubReceivers.ToArray());
            if(!string.IsNullOrEmpty(cc)) message.CC.Add(cc);

            var to = string.Join(",", info.Receivers.ToArray());
            if(!string.IsNullOrEmpty(to)) message.To.Add(to);

            if (!string.IsNullOrEmpty(info.Subject)) message.Subject = info.Subject;

            if (!string.IsNullOrEmpty(info.Body)) message.Body = info.Body;

            SmtpClientSend(mailConfig, message);
        }

        /// <summary>
        /// SmtpClientSend
        /// </summary>
        /// <param name="mailConfig"></param>
        /// <param name="message"></param>
        private static void SmtpClientSend(MailConfig mailConfig, MailMessage message)
        {
            var sender = new SmtpClient();
            sender.UseDefaultCredentials = false;
            sender.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                message.IsBodyHtml = mailConfig.IsHtml;
                message.From = new MailAddress(mailConfig.From, mailConfig.DisplayName);
                sender.Host = mailConfig.Host;
                sender.Port = mailConfig.Port;
                sender.Credentials = new NetworkCredential(mailConfig.User, mailConfig.Password);
                sender.EnableSsl = mailConfig.EnableSsl;
                sender.Send(message);
            }
            catch (Exception e)
            {
                var defultConfig = MailConfig.Defult;
                //发送异常一般为发送邮箱配置有误，这里提供一个默认发件邮箱。
                message.From = new MailAddress(defultConfig.From, defultConfig.DisplayName);// "NuGets@163.com", "Mafly"
                message.IsBodyHtml = true;
                sender.Host = defultConfig.Host; //"smtp.163.com";
                sender.Port = defultConfig.Port;// 25;
                sender.Credentials = new NetworkCredential(defultConfig.User, defultConfig.Password);// "NuGets@163.com", "vzihlbquwnriqlht"
                sender.EnableSsl = false;
                message.Body += e.ToString();
                Console.WriteLine(e);
                sender.Send(message);
            }
        }
    }

}

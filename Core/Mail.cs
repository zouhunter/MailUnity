using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;

namespace MailUnity
{
    /// <summary>
    /// 发送邮件
    /// </summary>
    public class Mail : IMail
    {
        /// <summary>
        /// 当前配制
        /// </summary>
        private MailConfig mailConfig;
        private Dictionary<string, MailInfo> _mainInfoDic = new Dictionary<string, MailInfo>();
        private MailInfo this[string info]
        {
            get
            {
                if (string.IsNullOrEmpty(info))
                {
                    info = "_defult";
                }
                if (!_mainInfoDic.ContainsKey(info))
                {
                    _mainInfoDic[info] = new MailInfo();
                }
                return _mainInfoDic[info];
            }
        }

        /// <summary>
        /// 初始化 MailUnity 的空实例
        /// 默认读取程序运行目录的下的Config/MailSetting.config文件
        /// </summary>
        public Mail()
        {
            mailConfig = MailConfig.Defult;
        }

        /// <summary>
        /// 使用指定的 MailUnity.Config 类对象初始化 MailUnity 类的新实例。
        /// </summary>
        /// <param name="config">包含邮件配置信息的 MailUnity.Config。</param>
        public Mail(MailConfig config)
        {
            mailConfig = config;
        }


        public IMail AddReceivers(string receiverName, params string[] addresses)
        {
            this[receiverName].Receivers.AddRange(addresses);
            return this;
        }

        public IMail AddSubReceivers(params string[] addresses)
        {
            ForEachInfo((info) =>
            {
                info.SubReceivers.AddRange(addresses);
            });
            return this;
        }

        public IMail AddSubject(string subject)
        {
            ForEachInfo((info) =>
            {
                info.Subject = subject;
            });
            return this;
        }

        public IMail AddFiles(params string[] files)
        {
            ForEachInfo((info) =>
            {
                foreach (var file in files)
                {
                    info.Files.Add(new Attachment(file));
                }
            });
            return this;
        }

        public IMail AddAttachment(params Attachment[] files)
        {
            ForEachInfo((info) =>
            {
                foreach (var file in files)
                {
                    info.Files.Add(file);
                }
            });
            return this;
        }

        public void Send(string body)
        {
            ForEachInfo((info) =>
            {
                info.Body = body;
                MailUtility.Send(mailConfig, info);
            });
        }
        public IAsyncMail SendAsync(string body)
        {
            var mail = new AsyncMail();
            ForEachInfo((info) =>
            {
                info.Body = body;
                var asyn = MailUtility.SendAsync(mailConfig, info);
                mail.RecordSubMail(asyn);
                asyn.onComplete = mail.OnSubMailComplete;
            });
            return mail;
        }
        private void ForEachInfo(Action<MailInfo> action)
        {
            foreach (var item in _mainInfoDic)
            {
                if (item.Value != null)
                {
                    action.Invoke(item.Value);
                }
            }
        }
    }
}

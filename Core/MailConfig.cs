using System;

namespace MailUnity
{
    /// <summary>
    /// 邮件配置信息
    /// </summary>
    [Serializable]
    public class MailConfig
    {
        private string _path = string.Empty;
        private static MailConfig defultConfig;

        /// <summary>
        /// 默认config,用于发送错误时反馈
        /// </summary>
        public static MailConfig Defult
        {
            get
            {
                if (defultConfig == null)
                {
                    defultConfig = CreateDefult();
                }
                return defultConfig;
            }
        }
        /// <summary>
        /// 读取默认路径（Config/MailSetting.config）下的配置文件
        /// </summary>
        /// <returns></returns>
        public MailConfig Create()
        {
            try
            {
                return CreateDefult();
            }
            catch
            {
                return new MailConfig();
            }
        }

        private static MailConfig CreateDefult()
        {
            var config = new MailConfig()
            {
                Host = "smtp.163.com",
                Port = 25,
                User = "zouhunter52@163.com",
                Password = "hunterzou52",
                IsHtml = true,
                From = "zouhunter52@163.com",
                DisplayName = "Hunter",
                EnableSsl = false
            };
            return config;
        }

        /// <summary>
        /// 主机名 如：smtp.163.com
        /// </summary>
        public string Host;

        /// <summary>
        /// 端口号 如：25
        /// </summary>
        public int Port;

        /// <summary>
        /// 用户名
        /// </summary>
        public string User;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password;

        /// <summary>
        /// 是否包含Html代码
        /// </summary>
        public bool IsHtml;

        /// <summary>
        /// 发送者显示名
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// 来源
        /// </summary>
        public string From;

        /// <summary>
        /// 是否启用SSL 默认：false 
        /// 如果启用 端口号要改为加密方式发送的
        /// </summary>
        public bool EnableSsl;
    }
}

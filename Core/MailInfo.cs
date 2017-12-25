using System.Collections.Generic;
using System.Net.Mail;

namespace MailUnity
{
    /// <summary>
    ///     发送邮件的信息
    /// </summary>
    public class MailInfo
    {
        /// <summary>
        /// 主题行
        /// </summary>
        public string _subject;
        /// <summary>
        /// 邮件的主题行
        /// </summary>
        public string Subject
        {
            get
            {
                if (string.IsNullOrEmpty(_subject))
                {
                    if (!string.IsNullOrEmpty(_body))
                    {
                        if (_body.Length > 15)
                        {
                            _subject = _body.Substring(0, 15);
                        }
                        else
                        {
                            _subject = _body;
                        }
                    }
                }

                return _subject;
            }
            set { _subject = value; }
        }

        /// <summary>
        /// 接收者名字
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 接收者邮箱
        /// </summary>
        private List<string> _receivers = new List<string>();
        public List<string> Receivers
        {
            get
            {
                if (_receivers == null) _receivers = new List<string>();
                return _receivers;
            }
        }

        /// <summary>
        /// 抄送人集合
        /// </summary>
        private List<string> _subReceivers = new List<string>();
        public List<string> SubReceivers
        {
            get
            {
                if (_subReceivers == null)
                    _subReceivers = new List<string>();
                return _subReceivers;
            }
        }

     
        /// <summary>
        /// 文件路径
        /// </summary>
        private List<Attachment> _files = new List<Attachment>();
        public List<Attachment> Files
        {
            get
            {
                if (_files == null)
                    _files = new List<Attachment>();
                return _files;
            }
        }

        /// <summary>
        /// 正文内容
        /// </summary>
        private string _body;
        public string Body { get { if (string.IsNullOrEmpty(_body)) _body = ReceiverName; return _body; } set { _body = value; } }

        /// <summary>
        /// 回复地址
        /// </summary>
        private string _replay;
        public string Replay { get { if (string.IsNullOrEmpty(_replay)) _replay = MailConfig.Defult.From;return _replay; }set { _replay = value; } }

    }
}
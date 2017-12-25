using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Sprites;
using UnityEngine.Scripting;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.Assertions.Must;
using UnityEngine.Assertions.Comparers;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;

namespace MailUnity
{
    public interface IMail
    {
        IMail AddReceivers(string receiverName, params string[] addresses);//添加接收人
        IMail AddSubReceivers(params string[] addresses);//添加抄送
        IMail AddSubject(string subject);//添加主题
        IMail AddFiles(params string[] files);//添加文件
        IMail AddAttachment(params Attachment[] files);//添加文件
        void Send(string body);
        IAsyncMail SendAsync(string body);
    }
}
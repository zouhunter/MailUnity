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
using System;

public class MailSendPanel : MonoBehaviour {
    [SerializeField]
    private InputField m_userNames;
    private List<string> userNames;

    private void Awake()
    {
        m_userNames.onEndEdit.AddListener(OnEndEditNames);
    }

    private void OnEndEditNames(string arg0)
    {
        //var mailService = new MailUnity.Mail();
        ////群发单显参数：多接收者邮箱、内容
        //mailService.Send("zouhangtezbm@126.com,1063627025@qq.com", "测试【群发单显】邮件发送！", true);
        ////参数：接收者邮箱、内容
        //mailService.Send("zouhangtezbm@126.com,1063627025@qq.com", "测试邮件发送！");
    }
}

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
using MailUnity;

public class MailSendPanel : MonoBehaviour
{
    [SerializeField]
    private InputField m_userNames;
    [SerializeField]
    private Button m_send;
    [SerializeField]
    private Button m_sendAsync;
    [SerializeField]
    private InputField m_text;
    [SerializeField]
    private Text m_state;
    private Mail mail;
    private string[] users;
    private string fileTest;
    private string state;
    private bool isStateChanged;
    
    private void Awake()
    {
        m_send.onClick.AddListener(OnSend);
        m_sendAsync.onClick.AddListener(OnSendAsync);
        mail = new MailUnity.Mail();
        fileTest = Application.dataPath + "/MailUnity/Demo/testFile.txt";
    }

    private void OnSend()
    {
        users = m_userNames.text.Split(new char[] { ';', '；', ';' });
        if (users == null || users.Length == 0 || string.IsNullOrEmpty(m_text.text)) return;
        OnStateChanged("正在发送...");
        mail.AddReceivers("Runtime", users).AddFiles(fileTest).Send(m_text.text);
        OnStateChanged("发送成功");
    }
    private void OnSendAsync()
    {
        users = m_userNames.text.Split(new char[] { ';', '；', ';' });
        if (users == null || users.Length == 0 || string.IsNullOrEmpty(m_text.text)) return;
        OnStateChanged("正在发送...");
        var async = mail.AddReceivers("Runtime", users).AddFiles(fileTest).SendAsync(m_text.text);
        async.onComplete = (x) => { OnStateChanged( "发送成功"); };
    }
    private void Update()
    {
        if(isStateChanged)
        {
            isStateChanged = false;
            m_state.text = state;
        }
    }
    private void OnStateChanged(string newState)
    {
        state = newState;
        isStateChanged = true;
    }

}

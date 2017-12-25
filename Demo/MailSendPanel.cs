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

public class MailSendPanel : MonoBehaviour {
    [SerializeField]
    private InputField m_userNames;
    [SerializeField]
    private Button m_send;
    private Mail mail;
    private string[] users;
    private string fileTest;
    private void Awake()
    {
        m_userNames.onEndEdit.AddListener(OnEndEditNames);
        m_send.onClick.AddListener(OnSend);
        mail = new MailUnity.Mail();
        fileTest = Application.dataPath + "/MailUnity/Demo/testFile.txt";
    }

    private void OnSend()
    {
        if (users == null) return;
        mail.AddReceivers("Runtime", users).AddFiles(fileTest).Send("Hellow Mail") ;
    }

    private void OnEndEditNames(string arg0)
    {
        users = arg0.Split(new char[] { ';','；',';'});
    }

}

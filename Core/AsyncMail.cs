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
using System.ComponentModel;

namespace MailUnity
{
    public class AsyncMail : IAsyncMail
    {
        private List<IAsyncMail> subMails = new List<IAsyncMail>();

        public UnityAction<IAsyncMail> onComplete { get; set; }

        public void Complete(object sender, AsyncCompletedEventArgs e)
        {
            if(e.UserState == this)
            {
                if(onComplete != null)
                {
                    onComplete.Invoke(this);
                }
            }
        }
        public void RecordSubMail(IAsyncMail mail)
        {
            if(!subMails.Contains(mail))
            {
                subMails.Add(mail);
            }
        }
        public void OnSubMailComplete(IAsyncMail mail)
        {
            if(subMails.Contains(mail))
            {
                subMails.Remove(mail);
            }
            if(subMails.Count == 0)
            {
                if(onComplete != null)
                {
                    onComplete.Invoke(this);
                }
            }
        }
    }
}


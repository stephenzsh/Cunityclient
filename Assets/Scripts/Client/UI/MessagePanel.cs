using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : BasePanel
{
    public Text text;

    string msg = null;

    private void Update()
    {
        if(msg!= null)
        {
            ShowText(msg);
            msg = null;
        }
    }


    public override void OnEnter()
    {
        base.OnEnter();
        text.CrossFadeAlpha(0, 0.1f, false);
        uIManager.SetMessagePanel(this);
    }
    public void ShowMessage(string message, bool isSync = false)
    {
        if (isSync)
        {
            //异步显示
            msg = message;
        } else
        {
            ShowText(message);
        }
    }
    private void ShowText(string message) {
        text.text = message;
        text.CrossFadeAlpha(1, 0.1f, false);
        Invoke("HideText", 1);
    }


    public void HideText()
    {
        text.CrossFadeAlpha(0, 0.1f, false);
    }

    
  
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{

    public InputField user, password;
    public Button loginBtn;
    public Button SignBtn;

    public LoginRequest loginRequest;
    public void OnLoginClick()
    {
        if (user.text == ""|| password.text == "")
        {
            Debug.Log("用户名密码不能为空");
        }
        loginRequest.OnClick(user.text,password.text);
    }

    // Update is called once per frame
    public override void OnEnter()
    {
        base.OnEnter();
        Enter();
    }
    public override void OnExit()
    {
        base.OnExit();
        Exit();
    }
    public override void OnRecovery()
    {
        base.OnRecovery();
    }
    public override void OnPause()
    {
        base.OnPause();
    }
    private void Enter()
    {
        gameObject.SetActive(true);
        loginBtn.onClick.AddListener(OnLoginClick);
    }
    private void Exit()
    {
        gameObject.SetActive(false);

    }
}

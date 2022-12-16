using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{

    public InputField user, pass;
    public Button loginBtn;
    public Button SignBtn;

    public LoginRequest loginRequest; 
    public void OnLoginClick()
    {
        
        loginRequest.OnClick();
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

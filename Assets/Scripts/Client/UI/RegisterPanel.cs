using Protobuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{

    public InputField user, password;
    public Button loginBtn;
    public Button SignBtn;

    public RegisterRequest registerRequest;
    public void OnLoginClick()
    {
        if (user.text == "" || password.text == "")
        {
            Debug.Log("用户名密码不能为空");
        }
        registerRequest.OnClick(user.text, password.text);
    }
    public void SwitchPanel()
    {

        uIManager.PopPanel();
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
        Enter();
    }
    public override void OnPause()
    {
        base.OnPause();
        Exit();
    }
    private void Enter()
    {
        gameObject.SetActive(true);
        SignBtn.onClick.AddListener(OnLoginClick);
        loginBtn.onClick.AddListener(SwitchPanel);
    }
    private void Exit()
    {
        gameObject.SetActive(false);

    }

    public void OnResponse(Message msg)
    {
        uIManager.ShowMessage("登陆成功");
        uIManager.PushPanel(PanelType.Login);
        
    }
}


using Google.Protobuf;
using Protobuf;
using System;
using UnityEngine;


public class LoginRequest : BaseRequest
{

    public LoginPanel loginPanel;

    private Message msg;

    private void Update()
    {
        if (msg != null)
        {
            loginPanel.OnResponse(msg);
            msg = null;
        }
    }

    public override void Awake()
    {
        
        base.Awake(); 
        face.AddRequest(this,RequestType.Login);
        
    }

   

    public override void OnDestroy()
    {
        base.OnDestroy();
        face.RemoveRequest(RequestType.Login);
    }


    
    public void OnClick(string user, string password)
    {

        //Debug.Log("LoginRequest Onclick");
        LoginMessage loginmessage = new LoginMessage()
        {
          
            Username = user,
            Password= password,
            Type = 1,
        };
        
        Message msg = new Message();
        msg.Data = loginmessage.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestType.Login); 
        msg.DataLen = (uint)loginmessage.ToByteArray().Length;
        SendRequest(msg);


    }

    public override void SendRequest(Message msg)
    {
        
        base.SendRequest(msg);
    }
    public override void OnResponse(Message msg)
    {

        this.msg = msg;
       

    }
}

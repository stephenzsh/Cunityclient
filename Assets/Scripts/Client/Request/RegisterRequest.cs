using Google.Protobuf;
using Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RegisterRequest:BaseRequest
    {

    public RegisterPanel registerPanel;

    private Message msg;

    private void Update()
    {
        if (msg != null)
        {
            registerPanel.OnResponse(msg);
            msg = null;
        }
    }

    public override void Awake()
    {
        base.Awake();
        face.AddRequest(this, RequestType.Register);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        face.RemoveRequest(RequestType.Register);
    }



    public void OnClick(string user, string password)
    {


        LoginMessage loginmessage = new LoginMessage()
        {

            Username = user,
            Password = password,
            Type = 0,
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


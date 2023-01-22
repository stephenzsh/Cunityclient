

using Google.Protobuf;
using Protobuf;
using System;
using UnityEngine;


public class LoginRequest : BaseRequest
{

    public LoginRequest request;

    public override void Awake()
    {
        base.Awake();
        face.AddRequest(this,RequestType.Login);
        //request = new LoginRequest();
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        face.RemoveRequest(RequestType.Login);
    }


    
    public void OnClick(string user, string password)
    {
        

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
        RoomListMessage obj = RoomListMessage.Parser.ParseFrom(msg.Data);
        
    }
}

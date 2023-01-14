

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


    public void SendRequest(string roomname, string operate)
    {

        
        //byte[] data = usermessage.ToByteArray();
        // Message pack = new Message((uint)data.Length, 0, data);
        // 序列化 Person 实例
        // byte[] data = john.ToByteArray();

        // 反序列化 Person 实例
        //Person john2 = Person.Parser.ParseFrom(data);
    }

    
    public void OnClick(string user, string password)
    {
        

        UserMessage usermessage = new UserMessage()
        {
            Flag = false,
            Roomname = user,
            Operate = "add"

        };
        
        Message msg = new Message();
        msg.Data = usermessage.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestType.Start); 
        msg.DataLen = (uint)usermessage.ToByteArray().Length;
        SendRequest(msg);


    }

    public override void SendRequest(Message msg)
    {
        
        base.SendRequest(msg);
    }
    public override void OnResponse(Message msg)
    {
        base.OnResponse(msg);
    }
}

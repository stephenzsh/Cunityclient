using Google.Protobuf;
using Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RoomRequest :BaseRequest
{
    const string Add = "add";
    const string Enter = "enter";
    public RoomPanel panel;
    private Message msg;
    private void Update()
    {
        if (msg != null)
        {
            panel.OnResponse(msg);
            msg = null;
        }
    }


    public override void Awake()
    {
        base.Awake();
        //type = 3
        face.AddRequest(this, RequestType.Room);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        face.RemoveRequest(RequestType.Register);
    }
    public override void SendRequest(Message msg)
    {

        base.SendRequest(msg);
    }
    public override void OnResponse(Message msg)
    {

        this.msg = msg;
    }

    public void CreateRoom(string roomName, int num)
    {
        UserMessage loginmessage = new UserMessage()
        {
            Operate = Add,
            Roomname = roomName,
            Num = Convert.ToUInt32(num),

        };
        Message msg = new Message();
        msg.Data = loginmessage.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestType.Room);
        msg.DataLen = (uint)loginmessage.ToByteArray().Length;
        SendRequest(msg);
    }

    public void EnterRoom(string roomName)
    {
        UserMessage loginmessage = new UserMessage()
        {

            Operate = Enter,
            Roomname = roomName,

        };
        Message msg = new Message();
        msg.Data = loginmessage.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestType.Room);
        msg.DataLen = (uint)loginmessage.ToByteArray().Length;
        SendRequest(msg);
    }

}


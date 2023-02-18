using Google.Protobuf;

using Protobuf;
using System;


public class RoomlistRequest : BaseRequest
{
    const string Add = "add";
    const string Enter = "enter";

    private Message msg;

    public RoomListPanel panel;

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
        //type = 2
        face.AddRequest(this, ActionCode.SearchRoom);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        face.RemoveRequest(ActionCode.SearchRoom);
    }
    public override void SendRequest(Message msg)
    {

        base.SendRequest(msg);
    }
    public override void OnResponse(Message msg)
    {

        this.msg = msg;
    }

    public void SearchRoom(string roomName)
    {
        GameMessage message = new GameMessage()
        {
            ActionCode = ActionCode.SearchRoom,
            Msg = roomName
        };
        Message msg = new Message();
        msg.Data = message.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestCode.MainHall);
        msg.DataLen = (uint)message.ToByteArray().Length;
        SendRequest(msg);
    }

    public void CreateRoom(string roomName, int num)
    {
        GameMessage message = new GameMessage()
        {
            ActionCode = ActionCode.CreateRoom,
            Msg = roomName
        };
        Message msg = new Message();
        msg.Data = message.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestCode.MainHall);
        msg.DataLen = (uint)message.ToByteArray().Length;
        SendRequest(msg);
    }

    public void EnterRoom(string roomName)
    {

        GameMessage message = new GameMessage()
        {
            ActionCode = ActionCode.EnterRoom,
            Msg = roomName
        };
        Message msg = new Message();
        msg.Data = message.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestCode.MainHall);
        msg.DataLen = (uint)message.ToByteArray().Length;
        SendRequest(msg);
    }


}


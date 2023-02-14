using Google.Protobuf;
using Protobuf;
using System;
using UnityEngine;

public class RoomRequest :BaseRequest
{
    
    
    public RoomPanel panel;
   
    private Message msg;
    private void Update()
    {
        if (msg != null)
        {
            GameMessage obj = GameMessage.Parser.ParseFrom(msg.Data);
            if (obj.ReturnCode == ReturnCode.Fail) {
                panel.FailResponse(obj.Msg);
            }
            switch (obj.ActionCode){
                case ActionCode.PlayerList:
                    panel.UpdatePlayerList(obj.Players);
                    break;
                case ActionCode.Chat:
                    panel.UpdateChat(obj.Roomlist[0]);
                    break;
                case ActionCode.CheckStatus:
                    panel.CheckStatus();
                    break;
                
            }
           
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
        face.RemoveRequest(RequestType.Room);
    }
    public override void SendRequest(Message msg)
    {

        base.SendRequest(msg);
    }
    public override void OnResponse(Message msg)
    {
        this.msg = msg;
    }

    public void GetPlayerList(string name)
    {
        GameMessage message = new GameMessage()
        {
            ActionCode = ActionCode.PlayerList,
            Msg = name
        };
        Message msg = new Message();
        msg.Data = message.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestType.Room);
        msg.DataLen = (uint)message.ToByteArray().Length;
        SendRequest(msg);
    }
    public void SendMsg(string roomname ,string text)
    {
        RoomMessage room = new RoomMessage()
        {
            Name = roomname
        };
        GameMessage message = new GameMessage()
        {
            ActionCode = ActionCode.Chat,
            Msg = text,
        };
        message.Roomlist.Add(room);
        Message msg = new Message();
        msg.Data = message.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestType.Room);
        msg.DataLen = (uint)message.ToByteArray().Length;
        SendRequest(msg);

    }

    public void StartGame(string roomname)
    {
        GameMessage message = new GameMessage()
        {
            ActionCode = ActionCode.StartGame,
            Msg = roomname,
        };
        Message msg = new Message();
        msg.Data = message.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestType.Room);
        msg.DataLen = (uint)message.ToByteArray().Length;
        SendRequest(msg);
    }
}


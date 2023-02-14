using Google.Protobuf;
using Protobuf;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRequest : BaseRequest
{
    public RoomPanel panel;

   

    public override void Awake()
    {
        base.Awake();
        face.AddRequest(this,RequestType.PlayerList);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        face.RemoveRequest(RequestType.PlayerList);
    }

    public override void OnResponse(Message msg)
    {
        GameMessage obj = GameMessage.Parser.ParseFrom(msg.Data);
        if (obj.ReturnCode == ReturnCode.Fail){
            Debug.Log("player request fail , msg = " + obj.Msg);
            panel.FailResponse(obj.Msg);
            return;
        }
        switch (obj.ActionCode)
        {
            case ActionCode.PlayerList:
                panel.UpdatePlayerList(obj.Players);
                break;
        }
    }
    public void CheckStatus(string roomname,bool checkstatus)
    {
        GameMessage message = new GameMessage()
        {
            ActionCode = ActionCode.CheckStatus,
            Checkstatus = checkstatus,
            Msg = roomname,
        };
        Message msg = new Message();
        msg.Data = message.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestType.Game);
        msg.DataLen = (uint)message.ToByteArray().Length;
        SendRequest(msg);
    }
    
}

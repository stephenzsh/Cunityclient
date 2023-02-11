using Google.Protobuf;
using Protobuf;
using System;
using UnityEngine;

public class RoomExitRequest :BaseRequest
{
    const string Exit = "exit";

    public override void Awake()
    {
        base.Awake();
        face.AddRequest(this,RequestType.ExitRoom);
    }

    public void ExitRoom(string roomName)
    {
        Debug.Log(roomName);
        GameMessage loginmessage = new GameMessage()
        {

            ActionCode = ActionCode.ExitRoom,
            Msg = roomName,

        };
        Message msg = new Message();
        msg.Data = loginmessage.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestType.Room);
        msg.DataLen = (uint)loginmessage.ToByteArray().Length;
        SendRequest(msg);
    }
}

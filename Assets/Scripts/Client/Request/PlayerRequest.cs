using Protobuf;
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
        panel.UpdatePlayerList(obj.Players);
    }
}

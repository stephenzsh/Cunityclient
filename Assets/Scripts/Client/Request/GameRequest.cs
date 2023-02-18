using Google.Protobuf;
using Protobuf;
using System;
using System.Linq;
using UnityEngine;

public class GameRequest :BaseRequest
{
    public RoomPanel panel;

    private GameMessage isstart = null;
    public override void Awake()
    {
        base.Awake();
        face.AddRequest(this, ActionCode.StartGame);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        face.RemoveRequest(ActionCode.StartGame);
    }

    private void Update()
    {
        if (isstart != null)
        {
            face.addPlayer(isstart.Players.ToList());
            panel.GameStarting(isstart.Players.ToList());
            isstart = null;
        }
    }

    public override void OnResponse(Message msg)
    {
        isstart = GameMessage.Parser.ParseFrom(msg.Data);
    }
    //public override void OnResponse(Message msg)
    //{
    //    Debug.Log("gamerequest onresponse");
    //    GameMessage obj = GameMessage.Parser.ParseFrom(msg.Data);
    //    if (obj.ReturnCode == ReturnCode.Fail)
    //    {
    //        Debug.Log("player request fail , msg = " + obj.Msg);
    //        panel.FailResponse(obj.Msg);
    //        return;
    //    }
    //    panel.GameStarting(obj.Players.ToList());
    //}
}

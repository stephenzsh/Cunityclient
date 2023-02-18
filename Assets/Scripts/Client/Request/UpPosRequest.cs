
using Google.Protobuf;
using Protobuf;
using System;
using UnityEngine;

public class UpPosRequest :BaseRequest
{

    private Message msg = null;

    public override void Awake()
    {
        base.Awake();
        face.AddRequest(this,ActionCode.UpdatePos);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        face.RemoveRequest(ActionCode.UpdatePos);
    }
    public void SendRequest(Vector2 pos) {
        GameMessage pack = new GameMessage { };
        pack.Msg = face.UserName;
        Player pLayerPack = new Player();
        PosPack posPack = new PosPack();
        posPack.PosX = pos.x;
        posPack.PosY = pos.y;
        
        pLayerPack.Name = face.UserName;
        pLayerPack.Pos = posPack;
        pack.Players.Add(pLayerPack);
        pack.ActionCode = ActionCode.UpdatePos;
        Message msg = new Message();
        msg.Data = pack.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestCode.Game);
        msg.DataLen = (uint)pack.ToByteArray().Length;
        base.SendRequest(msg);
    }

    public override void OnResponse(Message msg)
    {
        this.msg = msg;
    }

    private void Update()
    {
        if(msg != null)
        {
            GameMessage gameMessage = GameMessage.Parser.ParseFrom(msg.Data);
            face.UpPos(gameMessage);
            msg = null;
        }
    }
}


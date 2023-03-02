using Google.Protobuf;
using Protobuf;
using System;
using UnityEngine;

public class UpStateMachine : BaseRequest
{

    private Message msg = null;
    public override void Awake()
    {
        base.Awake();
        face.AddRequest(this, ActionCode.UpdateState);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        face.RemoveRequest(ActionCode.UpdateState);
    }
    public override void OnResponse(Message msg)
    {
        this.msg = msg;
    }

    private void Update()
    {
        if (msg != null)
        {
            GameMessage gameMessage = GameMessage.Parser.ParseFrom(msg.Data);
            face.UpState(gameMessage);
            msg = null;
        }
    }

    public void SendRequest(AnimatorPack animatorPack)
    {
        GameMessage pack = new GameMessage();
        pack.Msg = face.UserName;
        Player pLayerPack = new Player();
        pLayerPack.Animators = animatorPack;
        pLayerPack.Name = face.UserName;
        pack.Players.Add(pLayerPack);
        pack.ActionCode = ActionCode.UpdateState;
        Message msg = new Message();
        msg.Data = pack.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestCode.Game);
        msg.DataLen = (uint)pack.ToByteArray().Length;
        base.SendRequest(msg);
    }
}


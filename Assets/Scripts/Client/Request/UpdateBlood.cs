using Protobuf;
using UnityEngine;

public class UpdateBlood:BaseRequest
{
    public GamePanel panel;


    public override void Awake()
    {
        base.Awake();
        face.AddRequest(this, ActionCode.UpdateBlood);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        face.RemoveRequest(ActionCode.UpdateBlood);
    }

    public override void OnResponse(Message msg)
    {
        Debug.Log("upload blood");
        GameMessage message = GameMessage.Parser.ParseFrom(msg.Data);
        foreach (var Player in message.Players) {
            panel.UpdateValue(Player.Name,Player.Hp);
        }
    }

}


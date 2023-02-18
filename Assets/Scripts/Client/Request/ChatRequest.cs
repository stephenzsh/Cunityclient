using Google.Protobuf;
using Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ChatRequest:BaseRequest
{

    public RoomPanel panel;
    private Message msg;

    private void Update()
    {
        if (msg != null)
        {
            GameMessage gameMessage = GameMessage.Parser.ParseFrom(msg.Data);
            panel.UpdateChat(gameMessage.Roomlist[0]);
            msg = null; 
        }
    }

    public override void OnResponse(Message msg)
    {
        this.msg = msg;
    }
    public override void Awake()
    {
        base.Awake();
        face.AddRequest(this,ActionCode.Chat);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        face.RemoveRequest(ActionCode.Chat);
    }

    public void SendMsg(string roomname, string text)
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
        msg.ID = msg.ID = Convert.ToUInt32(RequestCode.Room);
        msg.DataLen = (uint)message.ToByteArray().Length;
        SendRequest(msg);

    }

    
}


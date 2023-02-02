using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RoomlistRequest : BaseRequest
{
    

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
        face.AddRequest(this, RequestType.Roomlist);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        face.RemoveRequest(RequestType.Register);
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
        RoomMessage message = new RoomMessage()
        {
            Name = roomName,
        };
        Message msg = new Message();
        msg.Data = message.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestType.Roomlist);
        msg.DataLen = (uint)message.ToByteArray().Length;
        SendRequest(msg);
    }



}


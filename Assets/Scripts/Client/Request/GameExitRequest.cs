using Google.Protobuf;
using Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public  class GameExitRequest :BaseRequest{

    private Message msg = null;

    public GamePanel gamePanel;

    public override void Awake()
    {
        base.Awake();
        face.AddRequest(this,ActionCode.ExitGame);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        face.RemoveRequest(ActionCode.ExitGame);
    }

    public void ExitGame() {

        GameMessage gameMessage = new GameMessage();
        gameMessage.ActionCode = ActionCode.ExitGame;
        gameMessage.Msg = face.UserName;
        Message msg = new Message();
        msg.Data = gameMessage.ToByteArray();
        msg.ID = msg.ID = Convert.ToUInt32(RequestCode.Game);
        msg.DataLen = (uint)gameMessage.ToByteArray().Length;
        SendRequest(msg);
        gamePanel.ExitGameResponse();
        //face.removePlayer(face.UserName);
    }

    private void Update()
    {
        if(msg!= null)
        {
            gamePanel.ExitGameResponse();
            msg = null;
        }
    }

    public override void OnResponse(Message msg)
    {
        this.msg = msg;
    }
}


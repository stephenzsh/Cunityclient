using Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GameModule : BaseModel<GameModule>
{
    protected override void InitAddTocHandler()
    {
        AddTocHandler(typeof(GameModule), TocLogin);
    }

    private void TocLogin(object data)
    {
       
    }
}




using Protobuf;
using UnityEngine;


public class LoginRequest : BaseRequest
{
    private static LoginRequest _instance;
    public static LoginRequest Instance
    {
        get
        {
            return _instance;
        }
    }


    public override void Awake()
    {
        base.Awake();
        _instance = new LoginRequest();
    }

    public void SendRequest(string roomname, string operate)
    {

        UserMessage usermessage = new UserMessage()
        {
            Flag = false,
            Roomname = roomname,
            Operate = operate

        };
        //byte[] data = usermessage.ToByteArray();
        // Message pack = new Message((uint)data.Length, 0, data);
        // 序列化 Person 实例
        // byte[] data = john.ToByteArray();

        // 反序列化 Person 实例
        //Person john2 = Person.Parser.ParseFrom(data);
    }

    public void ResovleResponse()
    {

    }
    public void OnClick()
    {
        Debug.Log("dianjishijian");
    }


}

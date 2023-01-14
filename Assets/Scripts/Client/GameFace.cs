
using Protobuf;

using UnityEngine;



//调用游戏
public class GameFace : MonoBehaviour
{
    public UIManager uIManager;

    public RequestManager requestManager;

    public ClientManager clientManager;

    private static GameFace face;
    public static GameFace Face
    {
        get
        {
            if (face == null)
            {
                face = GameObject.Find("GameFace").GetComponent<GameFace>();
            }
            return face;
        }
    }

    void Awake()
    {
        uIManager = new UIManager(this);
        requestManager = new RequestManager(this);
        clientManager = new ClientManager(this);
        uIManager.OnInit();
        requestManager.OnInit();
        clientManager.OnInit();
    }
    

    private void OnDestroy()
    {
        uIManager.OnDestroy();
        requestManager.OnDestroy();
        clientManager.OnDestroy();
    }

    public void Send(Message msg)
    {
        clientManager.Send(msg);
    }
    public void HandleResponse(Message msg, RequestType type)
    {
        requestManager.HandleResponse(msg,type);
    }

    public void AddRequest(BaseRequest request,RequestType type)
    {
        requestManager.AddRequest(request,type);
    }
    public void RemoveRequest(RequestType type)
    {
        requestManager.RemoveRequest(type);
    }





}
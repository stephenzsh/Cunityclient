using Net;
using Protobuf;
using System.Collections;
using UnityEngine;



//调用游戏
public class GameFace : MonoBehaviour
{
    public UIManager uIManager;

    public RequestManager requestManager;

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

    void Start()
    {
        InitNet();
        InitManager();
        //        ChatView.OpenView("Prefabs/ChatView/ChatView");
    }
    void Awake()
    {
        uIManager = new UIManager(this);
        requestManager = new RequestManager(this);
        
        uIManager.OnInit();
        requestManager.OnInit();
    }

    private void OnDestroy()
    {
        uIManager.OnDestroy();
        requestManager.OnDestroy();
    }
    private void InitNet()
    {
        gameObject.AddComponent<NetManager>();
        //NetManager.Instance.SendConnect();
    }

    private void InitManager()
    {
        gameObject.AddComponent<GameModule>();

    }

    public void AddRequest(BaseRequest request)
    {
        requestManager.AddRequest(request);
    }
    public void RemoveRequest(int i)
    {
        requestManager.RemoveRequest(i);
    }

}
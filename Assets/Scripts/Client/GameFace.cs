
using Google.Protobuf.Collections;
using Protobuf;
using System.Collections.Generic;
using UnityEngine;




//调用游戏
public class GameFace : MonoBehaviour
{
    public UIManager uIManager;

    public RequestManager requestManager;

    public ClientManager clientManager;

    public PlayerManager playerManager;

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

    public string UserName
    {
        set; get;
    }

    void Awake()
    {

        requestManager = new RequestManager(this);
        requestManager.OnInit();

        uIManager = new UIManager(this);
        uIManager.OnInit();
       
        playerManager = new PlayerManager(this);
        playerManager.OnInit();
        
        clientManager = new ClientManager(this);
        clientManager.OnInit();

        
    }
    

    private void OnDestroy()
    {        
        clientManager.OnDestroy();
        playerManager.OnDestroy();
        uIManager.OnDestroy();
        requestManager.OnDestroy();
    }

    public void Send(Message msg)
    {
        clientManager.Send(msg);
    }
    public void HandleResponse(Message msg, ActionCode type)
    {
        requestManager.HandleResponse(msg,type);
    }

    public void AddRequest(BaseRequest request,ActionCode type)
    {
        requestManager.AddRequest(request,type);
    }
    public void RemoveRequest(ActionCode type)
    {
        requestManager.RemoveRequest(type);
    }


    public void ShowMessage(string str,bool issync =false)
    {
        uIManager.ShowMessage(str,issync);
    }

   
    public void addPlayer(List<Player> packs ) {
        playerManager.addPlayer(packs);
    }

    public void removePlayer(string id)
    {
        playerManager.RemovePlayer(id);  
    }

    public void ExitGame()
    {
        playerManager.GameExit();
    }
    public void UpPos(GameMessage gameMessage)
    {
        playerManager.UpPos(gameMessage);
    }
    public void UpState(GameMessage gameMessage)
    {
        playerManager.UpState(gameMessage);
    }
   

}
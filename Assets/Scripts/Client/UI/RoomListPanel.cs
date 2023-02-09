using Protobuf;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListPanel : BasePanel
{
    public InputField roomName;
    public Slider num;
    public Button searchButton;
    public Button createButton;
    public Button logoutButton;
    public Transform roomlistTransform;
    public GameObject roomitem;
    public RoomlistRequest roomlistRequest;
    public RoomRequest roomRequest;

    private void Start()
    {
        searchButton.onClick.AddListener(SearchRoom);
        createButton.onClick.AddListener(CreateRoom);
        logoutButton.onClick.AddListener(LogOut);
    }
    private void SearchRoom()
    {
        if (roomName.text == null)
        {
            uIManager.ShowMessage("请输入房间名");
            return;
        }
        roomlistRequest.SearchRoom(roomName.text);

    }
    private void CreateRoom()
    {
        if (roomName.text == null && roomName.text.Length == 0 || roomName.text == "" )
        {
            uIManager.ShowMessage("请输入房间名");
            return;
        }
        if (num.value == 0)
        {
            uIManager.ShowMessage("请选择人数");
            return;
        }
        roomRequest.CreateRoom(roomName.text, (int)num.value);
        
    }
    public void EnterRoom(string name)
    {
        if (name == null )
        {
            uIManager.ShowMessage("请输入房间名");
            return;
        }
        roomRequest.EnterRoom(name);
    }
   
    private void LogOut() {

        uIManager.PopPanel();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Enter();
    }
    public override void OnExit()
    {
        base.OnExit();
        Exit();
    }
    public override void OnRecovery()
    {
        base.OnRecovery();
        Enter();
    }
    public override void OnPause()
    {
     
        base.OnPause();
        Exit();
    }
    
    private void Enter()
    {

        gameObject.SetActive(true);
        SearchRoom();

    }
    private void Exit()
    {
        gameObject.SetActive(false);
        roomName.text = "";
        num.value = 0;

    }

    private void UpdateRoom(GameMessage list)
    {
        
        for (int i = 0;i < roomlistTransform.childCount; i++)
        {
            Destroy(roomlistTransform.GetChild(i).gameObject);
            
        }
        Debug.Log(list.Roomlist);
        foreach (RoomMessage room in list.Roomlist)
        {
            RoomItem item = Instantiate(roomitem,Vector3.zero, Quaternion.identity).GetComponent<RoomItem>();
            item.roomListPanel = this;
            item.gameObject.transform.SetParent(roomlistTransform);
            item.SetRoomInfo(room.Name, (int)room.Num,(int)room.Maxnum,room.Gamestatus);
        }
    }

    public void OnResponse(Message msg)
    {
        GameMessage obj = GameMessage.Parser.ParseFrom(msg.Data);
        UpdateRoom(obj);
    }

    public void JoinRoomResponse(Message msg)
    {
        RoomPanel roompanel = (RoomPanel)uIManager.PushPanel(PanelType.Room);
        GameMessage obj = GameMessage.Parser.ParseFrom(msg.Data);
        
        roompanel.roomname = obj.Roomlist[0].Name;
    }
    public void ExitRoomResponse()
    {
        uIManager.PopPanel();
    }
}


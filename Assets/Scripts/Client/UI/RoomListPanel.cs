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
        roomlistRequest.CreateRoom(roomName.text, (int)num.value);
        
    }
    public void EnterRoom(string name)
    {
        
        if (name == null )
        {
            uIManager.ShowMessage("请输入房间名");
            return;
        }
        roomlistRequest.EnterRoom(name);
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
        if (obj.ReturnCode == ReturnCode.Fail)
        {
            uIManager.ShowMessage(obj.Msg);
            return;
        }
        switch (obj.ActionCode)
        {
            case ActionCode.SearchRoom:
                UpdateRoom(obj);
                break;
            case ActionCode.EnterRoom:

                RoomResponse(obj);
                break;
            case ActionCode.CreateRoom:
                RoomResponse(obj);
                break;
        }
        
    }

    public void RoomResponse(GameMessage msg)
    {
        RoomPanel panel = (RoomPanel)uIManager.PushPanel(PanelType.Room);
        Debug.Log(msg.Msg);
        panel.roomname = msg.Msg;

        panel.GetPlayers();
    }
  

}


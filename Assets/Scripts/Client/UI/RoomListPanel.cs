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
        if (roomName.text == null )
        {
            uIManager.ShowMessage("请输入房间名");
            return;
        }
        roomlistRequest.SearchRoom(roomName.text);
        
    }
    private void CreateRoom()
    {
        if (roomName.text == null )
        {
            uIManager.ShowMessage("请输入房间名和人数");
            return;
        }
        roomRequest.CreateRoom(roomName.text, (int)num.value);
        uIManager.PushPanel(PanelType.Room);
    }
    private void EnterRoom()
    {
        if (roomName.text == null )
        {
            uIManager.ShowMessage("请输入房间名");
            return;
        }
        roomRequest.EnterRoom(roomName.text);
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

    }

    private void UpdateRoom(RoomListMessage list)
    {
        for (int i = 0;i < roomlistTransform.childCount; i++)
        {
            Destroy(roomlistTransform.GetChild(i).gameObject);
            
        }
        foreach(RoomMessage room in list.Roomlist)
        {
            RoomItem item = Instantiate(roomitem, roomlistTransform).GetComponent<RoomItem>();
            item.gameObject.transform.SetParent(roomlistTransform);
            item.SetRoomInfo(room.Name, (int)room.Num,(int)room.Maxnum,room.Gamestatus);
        }
    }

    public void OnResponse(Message msg)
    {
        RoomListMessage obj = RoomListMessage.Parser.ParseFrom(msg.Data);
        UpdateRoom(obj);
    }
}


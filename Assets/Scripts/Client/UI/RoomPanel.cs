
using Protobuf;
using Google.Protobuf.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class RoomPanel : BasePanel
{
    public string roomname;

    public Button exitButton, startButton, sendButton;

    public InputField inputtext;
    public Transform content;
    public Scrollbar scrollbar;
    public Text chattext;
    public GameObject useritemobj;
    
    public GameObject checkwindow;
    public Button accepteButton, rejectButton;

    public RoomExitRequest exitRequest;

    public RoomRequest roomRequest;

    public PlayerRequest playerRequest;

    

    private void Start()
    {
        exitButton.onClick.AddListener(ExitRoomClick);
        sendButton.onClick.AddListener(SendClick);
        startButton.onClick.AddListener(StartGameClick);
        accepteButton.onClick.AddListener(AcceptClick);
        rejectButton.onClick.AddListener(RejectClick);
    }
    public void UpdatePlayerList(RepeatedField<Player> msg)
    {
        for (int i = 0; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);

        }
        
        foreach (Player player  in msg) {
            UserItem useritem = Instantiate(useritemobj, Vector3.zero, Quaternion.identity).GetComponent<UserItem>();
            useritem.gameObject.transform.SetParent(content);
            useritem.SetPlayerName(player.Name);
        }
    }
    private void SendClick()
    {
        roomRequest.SendMsg(this.roomname ,this.inputtext.text);
    }
    private void StartGameClick()
    {
        //uIManager.PushPanel(PanelType.Game);
        roomRequest.StartGame(this.roomname);
        
    }
    private void ExitRoomClick()
    {
        exitRequest.ExitRoom(this.roomname);
        uIManager.PopPanel();
    }
    public void GetPlayers()
    {

        roomRequest.GetPlayerList(this.roomname);
    }
    private void AcceptClick()
    {
        playerRequest.CheckStatus(this.roomname,true);
        checkwindow.SetActive(false);
    }
    private void RejectClick()
    {
        playerRequest.CheckStatus(this.roomname,false);
        checkwindow.SetActive(false);
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
        
    }
    private void Exit()
    {
        gameObject.SetActive(false);

    }
    public void FailResponse(string msg)
    {
        uIManager.ShowMessage(msg);
    }

    public void UpdateChat(RoomMessage roomMessage)
    {
        this.chattext.text = roomMessage.Message;
    }

    public void CheckStatus()
    {
        checkwindow.SetActive(true);
    }

    public void StartGame()
    {
        Debug.Log("ROOMPANEL STARTGAME");
        
    }

    public void GameStarting(List<Player> player)
    {
        Debug.Log("gamestarting  roompanel");
        GamePanel gamePanel = uIManager.PushPanel(PanelType.Game).GetComponent<GamePanel>();
        gamePanel.UpdateList(player);
    }
}


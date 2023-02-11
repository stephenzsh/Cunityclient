
using Protobuf;
using Google.Protobuf.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RoomPanel : BasePanel
{
    public string roomname;

    public Button exitButton, startButton, sendButton;

    public InputField inputtext;
    public Transform content;
    public Scrollbar scrollbar;

    public GameObject useritemobj;

    public RoomExitRequest exitRequest;

    public RoomRequest roomRequest;


    public void GetPlayers()
    {
        Debug.Log(this.roomname);
        roomRequest.GetPlayerList(this.roomname);
    }

    private void Start()
    {
        exitButton.onClick.AddListener(ExitRoomClick);
        sendButton.onClick.AddListener(SendClick);
        startButton.onClick.AddListener(StartGameClick);
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

    }
    private void StartGameClick()
    {

    }
    private void ExitRoomClick()
    {
        exitRequest.ExitRoom(this.roomname);
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
        
    }
    private void Exit()
    {
        gameObject.SetActive(false);

    }
    public void FailResponse(string msg)
    {
        uIManager.ShowMessage(msg);
    }
}


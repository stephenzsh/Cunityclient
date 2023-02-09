
using Protobuf;
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

    private void Start()
    {
        exitButton.onClick.AddListener(ExitRoomClick);
        sendButton.onClick.AddListener(SendClick);
        startButton.onClick.AddListener(StartGameClick);
    }
    public void UpdatePlayerList(RoomMessage msg)
    {
        for (int i = 0; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);

        }
        foreach (string player  in msg.Players.Keys) {
            UserItem useritem = Instantiate(useritemobj, Vector3.zero, Quaternion.identity).GetComponent<UserItem>();
            useritem.gameObject.transform.SetParent(content);
            useritem.SetPlayerName(player);
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
        Debug.Log("exitroomname == " + this.roomname);
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

    public void OnResponse(Message msg)
    {
        
    }
}


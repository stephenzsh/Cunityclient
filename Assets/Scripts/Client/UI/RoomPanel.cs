
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RoomPanel : BasePanel
{
    public Button exitButton, startButton, sendButton;

    public InputField inputtext;
    public Transform content;
    public Scrollbar scrollbar;

    private void Start()
    {
        exitButton.onClick.AddListener(ExitRoomClick);
        sendButton.onClick.AddListener(SendClick);
        startButton.onClick.AddListener(StartGameClick);
    }
    private void SendClick()
    {

    }
    private void StartGameClick()
    {

    }
    private void ExitRoomClick()
    {
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


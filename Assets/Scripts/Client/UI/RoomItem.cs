using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public Button join;
    public Text title, num, status;


    public RoomListPanel roomListPanel;
    // Start is called before the first frame update
    void Start()
    {
        join.onClick.AddListener(OnJoinClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnJoinClick()
    {
        roomListPanel.EnterRoom(this.title.text);
    }


    public void SetRoomInfo(string title,int curnum,int maxnum ,bool status)
    {
        this.title.text = title;
        this.num.text = curnum + "/" + maxnum;
        switch (status)
        {
            case true:
                this.status.text = "游戏中";
                break;
            case false:
                this.status.text = "等待加入";
                break;

        }
        
    }
}

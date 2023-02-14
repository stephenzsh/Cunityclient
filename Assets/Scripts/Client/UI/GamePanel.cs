using Protobuf;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    public GameObject item;

    public Transform listTrans;

    public Text Timetext;

    public Button exitBtn;

    private Dictionary<string,PlayerItem> itemList = new Dictionary<string,PlayerItem>();

    private float starttime;

    private void Start()
    {
        starttime = Time.time;
    }

    public void UpdateList(List<Player> players)
    {
        
        foreach (var player in players) {
            GameObject g = Instantiate(item, Vector3.zero, Quaternion.identity);
            g.transform.SetParent(listTrans);
            PlayerItem pinfo = gameObject.GetComponent<PlayerItem>();
            pinfo.Set(player.Name,player.Hp);
            itemList.Add(player.Name, pinfo);
        }
    }

    private void FixedUpdate()
    {
        Timetext.text = Mathf.Clamp((int)(Time.time - starttime), 0, 300).ToString();
    }

    public void UpdateValue(string id,int v)
    {
       if (itemList.TryGetValue(id, out PlayerItem pinfo))
        {
            pinfo.Up(v);
        }
       else
        {
            Debug.Log("获取不到信息");
        }
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
    }
    public override void OnPause()
    {
        base.OnPause();
    }
    private void Enter()
    {
        gameObject.SetActive(true);
    }
    private void Exit()
    {
        gameObject.SetActive(false);

    }

}

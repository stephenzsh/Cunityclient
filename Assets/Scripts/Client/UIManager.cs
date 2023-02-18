using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : BaseManager
{
    public UIManager(GameFace face) : base(face) { }

    private Dictionary<PanelType, BasePanel> panelDict = new Dictionary<PanelType, BasePanel>();

    private Dictionary<PanelType, string> panelPath = new Dictionary<PanelType, string>();

    private Stack<BasePanel> panelStack = new Stack<BasePanel>();

    private Transform canvasTransform;

    private MessagePanel messagePanel;
    
    public override void OnInit()
    {
        base.OnInit();
        InitPanel();
        canvasTransform = GameObject.Find("Canvas").transform;
       // PushPanel(PanelType.Game);
        PushPanel(PanelType.Message);
        PushPanel(PanelType.Login);
        
    }
    /// <summary>
    /// 界面显示ui
    /// </summary>
    /// <param name="panelType"></param>
    public BasePanel PushPanel(PanelType panelType)
    {

        if (panelDict.TryGetValue(panelType, out BasePanel panel))
        {
            if (panelStack.Count > 0)
            {                   
                    BasePanel topPanel = panelStack.Peek();       
                    topPanel.OnPause();
            }
            panelStack.Push(panel);
            panel.OnEnter();
        
            return panel;
        }
        else
        {
            BasePanel panel1 = SpawnPanel(panelType);
            if (panelStack.Count > 0)
            {
                BasePanel topPanel = panelStack.Peek();
                topPanel.OnPause();
            }
           
            panelStack.Push(panel1);
            panel1.OnEnter();
           
            return panel1;
        }
    }

    public void PopPanel()
    {
        if (panelStack.Count == 0) return;
        
        BasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();
        
        BasePanel panel = panelStack.Peek();
        panel.OnRecovery();
    }

    public BasePanel SpawnPanel(PanelType panelType)
    {
       
        if (panelPath.TryGetValue(panelType, out string path))
        {
            GameObject g = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            g.transform.SetParent(canvasTransform, false);
            BasePanel gpanel = g.GetComponent<BasePanel>();
            gpanel.SetUIMag = this;
            panelDict.Add(panelType, gpanel);
            return gpanel;
        } else {
            return null;
        }
        
    }


    private void InitPanel()
    {
        string panelpath = "Panel/";
        string[] path = new string[] { "MessagePanel","LoginPanel","RegisterPanel", "RoomlistPanel", "RoomPanel", "GamePanel" };
        panelPath.Add(PanelType.Message, panelpath + path[0]);
        panelPath.Add(PanelType.Login, panelpath + path[1]);
        panelPath.Add(PanelType.Register, panelpath + path[2]);
        panelPath.Add(PanelType.Roomlist, panelpath + path[3]);
        panelPath.Add(PanelType.Room, panelpath + path[4]);
        panelPath.Add(PanelType.Game, panelpath + path[5]);

    }
    

    public override void OnDestroy()
    { 
        base.OnDestroy();
    }

    public void SetMessagePanel(MessagePanel panel)
    {
        messagePanel = panel;
    }

 

    public void ShowMessage(string str,bool issync=false)
    {
       
        messagePanel.ShowMessage(str,issync);
    }
}

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
        PushPanel(PanelType.Message);
        PushPanel(PanelType.Login);
        
    }
    /// <summary>
    /// 界面显示ui
    /// </summary>
    /// <param name="panelType"></param>
    public void PushPanel(PanelType panelType)
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

    private BasePanel SpawnPanel(PanelType panelType)
    {
        if (panelPath.TryGetValue(panelType, out string path))
        {
            GameObject g = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            g.transform.SetParent(canvasTransform, false);
            BasePanel gpanel = g.GetComponent<BasePanel>();
            gpanel.SetUIMag = this;
            panelDict.Add(panelType, gpanel);
            return gpanel;
        }
        return null;
    }


    private void InitPanel()
    {
        string panelpath = "Panel/";
        string[] path = new string[] { "MessagePanel","LoginPanel","RegisterPanel", "FightPanel" };
        panelPath.Add(PanelType.Message, panelpath + path[0]);
        panelPath.Add(PanelType.Login, panelpath + path[1]);
        panelPath.Add(PanelType.Register, panelpath + path[2]);
        panelPath.Add(PanelType.Game, panelpath + path[3]);
        

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

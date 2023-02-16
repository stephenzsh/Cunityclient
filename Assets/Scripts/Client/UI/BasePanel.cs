using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BasePanel :MonoBehaviour
{
    protected UIManager uIManager;

    protected GameFace face
    {
        get { return GameFace.Face; }
    }
    public UIManager SetUIMag
    {
        set
        {
            uIManager = value;
        }
    }
    public virtual void OnEnter()
    {
       
    }

    public virtual void OnExit()
    {

    }
    public virtual void OnRecovery()
    {

    }

    public virtual void OnPause()
    {

    }
    

}


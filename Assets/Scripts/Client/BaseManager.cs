using System;
using UnityEngine;
/// <summary>
/// Summary description for Class1
/// </summary>
public class BaseManager
{
    protected GameFace face;

    public BaseManager(GameFace face){
        this.face = face;
    }

	public virtual void OnInit()
    {

    }

    public virtual void OnDestroy()
    {

    }
}

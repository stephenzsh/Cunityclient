using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRequest : MonoBehaviour
{

    protected GameFace face = GameFace.Face;

    //加个enum type,区分不同处理

    public virtual void Awake()
    {
        face.AddRequest(this);
    }

    
}

using Protobuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRequest : MonoBehaviour
{

    protected GameFace face;

    //加个enum type,区分不同处理

    public virtual void Awake()
    {
        face = GameFace.Face;
    }

    public virtual void OnDestroy()
    {
       
    }

    public virtual void OnResponse(Message msg)
    {

    }
   
    public virtual void SendRequest(Message msg, RequestType type) {
        face.Send(msg,type);
    }
}

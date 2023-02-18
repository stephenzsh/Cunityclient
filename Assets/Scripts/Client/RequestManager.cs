using Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RequestManager : BaseManager
{
    public RequestManager(GameFace face) : base(face) { }


    private Dictionary<ActionCode, BaseRequest> requestDict = new Dictionary<ActionCode, BaseRequest>();

    public void AddRequest(BaseRequest request, ActionCode type)
    {
        if (requestDict.TryGetValue(type, out BaseRequest baserequest))
        {
            return;
        } else
        {
            requestDict.Add(type, request);
        }
            
    }

    public void RemoveRequest(ActionCode type)
    {
        requestDict.Remove(type);
    }
    public void HandleResponse(Message msg, ActionCode type)
    {
        
        if (requestDict.TryGetValue(type, out BaseRequest request))
        {
            
            request.OnResponse(msg);
        }
        else
        {
            
            Debug.Log(" 不能处理error");
        }
    }
}


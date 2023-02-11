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


    private Dictionary<RequestType, BaseRequest> requestDict = new Dictionary<RequestType, BaseRequest>();

    public void AddRequest(BaseRequest request,RequestType type)
    {
        if (requestDict.TryGetValue(type, out BaseRequest baserequest))
        {
            return;
        } else
        {
            requestDict.Add(type, request);
        }
            
    }

    public void RemoveRequest(RequestType type)
    {
        requestDict.Remove(type);
    }
    public void HandleResponse(Message msg, RequestType type)
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


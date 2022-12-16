using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class RequestManager :BaseManager
    {
    public RequestManager(GameFace face) : base(face) { }


    //
    private Dictionary<int, BaseRequest> requestDict = new Dictionary<int, BaseRequest>();

    public void AddRequest(BaseRequest request)
    {
        requestDict.Add(0,request);
    }

    public void RemoveRequest(int i)
    {
        requestDict.Remove(i);
    }
}


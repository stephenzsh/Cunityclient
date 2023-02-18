
using Protobuf;
using System;

using System.Net.Sockets;

using System.Threading;

using UnityEngine;

public class ClientManager : BaseManager
{

    private Socket socket;
    private byte[] buffer = new byte[1024];
    
    public ClientManager(GameFace face) : base(face) { }

    public override void OnInit()
    {
        base.OnInit();
        InitSocket();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        CloseSocket();
    }


    private void InitSocket()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        try
        {
            socket.Connect("127.0.0.1", 8999);
            ThreadStart ts = new ThreadStart(StartReceive);
            Thread t = new Thread(ts);
            t.IsBackground=true;
            t.Start();
        }
        catch (Exception e)
        {
            Debug.Log(e);
            face.ShowMessage("服务器连接失败");
        }
    }

    private void StartReceive()
    {
        try
        {
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, socket);
        }
        catch (Exception e)
        {
            Debug.Log("接收数据失败：" + e);
            CloseSocket();
        }
    }

    private void ReceiveCallback(IAsyncResult ar)
    {

        int bytesReceived = socket.EndReceive(ar);
        if (bytesReceived > 0)
        {
            // 处理接收到的数据
            byte[] bytes = new byte[bytesReceived];        
            byte[] msgdata = bytes;
            Array.Copy(buffer, msgdata, bytesReceived);
            Message msg = MessagePack.Unpack(msgdata);
            HandleResponse(msg, (ActionCode)msg.ID);
        }
        else
        {
            CloseSocket();
            return;
        }

        // Begin receiving data again
        StartReceive();
    }
    public void HandleResponse(Message msg, ActionCode type)
    {
        face.HandleResponse(msg, type);
    }

    public void Send(Message msg)
    {
        socket.Send(MessagePack.Pack(msg));
    }


    private void CloseSocket()
    {
        if (socket != null && socket.Connected)
        {
            socket.Close();
        }
    }


    
}


using Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ClientManager : BaseManager
{

    private Socket socket;
    private byte[] dataLengthBytes = new byte[4];
    private byte[] data;
    SocketWrapper wrapper;
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
        wrapper = new SocketWrapper
        {
            Socket = socket,
            Data = data
        };
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
        }
    }

    private void StartReceive()
    {

        //socket.BeginReceive(dataLengthBytes,0,4, SocketFlags.None, ReceiveCallback,null);
        int bytesReceived = socket.Receive(dataLengthBytes);
        int dataLength = BitConverter.ToInt32(dataLengthBytes, 0);
        data = new byte[dataLength];
        socket.BeginReceive(data, 0, data.Length, SocketFlags.None, ReceiveCallback, null);


    }
    private void ReceiveCallback(IAsyncResult ar)
    {

        SocketWrapper wrapper = (SocketWrapper)ar.AsyncState;
        Socket socket = wrapper.Socket;
        int bytesReceived = socket.EndReceive(ar);
        if (bytesReceived > 0)
        {
            // 处理接收到的数据
            byte[] msgdata = wrapper.Data;
            Message msg = MessagePack.Unpack(msgdata);
            HandleResponse(msg, (RequestType)msg.ID);
        }
        StartReceive();

    }
    public void HandleResponse(Message msg, RequestType type)
    {
        face.HandleResponse(msg, type);
    }

    public void Send(Message msg,RequestType type)
    {
        socket.Send(MessagePack.Pack(msg,type));
    }


    private void CloseSocket()
    {
        if (socket != null && socket.Connected)
        {
            socket.Close();
        }
    }


    class SocketWrapper
    {
        public Socket Socket { get; set; }
        public byte[] Data { get; set; }
    }
}


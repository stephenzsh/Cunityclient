using System;
using System.Linq;
using Protobuf;
using Google.Protobuf;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

class MessagePack
{

    Stream stream;
    public static byte[] Pack(Message msg,RequestType type)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, msg);
            byte[] data = stream.ToArray();
            uint datalength = (uint)data.Length;
            byte[] combined = new byte[8 + data.Length];
            Buffer.BlockCopy(BitConverter.GetBytes(datalength), 0, combined, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(Convert.ToUInt32(type)), 0, combined, 4, 4);           
            Buffer.BlockCopy(data, 0, combined, 8,data.Length );
            return data;
        }
       
    }

    public static Message Unpack(byte[] data)
    {
        if (data.Length == 0)
        {
            return null;
        }
        using (MemoryStream stream = new MemoryStream(data))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Message msgdata = (Message)formatter.Deserialize(stream);
            return msgdata;
        }

    }
}


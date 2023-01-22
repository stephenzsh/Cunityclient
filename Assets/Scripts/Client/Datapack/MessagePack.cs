using System;
using System.Linq;
using Protobuf;
using Google.Protobuf;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

class MessagePack
{

    
    public static byte[] Pack(Message msg)
    {
        using (MemoryStream stream = new MemoryStream())
        using (var writer = new BinaryWriter(stream))
            {
                writer.Write(msg.DataLen);
                writer.Write(msg.ID);
                writer.Write(msg.Data);
                return stream.ToArray();
            }
        
       
    }

    public static Message Unpack(byte[] data)
    {
        if (data.Length == 0)
        {
            return null;
        }

        Message msg = new Message();
        msg.DataLen = BitConverter.ToUInt32(data, 0);
        msg.ID = BitConverter.ToUInt32(data, 4);
        msg.Data = new byte[msg.DataLen];
        Array.Copy(data, 8, msg.Data, 0, msg.DataLen);
        return msg;
    }
}


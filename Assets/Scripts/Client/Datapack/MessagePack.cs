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
        using (MemoryStream stream = new MemoryStream(data))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Message msgdata = (Message)formatter.Deserialize(stream);
            return msgdata;
        }

    }
}


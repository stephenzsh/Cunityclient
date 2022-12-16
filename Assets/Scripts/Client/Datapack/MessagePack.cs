using System;
using System.Linq;
using Protobuf;
using Google.Protobuf;

    class MessagePack
    {
        public static byte[] Pack(Message msg)
        {
            msg.Length = msg.Data.Length;
            return msg.ToByteArray();
        }

        public static Message Unpack(byte[] data) {

            Message msg = (Message)Message.Descriptor.Parser.ParseFrom(data);
            return msg;
        }
    }


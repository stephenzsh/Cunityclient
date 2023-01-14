using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Message
{
    public uint DataLen { get; set; }
    public uint ID { get; set; }
    public byte[] Data { get; set; }
}


// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: usermessage.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Protobuf {

  /// <summary>Holder for reflection information generated from usermessage.proto</summary>
  public static partial class UsermessageReflection {

    #region Descriptor
    /// <summary>File descriptor for usermessage.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UsermessageReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChF1c2VybWVzc2FnZS5wcm90bxIIUHJvdG9idWYiPgoLVXNlck1lc3NhZ2US",
            "DwoHb3BlcmF0ZRgBIAEoCRIMCgRmbGFnGAUgASgIEhAKCHJvb21uYW1lGAcg",
            "ASgJYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Protobuf.UserMessage), global::Protobuf.UserMessage.Parser, new[]{ "Operate", "Flag", "Roomname" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class UserMessage : pb::IMessage<UserMessage> {
    private static readonly pb::MessageParser<UserMessage> _parser = new pb::MessageParser<UserMessage>(() => new UserMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<UserMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Protobuf.UsermessageReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserMessage(UserMessage other) : this() {
      operate_ = other.operate_;
      flag_ = other.flag_;
      roomname_ = other.roomname_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserMessage Clone() {
      return new UserMessage(this);
    }

    /// <summary>Field number for the "operate" field.</summary>
    public const int OperateFieldNumber = 1;
    private string operate_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Operate {
      get { return operate_; }
      set {
        operate_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "flag" field.</summary>
    public const int FlagFieldNumber = 5;
    private bool flag_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Flag {
      get { return flag_; }
      set {
        flag_ = value;
      }
    }

    /// <summary>Field number for the "roomname" field.</summary>
    public const int RoomnameFieldNumber = 7;
    private string roomname_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Roomname {
      get { return roomname_; }
      set {
        roomname_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as UserMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(UserMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Operate != other.Operate) return false;
      if (Flag != other.Flag) return false;
      if (Roomname != other.Roomname) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Operate.Length != 0) hash ^= Operate.GetHashCode();
      if (Flag != false) hash ^= Flag.GetHashCode();
      if (Roomname.Length != 0) hash ^= Roomname.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Operate.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Operate);
      }
      if (Flag != false) {
        output.WriteRawTag(40);
        output.WriteBool(Flag);
      }
      if (Roomname.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Roomname);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Operate.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Operate);
      }
      if (Flag != false) {
        size += 1 + 1;
      }
      if (Roomname.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Roomname);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(UserMessage other) {
      if (other == null) {
        return;
      }
      if (other.Operate.Length != 0) {
        Operate = other.Operate;
      }
      if (other.Flag != false) {
        Flag = other.Flag;
      }
      if (other.Roomname.Length != 0) {
        Roomname = other.Roomname;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Operate = input.ReadString();
            break;
          }
          case 40: {
            Flag = input.ReadBool();
            break;
          }
          case 58: {
            Roomname = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code

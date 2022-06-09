// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/SensorEventGenerator.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SensorEmulator {

  /// <summary>Holder for reflection information generated from Protos/SensorEventGenerator.proto</summary>
  public static partial class SensorEventGeneratorReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/SensorEventGenerator.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SensorEventGeneratorReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiFQcm90b3MvU2Vuc29yRXZlbnRHZW5lcmF0b3IucHJvdG8SDlNlbnNvckVt",
            "dWxhdG9yGhtnb29nbGUvcHJvdG9idWYvZW1wdHkucHJvdG8aH2dvb2dsZS9w",
            "cm90b2J1Zi90aW1lc3RhbXAucHJvdG8iiQEKDUV2ZW50UmVzcG9uc2USCgoC",
            "aWQYASABKAMSEwoLdGVtcGVyYXR1cmUYAiABKAESEAoIaHVtaWRpdHkYAyAB",
            "KAESFQoNY2FyYm9uRGlveGlkZRgEIAEoARIuCgpzZW5zb3JUeXBlGAUgASgO",
            "MhouU2Vuc29yRW11bGF0b3IuU2Vuc29yVHlwZSIhCgtUeXBlUmVxdWVzdBIS",
            "CgpzZW5zb3JUeXBlGAEgASgJKiwKClNlbnNvclR5cGUSCgoGU1RSRUVUEAAS",
            "CAoEUk9PTRABEggKBEJPVEgQAjKtAQoORXZlbnRHZW5lcmF0b3ISRgoLRXZl",
            "bnRTdHJlYW0SFi5nb29nbGUucHJvdG9idWYuRW1wdHkaHS5TZW5zb3JFbXVs",
            "YXRvci5FdmVudFJlc3BvbnNlMAESUwoRRXZlbnRTdHJlYW1EdXBsZXgSGy5T",
            "ZW5zb3JFbXVsYXRvci5UeXBlUmVxdWVzdBodLlNlbnNvckVtdWxhdG9yLkV2",
            "ZW50UmVzcG9uc2UoATABQhGqAg5TZW5zb3JFbXVsYXRvcmIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::SensorEmulator.SensorType), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SensorEmulator.EventResponse), global::SensorEmulator.EventResponse.Parser, new[]{ "Id", "Temperature", "Humidity", "CarbonDioxide", "SensorType" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SensorEmulator.TypeRequest), global::SensorEmulator.TypeRequest.Parser, new[]{ "SensorType" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum SensorType {
    [pbr::OriginalName("STREET")] Street = 0,
    [pbr::OriginalName("ROOM")] Room = 1,
    [pbr::OriginalName("BOTH")] Both = 2,
  }

  #endregion

  #region Messages
  public sealed partial class EventResponse : pb::IMessage<EventResponse>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<EventResponse> _parser = new pb::MessageParser<EventResponse>(() => new EventResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<EventResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SensorEmulator.SensorEventGeneratorReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EventResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EventResponse(EventResponse other) : this() {
      id_ = other.id_;
      temperature_ = other.temperature_;
      humidity_ = other.humidity_;
      carbonDioxide_ = other.carbonDioxide_;
      sensorType_ = other.sensorType_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EventResponse Clone() {
      return new EventResponse(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private long id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    /// <summary>Field number for the "temperature" field.</summary>
    public const int TemperatureFieldNumber = 2;
    private double temperature_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public double Temperature {
      get { return temperature_; }
      set {
        temperature_ = value;
      }
    }

    /// <summary>Field number for the "humidity" field.</summary>
    public const int HumidityFieldNumber = 3;
    private double humidity_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public double Humidity {
      get { return humidity_; }
      set {
        humidity_ = value;
      }
    }

    /// <summary>Field number for the "carbonDioxide" field.</summary>
    public const int CarbonDioxideFieldNumber = 4;
    private double carbonDioxide_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public double CarbonDioxide {
      get { return carbonDioxide_; }
      set {
        carbonDioxide_ = value;
      }
    }

    /// <summary>Field number for the "sensorType" field.</summary>
    public const int SensorTypeFieldNumber = 5;
    private global::SensorEmulator.SensorType sensorType_ = global::SensorEmulator.SensorType.Street;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::SensorEmulator.SensorType SensorType {
      get { return sensorType_; }
      set {
        sensorType_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as EventResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(EventResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Temperature, other.Temperature)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Humidity, other.Humidity)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(CarbonDioxide, other.CarbonDioxide)) return false;
      if (SensorType != other.SensorType) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Id != 0L) hash ^= Id.GetHashCode();
      if (Temperature != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Temperature);
      if (Humidity != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Humidity);
      if (CarbonDioxide != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(CarbonDioxide);
      if (SensorType != global::SensorEmulator.SensorType.Street) hash ^= SensorType.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Id != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(Id);
      }
      if (Temperature != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Temperature);
      }
      if (Humidity != 0D) {
        output.WriteRawTag(25);
        output.WriteDouble(Humidity);
      }
      if (CarbonDioxide != 0D) {
        output.WriteRawTag(33);
        output.WriteDouble(CarbonDioxide);
      }
      if (SensorType != global::SensorEmulator.SensorType.Street) {
        output.WriteRawTag(40);
        output.WriteEnum((int) SensorType);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Id != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(Id);
      }
      if (Temperature != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Temperature);
      }
      if (Humidity != 0D) {
        output.WriteRawTag(25);
        output.WriteDouble(Humidity);
      }
      if (CarbonDioxide != 0D) {
        output.WriteRawTag(33);
        output.WriteDouble(CarbonDioxide);
      }
      if (SensorType != global::SensorEmulator.SensorType.Street) {
        output.WriteRawTag(40);
        output.WriteEnum((int) SensorType);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Id != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(Id);
      }
      if (Temperature != 0D) {
        size += 1 + 8;
      }
      if (Humidity != 0D) {
        size += 1 + 8;
      }
      if (CarbonDioxide != 0D) {
        size += 1 + 8;
      }
      if (SensorType != global::SensorEmulator.SensorType.Street) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) SensorType);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(EventResponse other) {
      if (other == null) {
        return;
      }
      if (other.Id != 0L) {
        Id = other.Id;
      }
      if (other.Temperature != 0D) {
        Temperature = other.Temperature;
      }
      if (other.Humidity != 0D) {
        Humidity = other.Humidity;
      }
      if (other.CarbonDioxide != 0D) {
        CarbonDioxide = other.CarbonDioxide;
      }
      if (other.SensorType != global::SensorEmulator.SensorType.Street) {
        SensorType = other.SensorType;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Id = input.ReadInt64();
            break;
          }
          case 17: {
            Temperature = input.ReadDouble();
            break;
          }
          case 25: {
            Humidity = input.ReadDouble();
            break;
          }
          case 33: {
            CarbonDioxide = input.ReadDouble();
            break;
          }
          case 40: {
            SensorType = (global::SensorEmulator.SensorType) input.ReadEnum();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            Id = input.ReadInt64();
            break;
          }
          case 17: {
            Temperature = input.ReadDouble();
            break;
          }
          case 25: {
            Humidity = input.ReadDouble();
            break;
          }
          case 33: {
            CarbonDioxide = input.ReadDouble();
            break;
          }
          case 40: {
            SensorType = (global::SensorEmulator.SensorType) input.ReadEnum();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class TypeRequest : pb::IMessage<TypeRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<TypeRequest> _parser = new pb::MessageParser<TypeRequest>(() => new TypeRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<TypeRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SensorEmulator.SensorEventGeneratorReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TypeRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TypeRequest(TypeRequest other) : this() {
      sensorType_ = other.sensorType_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TypeRequest Clone() {
      return new TypeRequest(this);
    }

    /// <summary>Field number for the "sensorType" field.</summary>
    public const int SensorTypeFieldNumber = 1;
    private string sensorType_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string SensorType {
      get { return sensorType_; }
      set {
        sensorType_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as TypeRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(TypeRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (SensorType != other.SensorType) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (SensorType.Length != 0) hash ^= SensorType.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (SensorType.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(SensorType);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (SensorType.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(SensorType);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (SensorType.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(SensorType);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(TypeRequest other) {
      if (other == null) {
        return;
      }
      if (other.SensorType.Length != 0) {
        SensorType = other.SensorType;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            SensorType = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            SensorType = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code

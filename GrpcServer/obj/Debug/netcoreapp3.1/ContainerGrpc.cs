// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/container.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcServer {
  public static partial class Container
  {
    static readonly string __ServiceName = "container.Container";

    static readonly grpc::Marshaller<global::GrpcServer.WaterRequest> __Marshaller_container_WaterRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.WaterRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcServer.WaterAddResponse> __Marshaller_container_WaterAddResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.WaterAddResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcServer.WaterRemoveResponse> __Marshaller_container_WaterRemoveResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.WaterRemoveResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcServer.WaterAddRequest> __Marshaller_container_WaterAddRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.WaterAddRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcServer.WaterLevelResponse> __Marshaller_container_WaterLevelResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.WaterLevelResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcServer.WaterRemoveRequest> __Marshaller_container_WaterRemoveRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.WaterRemoveRequest.Parser.ParseFrom);

    static readonly grpc::Method<global::GrpcServer.WaterRequest, global::GrpcServer.WaterAddResponse> __Method_ShouldAdd = new grpc::Method<global::GrpcServer.WaterRequest, global::GrpcServer.WaterAddResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ShouldAdd",
        __Marshaller_container_WaterRequest,
        __Marshaller_container_WaterAddResponse);

    static readonly grpc::Method<global::GrpcServer.WaterRequest, global::GrpcServer.WaterRemoveResponse> __Method_ShouldRemove = new grpc::Method<global::GrpcServer.WaterRequest, global::GrpcServer.WaterRemoveResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ShouldRemove",
        __Marshaller_container_WaterRequest,
        __Marshaller_container_WaterRemoveResponse);

    static readonly grpc::Method<global::GrpcServer.WaterAddRequest, global::GrpcServer.WaterLevelResponse> __Method_Add = new grpc::Method<global::GrpcServer.WaterAddRequest, global::GrpcServer.WaterLevelResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Add",
        __Marshaller_container_WaterAddRequest,
        __Marshaller_container_WaterLevelResponse);

    static readonly grpc::Method<global::GrpcServer.WaterRemoveRequest, global::GrpcServer.WaterLevelResponse> __Method_Remove = new grpc::Method<global::GrpcServer.WaterRemoveRequest, global::GrpcServer.WaterLevelResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Remove",
        __Marshaller_container_WaterRemoveRequest,
        __Marshaller_container_WaterLevelResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcServer.ContainerReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Container</summary>
    [grpc::BindServiceMethod(typeof(Container), "BindService")]
    public abstract partial class ContainerBase
    {
      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.WaterAddResponse> ShouldAdd(global::GrpcServer.WaterRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.WaterRemoveResponse> ShouldRemove(global::GrpcServer.WaterRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.WaterLevelResponse> Add(global::GrpcServer.WaterAddRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.WaterLevelResponse> Remove(global::GrpcServer.WaterRemoveRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ContainerBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_ShouldAdd, serviceImpl.ShouldAdd)
          .AddMethod(__Method_ShouldRemove, serviceImpl.ShouldRemove)
          .AddMethod(__Method_Add, serviceImpl.Add)
          .AddMethod(__Method_Remove, serviceImpl.Remove).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ContainerBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_ShouldAdd, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.WaterRequest, global::GrpcServer.WaterAddResponse>(serviceImpl.ShouldAdd));
      serviceBinder.AddMethod(__Method_ShouldRemove, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.WaterRequest, global::GrpcServer.WaterRemoveResponse>(serviceImpl.ShouldRemove));
      serviceBinder.AddMethod(__Method_Add, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.WaterAddRequest, global::GrpcServer.WaterLevelResponse>(serviceImpl.Add));
      serviceBinder.AddMethod(__Method_Remove, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.WaterRemoveRequest, global::GrpcServer.WaterLevelResponse>(serviceImpl.Remove));
    }

  }
}
#endregion

package UsergRPCService;

import static io.grpc.MethodDescriptor.generateFullMethodName;

/**
 * <pre>
 * Definér gRPC tjenesten
 * </pre>
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.66.0)",
    comments = "Source: user.proto")
@io.grpc.stub.annotations.GrpcGenerated
public final class UsergRPCServiceGrpc {

  private UsergRPCServiceGrpc() {}

  public static final java.lang.String SERVICE_NAME = "UsergRPCService.UsergRPCService";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<UsergRPCService.User.CreateUserRequest,
      UsergRPCService.User.UserReply> getCreateUserMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "CreateUser",
      requestType = UsergRPCService.User.CreateUserRequest.class,
      responseType = UsergRPCService.User.UserReply.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<UsergRPCService.User.CreateUserRequest,
      UsergRPCService.User.UserReply> getCreateUserMethod() {
    io.grpc.MethodDescriptor<UsergRPCService.User.CreateUserRequest, UsergRPCService.User.UserReply> getCreateUserMethod;
    if ((getCreateUserMethod = UsergRPCServiceGrpc.getCreateUserMethod) == null) {
      synchronized (UsergRPCServiceGrpc.class) {
        if ((getCreateUserMethod = UsergRPCServiceGrpc.getCreateUserMethod) == null) {
          UsergRPCServiceGrpc.getCreateUserMethod = getCreateUserMethod =
              io.grpc.MethodDescriptor.<UsergRPCService.User.CreateUserRequest, UsergRPCService.User.UserReply>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "CreateUser"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UsergRPCService.User.CreateUserRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UsergRPCService.User.UserReply.getDefaultInstance()))
              .setSchemaDescriptor(new UsergRPCServiceMethodDescriptorSupplier("CreateUser"))
              .build();
        }
      }
    }
    return getCreateUserMethod;
  }

  private static volatile io.grpc.MethodDescriptor<UsergRPCService.User.UserByIdRequest,
      UsergRPCService.User.UserReply> getGetUserByIdMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetUserById",
      requestType = UsergRPCService.User.UserByIdRequest.class,
      responseType = UsergRPCService.User.UserReply.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<UsergRPCService.User.UserByIdRequest,
      UsergRPCService.User.UserReply> getGetUserByIdMethod() {
    io.grpc.MethodDescriptor<UsergRPCService.User.UserByIdRequest, UsergRPCService.User.UserReply> getGetUserByIdMethod;
    if ((getGetUserByIdMethod = UsergRPCServiceGrpc.getGetUserByIdMethod) == null) {
      synchronized (UsergRPCServiceGrpc.class) {
        if ((getGetUserByIdMethod = UsergRPCServiceGrpc.getGetUserByIdMethod) == null) {
          UsergRPCServiceGrpc.getGetUserByIdMethod = getGetUserByIdMethod =
              io.grpc.MethodDescriptor.<UsergRPCService.User.UserByIdRequest, UsergRPCService.User.UserReply>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "GetUserById"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UsergRPCService.User.UserByIdRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UsergRPCService.User.UserReply.getDefaultInstance()))
              .setSchemaDescriptor(new UsergRPCServiceMethodDescriptorSupplier("GetUserById"))
              .build();
        }
      }
    }
    return getGetUserByIdMethod;
  }

  private static volatile io.grpc.MethodDescriptor<UsergRPCService.User.UserByEmailRequest,
      UsergRPCService.User.UserReply> getGetUserByEmailMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetUserByEmail",
      requestType = UsergRPCService.User.UserByEmailRequest.class,
      responseType = UsergRPCService.User.UserReply.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<UsergRPCService.User.UserByEmailRequest,
      UsergRPCService.User.UserReply> getGetUserByEmailMethod() {
    io.grpc.MethodDescriptor<UsergRPCService.User.UserByEmailRequest, UsergRPCService.User.UserReply> getGetUserByEmailMethod;
    if ((getGetUserByEmailMethod = UsergRPCServiceGrpc.getGetUserByEmailMethod) == null) {
      synchronized (UsergRPCServiceGrpc.class) {
        if ((getGetUserByEmailMethod = UsergRPCServiceGrpc.getGetUserByEmailMethod) == null) {
          UsergRPCServiceGrpc.getGetUserByEmailMethod = getGetUserByEmailMethod =
              io.grpc.MethodDescriptor.<UsergRPCService.User.UserByEmailRequest, UsergRPCService.User.UserReply>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "GetUserByEmail"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UsergRPCService.User.UserByEmailRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UsergRPCService.User.UserReply.getDefaultInstance()))
              .setSchemaDescriptor(new UsergRPCServiceMethodDescriptorSupplier("GetUserByEmail"))
              .build();
        }
      }
    }
    return getGetUserByEmailMethod;
  }

  private static volatile io.grpc.MethodDescriptor<UsergRPCService.User.UpdateUserRequest,
      UsergRPCService.User.UserReply> getUpdateUserMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "UpdateUser",
      requestType = UsergRPCService.User.UpdateUserRequest.class,
      responseType = UsergRPCService.User.UserReply.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<UsergRPCService.User.UpdateUserRequest,
      UsergRPCService.User.UserReply> getUpdateUserMethod() {
    io.grpc.MethodDescriptor<UsergRPCService.User.UpdateUserRequest, UsergRPCService.User.UserReply> getUpdateUserMethod;
    if ((getUpdateUserMethod = UsergRPCServiceGrpc.getUpdateUserMethod) == null) {
      synchronized (UsergRPCServiceGrpc.class) {
        if ((getUpdateUserMethod = UsergRPCServiceGrpc.getUpdateUserMethod) == null) {
          UsergRPCServiceGrpc.getUpdateUserMethod = getUpdateUserMethod =
              io.grpc.MethodDescriptor.<UsergRPCService.User.UpdateUserRequest, UsergRPCService.User.UserReply>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "UpdateUser"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UsergRPCService.User.UpdateUserRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UsergRPCService.User.UserReply.getDefaultInstance()))
              .setSchemaDescriptor(new UsergRPCServiceMethodDescriptorSupplier("UpdateUser"))
              .build();
        }
      }
    }
    return getUpdateUserMethod;
  }

  private static volatile io.grpc.MethodDescriptor<UsergRPCService.User.DeleteUserRequest,
      UsergRPCService.User.DeleteReply> getDeleteUserMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "DeleteUser",
      requestType = UsergRPCService.User.DeleteUserRequest.class,
      responseType = UsergRPCService.User.DeleteReply.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<UsergRPCService.User.DeleteUserRequest,
      UsergRPCService.User.DeleteReply> getDeleteUserMethod() {
    io.grpc.MethodDescriptor<UsergRPCService.User.DeleteUserRequest, UsergRPCService.User.DeleteReply> getDeleteUserMethod;
    if ((getDeleteUserMethod = UsergRPCServiceGrpc.getDeleteUserMethod) == null) {
      synchronized (UsergRPCServiceGrpc.class) {
        if ((getDeleteUserMethod = UsergRPCServiceGrpc.getDeleteUserMethod) == null) {
          UsergRPCServiceGrpc.getDeleteUserMethod = getDeleteUserMethod =
              io.grpc.MethodDescriptor.<UsergRPCService.User.DeleteUserRequest, UsergRPCService.User.DeleteReply>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "DeleteUser"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UsergRPCService.User.DeleteUserRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UsergRPCService.User.DeleteReply.getDefaultInstance()))
              .setSchemaDescriptor(new UsergRPCServiceMethodDescriptorSupplier("DeleteUser"))
              .build();
        }
      }
    }
    return getDeleteUserMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static UsergRPCServiceStub newStub(io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<UsergRPCServiceStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<UsergRPCServiceStub>() {
        @java.lang.Override
        public UsergRPCServiceStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new UsergRPCServiceStub(channel, callOptions);
        }
      };
    return UsergRPCServiceStub.newStub(factory, channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static UsergRPCServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<UsergRPCServiceBlockingStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<UsergRPCServiceBlockingStub>() {
        @java.lang.Override
        public UsergRPCServiceBlockingStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new UsergRPCServiceBlockingStub(channel, callOptions);
        }
      };
    return UsergRPCServiceBlockingStub.newStub(factory, channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static UsergRPCServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<UsergRPCServiceFutureStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<UsergRPCServiceFutureStub>() {
        @java.lang.Override
        public UsergRPCServiceFutureStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new UsergRPCServiceFutureStub(channel, callOptions);
        }
      };
    return UsergRPCServiceFutureStub.newStub(factory, channel);
  }

  /**
   * <pre>
   * Definér gRPC tjenesten
   * </pre>
   */
  public interface AsyncService {

    /**
     * <pre>
     * Opret en bruger
     * </pre>
     */
    default void createUser(UsergRPCService.User.CreateUserRequest request,
        io.grpc.stub.StreamObserver<UsergRPCService.User.UserReply> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getCreateUserMethod(), responseObserver);
    }

    /**
     * <pre>
     * Hent en bruger baseret på ID
     * </pre>
     */
    default void getUserById(UsergRPCService.User.UserByIdRequest request,
        io.grpc.stub.StreamObserver<UsergRPCService.User.UserReply> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetUserByIdMethod(), responseObserver);
    }

    /**
     * <pre>
     * Hent en bruger baseret på email
     * </pre>
     */
    default void getUserByEmail(UsergRPCService.User.UserByEmailRequest request,
        io.grpc.stub.StreamObserver<UsergRPCService.User.UserReply> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetUserByEmailMethod(), responseObserver);
    }

    /**
     * <pre>
     * Opdater en bruger
     * </pre>
     */
    default void updateUser(UsergRPCService.User.UpdateUserRequest request,
        io.grpc.stub.StreamObserver<UsergRPCService.User.UserReply> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getUpdateUserMethod(), responseObserver);
    }

    /**
     * <pre>
     * Slet en bruger baseret på ID
     * </pre>
     */
    default void deleteUser(UsergRPCService.User.DeleteUserRequest request,
        io.grpc.stub.StreamObserver<UsergRPCService.User.DeleteReply> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getDeleteUserMethod(), responseObserver);
    }
  }

  /**
   * Base class for the server implementation of the service UsergRPCService.
   * <pre>
   * Definér gRPC tjenesten
   * </pre>
   */
  public static abstract class UsergRPCServiceImplBase
      implements io.grpc.BindableService, AsyncService {

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return UsergRPCServiceGrpc.bindService(this);
    }
  }

  /**
   * A stub to allow clients to do asynchronous rpc calls to service UsergRPCService.
   * <pre>
   * Definér gRPC tjenesten
   * </pre>
   */
  public static final class UsergRPCServiceStub
      extends io.grpc.stub.AbstractAsyncStub<UsergRPCServiceStub> {
    private UsergRPCServiceStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected UsergRPCServiceStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new UsergRPCServiceStub(channel, callOptions);
    }

    /**
     * <pre>
     * Opret en bruger
     * </pre>
     */
    public void createUser(UsergRPCService.User.CreateUserRequest request,
        io.grpc.stub.StreamObserver<UsergRPCService.User.UserReply> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getCreateUserMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     * <pre>
     * Hent en bruger baseret på ID
     * </pre>
     */
    public void getUserById(UsergRPCService.User.UserByIdRequest request,
        io.grpc.stub.StreamObserver<UsergRPCService.User.UserReply> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getGetUserByIdMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     * <pre>
     * Hent en bruger baseret på email
     * </pre>
     */
    public void getUserByEmail(UsergRPCService.User.UserByEmailRequest request,
        io.grpc.stub.StreamObserver<UsergRPCService.User.UserReply> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getGetUserByEmailMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     * <pre>
     * Opdater en bruger
     * </pre>
     */
    public void updateUser(UsergRPCService.User.UpdateUserRequest request,
        io.grpc.stub.StreamObserver<UsergRPCService.User.UserReply> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getUpdateUserMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     * <pre>
     * Slet en bruger baseret på ID
     * </pre>
     */
    public void deleteUser(UsergRPCService.User.DeleteUserRequest request,
        io.grpc.stub.StreamObserver<UsergRPCService.User.DeleteReply> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getDeleteUserMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   * A stub to allow clients to do synchronous rpc calls to service UsergRPCService.
   * <pre>
   * Definér gRPC tjenesten
   * </pre>
   */
  public static final class UsergRPCServiceBlockingStub
      extends io.grpc.stub.AbstractBlockingStub<UsergRPCServiceBlockingStub> {
    private UsergRPCServiceBlockingStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected UsergRPCServiceBlockingStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new UsergRPCServiceBlockingStub(channel, callOptions);
    }

    /**
     * <pre>
     * Opret en bruger
     * </pre>
     */
    public UsergRPCService.User.UserReply createUser(UsergRPCService.User.CreateUserRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getCreateUserMethod(), getCallOptions(), request);
    }

    /**
     * <pre>
     * Hent en bruger baseret på ID
     * </pre>
     */
    public UsergRPCService.User.UserReply getUserById(UsergRPCService.User.UserByIdRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getGetUserByIdMethod(), getCallOptions(), request);
    }

    /**
     * <pre>
     * Hent en bruger baseret på email
     * </pre>
     */
    public UsergRPCService.User.UserReply getUserByEmail(UsergRPCService.User.UserByEmailRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getGetUserByEmailMethod(), getCallOptions(), request);
    }

    /**
     * <pre>
     * Opdater en bruger
     * </pre>
     */
    public UsergRPCService.User.UserReply updateUser(UsergRPCService.User.UpdateUserRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getUpdateUserMethod(), getCallOptions(), request);
    }

    /**
     * <pre>
     * Slet en bruger baseret på ID
     * </pre>
     */
    public UsergRPCService.User.DeleteReply deleteUser(UsergRPCService.User.DeleteUserRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getDeleteUserMethod(), getCallOptions(), request);
    }
  }

  /**
   * A stub to allow clients to do ListenableFuture-style rpc calls to service UsergRPCService.
   * <pre>
   * Definér gRPC tjenesten
   * </pre>
   */
  public static final class UsergRPCServiceFutureStub
      extends io.grpc.stub.AbstractFutureStub<UsergRPCServiceFutureStub> {
    private UsergRPCServiceFutureStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected UsergRPCServiceFutureStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new UsergRPCServiceFutureStub(channel, callOptions);
    }

    /**
     * <pre>
     * Opret en bruger
     * </pre>
     */
    public com.google.common.util.concurrent.ListenableFuture<UsergRPCService.User.UserReply> createUser(
        UsergRPCService.User.CreateUserRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getCreateUserMethod(), getCallOptions()), request);
    }

    /**
     * <pre>
     * Hent en bruger baseret på ID
     * </pre>
     */
    public com.google.common.util.concurrent.ListenableFuture<UsergRPCService.User.UserReply> getUserById(
        UsergRPCService.User.UserByIdRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getGetUserByIdMethod(), getCallOptions()), request);
    }

    /**
     * <pre>
     * Hent en bruger baseret på email
     * </pre>
     */
    public com.google.common.util.concurrent.ListenableFuture<UsergRPCService.User.UserReply> getUserByEmail(
        UsergRPCService.User.UserByEmailRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getGetUserByEmailMethod(), getCallOptions()), request);
    }

    /**
     * <pre>
     * Opdater en bruger
     * </pre>
     */
    public com.google.common.util.concurrent.ListenableFuture<UsergRPCService.User.UserReply> updateUser(
        UsergRPCService.User.UpdateUserRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getUpdateUserMethod(), getCallOptions()), request);
    }

    /**
     * <pre>
     * Slet en bruger baseret på ID
     * </pre>
     */
    public com.google.common.util.concurrent.ListenableFuture<UsergRPCService.User.DeleteReply> deleteUser(
        UsergRPCService.User.DeleteUserRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getDeleteUserMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_CREATE_USER = 0;
  private static final int METHODID_GET_USER_BY_ID = 1;
  private static final int METHODID_GET_USER_BY_EMAIL = 2;
  private static final int METHODID_UPDATE_USER = 3;
  private static final int METHODID_DELETE_USER = 4;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final AsyncService serviceImpl;
    private final int methodId;

    MethodHandlers(AsyncService serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_CREATE_USER:
          serviceImpl.createUser((UsergRPCService.User.CreateUserRequest) request,
              (io.grpc.stub.StreamObserver<UsergRPCService.User.UserReply>) responseObserver);
          break;
        case METHODID_GET_USER_BY_ID:
          serviceImpl.getUserById((UsergRPCService.User.UserByIdRequest) request,
              (io.grpc.stub.StreamObserver<UsergRPCService.User.UserReply>) responseObserver);
          break;
        case METHODID_GET_USER_BY_EMAIL:
          serviceImpl.getUserByEmail((UsergRPCService.User.UserByEmailRequest) request,
              (io.grpc.stub.StreamObserver<UsergRPCService.User.UserReply>) responseObserver);
          break;
        case METHODID_UPDATE_USER:
          serviceImpl.updateUser((UsergRPCService.User.UpdateUserRequest) request,
              (io.grpc.stub.StreamObserver<UsergRPCService.User.UserReply>) responseObserver);
          break;
        case METHODID_DELETE_USER:
          serviceImpl.deleteUser((UsergRPCService.User.DeleteUserRequest) request,
              (io.grpc.stub.StreamObserver<UsergRPCService.User.DeleteReply>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        default:
          throw new AssertionError();
      }
    }
  }

  public static final io.grpc.ServerServiceDefinition bindService(AsyncService service) {
    return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
        .addMethod(
          getCreateUserMethod(),
          io.grpc.stub.ServerCalls.asyncUnaryCall(
            new MethodHandlers<
              UsergRPCService.User.CreateUserRequest,
              UsergRPCService.User.UserReply>(
                service, METHODID_CREATE_USER)))
        .addMethod(
          getGetUserByIdMethod(),
          io.grpc.stub.ServerCalls.asyncUnaryCall(
            new MethodHandlers<
              UsergRPCService.User.UserByIdRequest,
              UsergRPCService.User.UserReply>(
                service, METHODID_GET_USER_BY_ID)))
        .addMethod(
          getGetUserByEmailMethod(),
          io.grpc.stub.ServerCalls.asyncUnaryCall(
            new MethodHandlers<
              UsergRPCService.User.UserByEmailRequest,
              UsergRPCService.User.UserReply>(
                service, METHODID_GET_USER_BY_EMAIL)))
        .addMethod(
          getUpdateUserMethod(),
          io.grpc.stub.ServerCalls.asyncUnaryCall(
            new MethodHandlers<
              UsergRPCService.User.UpdateUserRequest,
              UsergRPCService.User.UserReply>(
                service, METHODID_UPDATE_USER)))
        .addMethod(
          getDeleteUserMethod(),
          io.grpc.stub.ServerCalls.asyncUnaryCall(
            new MethodHandlers<
              UsergRPCService.User.DeleteUserRequest,
              UsergRPCService.User.DeleteReply>(
                service, METHODID_DELETE_USER)))
        .build();
  }

  private static abstract class UsergRPCServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    UsergRPCServiceBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return UsergRPCService.User.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("UsergRPCService");
    }
  }

  private static final class UsergRPCServiceFileDescriptorSupplier
      extends UsergRPCServiceBaseDescriptorSupplier {
    UsergRPCServiceFileDescriptorSupplier() {}
  }

  private static final class UsergRPCServiceMethodDescriptorSupplier
      extends UsergRPCServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final java.lang.String methodName;

    UsergRPCServiceMethodDescriptorSupplier(java.lang.String methodName) {
      this.methodName = methodName;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (UsergRPCServiceGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new UsergRPCServiceFileDescriptorSupplier())
              .addMethod(getCreateUserMethod())
              .addMethod(getGetUserByIdMethod())
              .addMethod(getGetUserByEmailMethod())
              .addMethod(getUpdateUserMethod())
              .addMethod(getDeleteUserMethod())
              .build();
        }
      }
    }
    return result;
  }
}

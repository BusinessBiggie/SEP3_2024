package com.sep3.notification.Api.grpc;

import UsergRPCService.User;
import UsergRPCService.UsergRPCServiceGrpc;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import org.springframework.stereotype.Service;

import javax.annotation.PreDestroy;

@Service
public class UserService {

  private final ManagedChannel managedChannel;
  private final UsergRPCServiceGrpc.UsergRPCServiceBlockingStub stub;

  public UserService() {
    // Create a single ManagedChannel instance
    this.managedChannel = ManagedChannelBuilder.forAddress("localhost", 5117)
        .usePlaintext()
        .build();
    this.stub = UsergRPCServiceGrpc.newBlockingStub(managedChannel);
  }

  public User.UserReply getUser(String id) {
    User.UserByIdRequest request = User.UserByIdRequest.newBuilder()
        .setId(id)
        .build();
    return stub.getUserById(request);
  }

  // Gracefully shutdown the channel when the application stops
  @PreDestroy
  public void shutdownChannel() {
    System.out.println("Shutting down gRPC ManagedChannel...");
    if (managedChannel != null && !managedChannel.isShutdown()) {
      managedChannel.shutdown();
    }
  }
}

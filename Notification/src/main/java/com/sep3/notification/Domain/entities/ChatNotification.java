package com.sep3.notification.Domain.entities;


import UsergRPCService.User;
import com.sep3.notification.Api.grpc.UserService;
import jakarta.persistence.*;
import org.springframework.beans.factory.annotation.Autowired;

@Entity
@DiscriminatorValue("ChatNotification")
public class ChatNotification extends EmailTemplate {

  @Transient
  @Autowired UserService userService;
  @Override public String getBody()
  {
    return super.getBody();
  }

  @Override public String getSubject()
  {
    return super.getSubject();
  }

  @Override public Mail generateMail(String id){
    User.UserReply reply = userService.getUser(id);
    Mail mail = new Mail(reply.getEmail(),"insert mail",getSubject(),getBody());
    return mail;
  }
}

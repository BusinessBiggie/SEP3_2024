package com.sep3.notification.Domain.services;


import UsergRPCService.User;
import com.sep3.notification.Api.grpc.UserService;
import com.sep3.notification.Domain.entities.Mail;
import com.sep3.notification.Domain.entities.EmailTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class MailService {

  private final UserService userService;

  @Autowired
  public MailService(UserService userService) {
    this.userService = userService;
  }

  public Mail generateNotificationMail(String id, EmailTemplate template) {
    User.UserReply reply = userService.getUser(id);
    String subject = template.getSubject();
    String body = template.getBody();
    return new Mail(reply.getEmail(), "insert mail", subject, body);
  }
}

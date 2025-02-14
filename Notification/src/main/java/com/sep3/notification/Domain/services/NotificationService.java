package com.sep3.notification.Domain.services;


import com.sep3.notification.Domain.entities.Mail;
import com.sep3.notification.Domain.entities.NotificationAlert;
import com.sep3.notification.Domain.entities.RegistrationNotification;
import com.sep3.notification.Infrastructure.repositories.EmailTemplateRepository;
import com.sep3.notification.Domain.entities.ChatNotification;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class NotificationService
{
  @Autowired
  EmailTemplateRepository templateRepository;

  @Autowired MailService mailService;

  public void Handler(NotificationAlert alert){
    String id = String.valueOf(alert.getId());
    switch(alert.getType()){
      case CHAT_NOTIFICATION:
        ChatNotification template = templateRepository.findAllChatNotifications();
        Mail mail = mailService.generateNotificationMail(id,template);
        mail.send();
        break;
      case WELCOME_MAIL:
        RegistrationNotification templateReg = templateRepository.findRegistrationNotification();
        Mail mailReg = mailService.generateNotificationMail(id,templateReg);
        mailReg.send();
        break;

    }
  }
}

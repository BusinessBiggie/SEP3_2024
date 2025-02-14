package com.sep3.notification.Infrastructure.repositories;
import com.sep3.notification.Domain.entities.ChatNotification;
import com.sep3.notification.Domain.entities.RegistrationNotification;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import com.sep3.notification.Domain.entities.EmailTemplate;

@Repository
public interface EmailTemplateRepository extends JpaRepository<EmailTemplate, Long> {

  @Query("SELECT e FROM EmailTemplate e WHERE TYPE(e) = ChatNotification")
  ChatNotification findAllChatNotifications();

  @Query("SELECT e FROM EmailTemplate e WHERE TYPE(e) = RegistrationNotification")
  RegistrationNotification findRegistrationNotification();



}


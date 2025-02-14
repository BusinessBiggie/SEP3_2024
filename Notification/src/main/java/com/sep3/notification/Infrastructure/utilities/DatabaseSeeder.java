package com.sep3.notification.Infrastructure.utilities;

import com.sep3.notification.Domain.entities.ChatNotification;
import com.sep3.notification.Domain.entities.EmailTemplate;
import com.sep3.notification.Domain.entities.EmailType;
import com.sep3.notification.Domain.entities.RegistrationNotification;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;
import jakarta.persistence.EntityManager;
import jakarta.transaction.Transactional;

@Component
public class DatabaseSeeder implements CommandLineRunner {

  private final EntityManager entityManager;

  public DatabaseSeeder(EntityManager entityManager) {
    this.entityManager = entityManager;
  }

  @Override
  @Transactional
  public void run(String... args) throws Exception {
    if (entityManager.find(EmailTemplate.class, 1L) == null) {

      ChatNotification entityChatNotification = new ChatNotification();
      entityChatNotification.setBody("Unread notification");
      entityChatNotification.setSubject("You have an unread message at EcoUme!");
      entityChatNotification.setType(EmailType.CHAT_NOTIFICATION);

      entityManager.persist(entityChatNotification);

      RegistrationNotification entityRegistrationNotification = new RegistrationNotification();
      entityRegistrationNotification.setBody("You have signed up for EcoUme! If you did not create the account, feel free to not contact us.");
      entityRegistrationNotification.setSubject("Registration successful");
      entityRegistrationNotification.setType(EmailType.WELCOME_MAIL);
      entityManager.persist(entityRegistrationNotification);
    }
  }
}
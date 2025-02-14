package com.sep3.notification.Infrastructure.utilities;

import com.rabbitmq.client.Channel;
import com.rabbitmq.client.Connection;
import com.rabbitmq.client.ConnectionFactory;
import com.rabbitmq.client.DeliverCallback;
import com.sep3.notification.Domain.entities.NotificationAlert;
import com.sep3.notification.Domain.services.NotificationService;
import jakarta.annotation.PostConstruct;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.util.concurrent.TimeoutException;

@Component
public class RecvRabbitMQ
{

  private final static String QUEUE_NAME = "Notification_Out";

  @Autowired NotificationService notificationService;


  @PostConstruct
  public void init() {

    try {
      ReceiveAlert();
    } catch (IOException | TimeoutException e) {
      throw new RuntimeException("Failed to initialize RabbitMQ listener", e);
    }
  }

  public void ReceiveAlert() throws IOException, TimeoutException
  {
    ConnectionFactory factory = new ConnectionFactory();
    factory.setHost("ip");
    factory.setUsername("NotificationApp");
    factory.setPassword("password");
    Connection connection = factory.newConnection();
    Channel channel = connection.createChannel();

    channel.queueDeclare(QUEUE_NAME, false, false, false, null);
    System.out.println(" [*] Waiting for messages. To exit press CTRL+C");

    DeliverCallback deliverCallback = (consumerTag, delivery) -> {
      String message = new String(delivery.getBody(), StandardCharsets.UTF_8);

      try {
        NotificationAlert alert = AlertDeserializer.convertJsonStringToTray(message);
        notificationService.Handler(alert);
        System.out.println(" [x] Received '" + message + "'");
      } catch (Exception e) {
        System.err.println("Error processing message: " + message);
        e.printStackTrace();
      }
    };
    channel.basicConsume(QUEUE_NAME, true, deliverCallback, consumerTag -> { });
  }

}
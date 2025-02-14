package com.sep3.notification.Infrastructure.utilities;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.sep3.notification.Domain.entities.NotificationAlert;

public class AlertDeserializer
{
  private static final ObjectMapper objectMapper = new ObjectMapper();
  public static NotificationAlert convertJsonStringToTray(String jsonString) {
    try {
      return objectMapper.readValue(jsonString, NotificationAlert.class);
    } catch (Exception e) {
      e.printStackTrace();
      return null; // or handle the exception as needed
    }
  }
}

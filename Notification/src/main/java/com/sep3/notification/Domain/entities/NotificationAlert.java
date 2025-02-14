package com.sep3.notification.Domain.entities;

import com.fasterxml.jackson.annotation.JsonProperty;

public class NotificationAlert
{
  @JsonProperty("UserId")
  private int id;

  @JsonProperty("Type")
  private EmailType type;

  public NotificationAlert(int id, EmailType type)
  {
    this.id = id;
    this.type = type;
  }

  public NotificationAlert() {
  }

  public int getId()
  {
    return id;
  }

  public void setId(int id)
  {
    this.id = id;
  }

  public EmailType getType()
  {
    return type;
  }

  public void setType(EmailType type)
  {
    this.type = type;
  }
}

package com.sep3.notification.Domain.entities;


import jakarta.persistence.*;

@Entity
@Inheritance(strategy = InheritanceType.SINGLE_TABLE)
@DiscriminatorColumn(name = "entity_type", discriminatorType = DiscriminatorType.STRING)
@Table(name = "chat_notification_templates")
public abstract class EmailTemplate {

  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  private int id;

  @Column(nullable = false)
  private String subject;

  @Column(nullable = false, columnDefinition = "TEXT")
  private String body;

  @Column(nullable = false)
  private EmailType type;
  // Enum for type of email, you can define different types

  public int getId()
  {
    return id;
  }

  public EmailType getType()
  {
    return type;
  }

  public abstract Mail generateMail(String id);

 public String getBody(){
    return body;
  }
 public String getSubject(){
    return subject;
 }

  public void setSubject(String subject)
  {
    this.subject = subject;
  }

  public void setBody(String body)
  {
    this.body = body;
  }

  public void setType(EmailType type)
  {
    this.type = type;
  }

}


package com.sep3.notification.Domain.entities;

public class Mail {

  private Long id;

  private String reciever;

  private String sender;

  private String subject;

  private String body;

  public Mail() {}


  public Mail(String reciever, String sender, String subject, String body) {
    this.reciever = reciever;
    this.sender = sender;
    this.subject = subject;
    this.body = body;
  }

  // Getters and Setters
  public String getreciever() {
    return reciever;
  }

  public void setreciever(String reciever) {
    this.reciever = reciever;
  }

  public String getFrom() {
    return sender;
  }

  public void setFrom(String from) {
    this.sender = sender;
  }

  public String getSubject() {
    return subject;
  }

  public void setSubject(String subject) {
    this.subject = subject;
  }

  public String getBody() {
    return body;
  }

  public void setBody(String body) {
    this.body = body;
  }

  public void send() {
    System.out.println("Sending email reciever: " + this.reciever);
    TLSEmail util = new TLSEmail();
    util.sendMail(this);
  }
}


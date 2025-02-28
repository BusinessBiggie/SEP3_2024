package com.sep3.notification.Domain.entities;


import com.sep3.notification.Infrastructure.utilities.EmailUtil;

import java.util.Properties;

import javax.mail.Authenticator;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;

public class TLSEmail {

  /**
   Outgoing Mail (SMTP) Server
   requires TLS or SSL: smtp.gmail.com (use authentication)
   Use Authentication: Yes
   Port for TLS/STARTTLS: 587
   */
  public void sendMail(Mail mail) {
    final String fromEmail = "redacted"; //requires valid gmail id
    final String password = "redacted"; // correct password for gmail id

    System.out.println("TLSEmail Start");
    Properties props = new Properties();
    props.put("mail.smtp.host", "redacted"); //SMTP Host
    props.put("mail.smtp.port", "587"); //TLS Port
    props.put("mail.smtp.auth", "true"); //enable authentication
    props.put("mail.smtp.starttls.enable", "true"); //enable STARTTLS

    //create Authenticator object to pass in Session.getInstance argument
    Authenticator auth = new Authenticator() {
      //override the getPasswordAuthentication method
      protected PasswordAuthentication getPasswordAuthentication() {
        return new PasswordAuthentication(fromEmail, password);
      }
    };
    Session session = Session.getInstance(props, auth);

    EmailUtil.sendEmail(session, mail.getreciever(),mail.getSubject(), mail.getBody());

  }


}

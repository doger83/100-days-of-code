
  <?php

  /* All form fields are automatically passed to the PHP script through the array $HTTP_POST_VARS. */
  $email = 'Dominic@gerweck2.de';
  $subject = $HTTP_POST_VARS['subject'];
  $message = $HTTP_POST_VARS['message'];
  // Set From: header
   $from =  $name . " <" . $email . ">";

   // Email Headers
	
	$headers = "Reply-To: ". $email . "\r\n";
 	$headers .= "MIME-Version: 1.0\r\n";
	$headers .= "Content-Type: text/html; charset=ISO-8859-1\r\n";

  /* PHP form validation: the script checks that the Email field contains a valid email address and the Subject field isn't empty. preg_match performs a regular expression match. It's a very powerful PHP function to validate form fields and other strings - see PHP manual for details. */
  if (!preg_match("/\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/", $email)) {
  echo "<h4>Invalid email address</h4>";
  echo "<a href='javascript:history.back(1);'>Back</a>";
  } elseif ($subject == "2") {
  echo "<h4>No subject</h4>";
  echo "<a href='javascript:history.back(1);'>Back</a>";
  }

  /* Sends the mail and outputs the "Thank you" string if the mail is successfully sent, or the error string otherwise. */
  elseif (mail($email,$subject,$message,$headers, "-f Dominic@gerweck2")) {
  echo "<h4>Thank you for sending email</h4>";
  } else {
  echo "<h4>Can't send email to $email</h4>";
  }
  ?>

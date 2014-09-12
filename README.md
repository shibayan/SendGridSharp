SendGridSharp
=============

Yet Another SendGrid Client for C#

## Usage

```
var client = new SendGridClient(new NetworkCredential("API_USER", "API_KEY"));

var message = new SendGridMessage();

message.To.Add("****@****.com");
message.From = "****@****.com";

message.Header.AddSubstitution("-name-", "customer");

message.Subject = "Dear -name- ";
message.Html = "<p>html message</p>";
message

client.Send(message);
```

SendGridSharp
=============

Simplify SendGrid REST / SMTP API Client for C#

## Usage

```csharp
// Use API Key
var client = new SendGridClient("API_KEY");
// use SendGrid credential
//var client = new SendGridClient(new NetworkCredential("USERNAME", "PASSWORD"));

var message = new SendGridMessage();

message.To.Add("****@****.com");
message.From = "****@****.com";

message.Header.AddSubstitution("-name-", "customer");

message.Subject = "Dear -name- ";
message.Html = "<p>html message</p>";
message.Text = "text message";

client.Send(message);
```

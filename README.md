# SendGridSharp

![Build](https://github.com/shibayan/SendGridSharp/workflows/Build/badge.svg)
[![Downloads](https://img.shields.io/nuget/dt/SendGridSharp.svg)](https://www.nuget.org/packages/SendGridSharp/)
[![NuGet](https://img.shields.io/nuget/v/SendGridSharp)](https://www.nuget.org/packages/SendGridSharp/)
[![License](https://img.shields.io/github/license/shibayan/SendGridSharp)](https://github.com/shibayan/SendGridSharp/blob/master/LICENSE)

Simplify SendGrid SMTP / REST v2 API Client for C# / .NET Standard

## Install

```
Install-Package SendGridSharp
```

```
dotnet add package SendGridSharp
```

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

## License

This project is licensed under the [MIT License](https://github.com/shibayan/SendGridSharp/blob/master/LICENSE)

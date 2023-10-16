# Ninjasoft.MailBuilder
A utility to help build email in code

## Purpose
The purpose of this project is to provide a utility to build email messages in code.

## Usage
Start by creating a new instance of 'MailMessageBuilder' in the following way
```
var mailMessageBuilder = new MailMessageBuilder();
```

This is setup as a builder pattern so the variable name from above is not necessary if that is the route you are going down.

There are two end paths of the builder: `Send` and `Build`

### Build
The return type of Build is a `MailMessage` in the `System.Net.Mail` namespace.
```
var mailMessage = new MailMessageBuilder()
	.SetFrom("no-reply@domain.com")
	.AddRecipient("user@test.com")
	.Build();
```

### Send
The return type of `Send` is void and will actually send the email if you have provided valid settings to the included proxy class.
```
var smtpProxy = new SmtpClientProxy();

new MailMessageBuilder(smtpProxy)
	.SetFrom("no-reply@domain.com")
	.AddRecipient("user@test.com")
	.Send();
```

There is also an async version of `Send`
```
var smtpProxy = new SmtpClientProxy();

await new MailMessageBuilder(smtpProxy)
	.SetFrom("no-reply@domain.com")
	.AddRecipient("user@test.com")
	.SendAsync();
```
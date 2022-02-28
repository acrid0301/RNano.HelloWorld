# RNANO HELLO WORLD - Using IoC

## NOTE:
This code is not for distribution. It was intended for the company I am applying for as part of thier code exam process.
This code was designed based on the requirements they provided and it shows how it will be scale to support future enhancement. 

## Version 1.0 Information
The code was developed using C# .Net Core version 2.0

### License: Not Applicable

### Features/Requirements

* Writes Hello World to the console screen.
* Coded the way to support Mobile applications, Web applications, Windows Services and applications.
* Created a Fake data context to be modified to a preferred database
* Configuration compatibility, can be enhance based on the business requirements.
* Logger compatibility

### Unit Tests Added 

* Unit testing for Api controller
* Unit testing for Service
* Unit testing for Proxy

### Code Usage 

```csharp
 Console.WriteLine("======= Get Hello Message using Uow Factory =======");
	using (var svc = _uFactory.Create())
	{
		var model = svc.Message.GetMessage();
		if (model != null)
			Console.WriteLine(model.Message);
	};

Console.WriteLine("======= Get Hello Message using Proxy Factory =======");
	using (var proxy = _pFactory.CreateMessageProxy())
	{
		var model = await proxy.GetMessage();
		if (model != null)
			Console.WriteLine(model.Message);
	};

```
### Project Contents

* RNano Hello World - Api
* RNano Hello World - Domain
* RNano Hello World - Domain Model
* RNano Hello World - Infrastructure
* RNano Hello World - Proxy
* RNano Hello World - Console App
* RNano Hello World - Unit Tests

### Getting Started

1. Download the Project
2. Open appsettings.json and make sure the service uri is pointing to your Api
```
{
  "ServiceBaseUri": "http://localhost:60162/api/"
}

```
4. The project has multiple start up. It will start the api first and then the console application.
5. Run the solution project


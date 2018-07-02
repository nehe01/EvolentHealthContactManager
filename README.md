# Evolent Health Contact Manager
Its for maintaining the contact information

# Software Requirements
- .Net core 2.0 runtime (https://www.microsoft.com/net/download/all)
- .Net core web hosting bundle (https://www.microsoft.com/net/download/dotnet-core/runtime-2.0.3) under windows
- IIS
- SQL Server
- Postman (if only api want to test) (optional)

# Steps to run the application

- Clone source code from github repository using this ssh url (git@github.com:nehe01/EvolentHealthContactManager.git).
- Run ci-build script form command prompt at root level to build and publish project. It will publish artifacts on ".\src\Contact.Manager.Api\bin\Release\netcoreapp2.0\publish\".
- Copy mdf file from root folder and copy it in local drive and mention that path to the value of attachdbfile in appsettings.json of publish folder
- In appsettings.json file, Replace contactsdatabase value with '"Server=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\mdf\\EvolentHealthContactsDb.mdf;Database=EvolentHealthContactsDb;Trusted_Connection=True;"' - Change server value according to database source.
- Create a Website in IIS and refer above location for physical path and use port no '64984', as we dont have to change it in js file
- While configuring website make sure that in application pool of that website select "No Managed Code" for .net framework version as we are using .Net core

- Launch the Website (This request will open index.html file)
- To verify list/add/edit/delete features, I have provided simple ui where you can perform all operations which is mentioned.
	OR
- Use any Web API testing tools like Postman. To add contact use same link with POST Http request, To edit contact use same link with PUT Http request, To list contacts use same url with GET Http request, To delete contacts use same link with DELETE Http request

# Solution Architechture:
- Contact.Manager.Api: This is main web api which perform CRUD operations. This is business logic of application.
	- wwwroot: This contains all js, css and html files which are used in application's UI.
- Contact.Manager.Data.Access.Layer: This is data access layer which is used for EF database operations
- Contact.Manager.Api.Tests: This is mainly for tests of project. (Due to time constraints test are not written)

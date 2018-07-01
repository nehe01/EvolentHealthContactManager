# Evolent Health Contact Manager
Its for maintaining the contact information

Software Requirements
.net core 2.0 runtime
.net core web hosting bundle
IIS
SQL Server or localdb of visual studio
Postman (if only api want to test) (optional)

Steps to run the application

- Clone source code from github repository using this ssh url (git@github.com:nehe01/EvolentHealthContactManager.git).
- Run ci-build script to build and publish project. It will publish artifacts on ".\src\Contact.Manager.Api\bin\Release\netcoreapp2.0\publish\".
- Create a Website in IIS and refer above location for physical path and use port no '64984', as we dont have to change it in js file
- While configuring website make sure that in applicatin pool of that website select "No Managed Code" for .net framework version
- Change connection string value of attachdbfilename accordingly where mdf file is placed and also change server value according to database source in appsettings.json file.

- Launch the Website (This request will open index.html file)
- To verify list/add/edit/delete features, I have provided simple ui where you can perform all operations which is mentioned.
	OR
- Use any Web API testing tools like Postman. To add contact use same link with POST Http request, To edit contact use same link with PUT Http request, To list contacts use same url with GET Http request, To delete contacts use same link with DELETE Http request

Solution Architechture:
Contact.Manager.Api: This is main web api which perform CRUD operations. This is business logic of application.
	- wwwroot: This contains all js, css and html files which are used in application's UI.
Contact.Manager.Data.Access.Layer: This is data access layer which is used for EF database operations
Contact.Manager.Api.Tests: This is mainly for tests of project. (Due to time constraints test are not written)

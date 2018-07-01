# Evolent Health Contact Manager
Its for maintaining the contact information

Software Requirements
.net core 2.0
IIS
SQL Server
Postman (if only api want to test)

Steps to run the application

Clone source code from github repository using this ssh url (git@github.com:nehe01/EvolentHealthContactManager.git).

Execute SQL Scripts to create database and tables.
Create a Website in IIS and refer the source code.
Launch the Website then navigate to "~/api/ContactWebApi"(This request will list all the contacts info)
To verify add/edit/delete features, use any Web API testing tools like Postman. for add use same link with POST Http request for edit use same link with PUT Http request for delete use same link with DELETE Http request
Architechture
DataAccessLayer:	This layer is responsible to perform CRUD operations.
BusinessLayer:	This layer is responsible to enforce business operations on data entities.
WebAPI:	This layer is responsible to get a WebApi request and contact other layers to process the request.
# Ntt Data Test Case
## Social Media Application

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Social Media Application is a showing user posts, It means that basically doing CRUD application on Authenticated user. It contains belowing the technologies.

- .NET 6 Web API (Backend)
- React JS (Frontend)
- Mongo DB(No SQL Database)

✨Magic ✨

It includes that belowing the topics;
- Inversion Of Control (Autofac) - To make Dependency Injection
- SOLID Princliples
- Aspect Oriented Programming
- JWT
- Fluent Validation
- Redux
- Onion Architecture
- MediatR
- AutoMapper

# Features

## How to use Social Media api that you can see at the following parts.

# Post Methods
|Route |Http|Post Data| Description|
|------|----|---------|------------|
|/api/posts|POST|{'Message:"...","UserId":"ObjectId("...")"'}|To add post that you can use easily the process.|
|/api/posts|GET|Null|Listing all posts|
|/api/posts/:id|PUT|{"Message:"...}|To Update the post|
|/api/posts/:id|GET|Null|Get By Id of the post.|
|/api/posts/:id|DELETE|Null|Delete the post.|
---------------------------------------------------------------
# Auth Methods
|Route |Http|Post Data| Description|
|------|----|---------|------------|
|/api/auth/register|POST|{'name:"..","surname":"...","email":"...","password":".."}|To register user that you can use easily the process|
|/api/auth/login|POST|{"email":"nttdata@test.com","password":"..."}|When we want to add token and also reach another methods.|
---------------------------------------------------------------

# User Methods
|Route |Http|Post Data| Description|
|------|----|---------|------------|
|/users|GET|NULL|To get all users|
|/users/|PUT|{'username:"loginName",password:"..",..}|Update user details|
|/users/updatepassword/|PUT|{"oldPassword":"","newPassword":".."}|Update of user password.|
|/users/:id|GET|Null|Getting only one user.|
|/users/:id|DELETE|Null|Delete user.|

## Installation

Application requires [Node.js](https://nodejs.org/) v15+ to run.

Install the dependencies and devDependencies and start the server.

For Frontend...
```sh
cd src/Client/ui
code .
npm i
npm start
```

For Backend...

```sh
cd src/API
open on Visual Studio
build application
set as project API side 
start application
```







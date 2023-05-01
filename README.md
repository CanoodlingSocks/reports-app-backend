# Report App (Backend)

This is a basic report app for creating templates and generating reports based on those templates. 
The purpose of this app is mostly so that I can practice backend development, try to utilize patterns such as Dependency Injection and the 
Dependency Inversion Principle (DIP), as well as working with a database using SQLite etc. 

## Current Features

- Creating report templates with customizable fields
- Generating reports based on those templates
- Saving and retrieving templates and reports from the SQLite database

## Installation

Clone the repository to your local machine.
Run npm install in the terminal to install the necessary dependencies.
Run npm start to start the application.
Open 'localhost:3000/' in your web browser to view the web page

1. Clone the repo to you local machine.
2. In Package-Manager if no migration exist, type ```Add-Migration init```  and then type ```Update-Database``` to create the neccessary tables
3. Run the program and check out Swagger to test the Api endpoints

## Future Ideas
In the future, I plan to add a very basic/lightweight word processor to the frontend app to add the functionality of being able to format
your templates and add text to the reports. I might also add a login function and the ability to have individual templates/reports, who knows!

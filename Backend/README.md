# C# Webapi

## The approach

The approach for the backend was to create a RESTful API that interacted with the Database in order to do CRUD operations.

[Diagram-of-each-Restful-api-endpoints]()


There were some cautionary tales to look out for, mainly requests to the api that involed user input. The biggest risk was SQL injection attacks to the database. 

Swagger inteegration for ease of testing api endpoints during development.

Information on connecting to the Database is stored in WebApi/Properties/launchSettings.json -> If it needs changing you can change it there

## Dockerbuild image commands

- TBD
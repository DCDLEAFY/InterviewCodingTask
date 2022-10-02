# InterviewCodingTask

To run the project there are **2 steps**.

1) Run the docker command in the root directory. This command will create 2 docker containers(Frontend & DB)

``` docker-compose up ``` 

2) Go to Backend/WebApi and run 'dotnet run'

This last step is not needed ussually however there are some configuration needed to run a dotnet solution in a docker container. These are yet to be set. I will do so when i have time however for now this will be go-to method.

To view the App goto localhost:8080

## **To-do list**
- [x] Set up Dockerfiles to create docker images for each "*end*"
  - [x] Frontend
  - [x] Backend
  - [x] DB-end :) 
- [ ] API Server
  - [ ] Set up UnitTests and Success conditions
  - [x] Request mapping 
  - [x] Database data mapping
  - [x] Database Connection
  - [x] Database Query functions
    - [x] Search -> Get Request
    - [x] Add -> Post Request
    - [x] Edit -> Put/Post Request
- [x] Database MySQL
  - [x] Create table based on AchmeBroker.txt file
- [x] Frontend VUE
  - [x] Json response from a get request to Server API 
  - [x] Transform Json to User-friendly output - Table
  - [x] Prettify - Finalise CSS and make the site appealing




## **My Approach Notes**

Stack of choice: 
- Frontend: Vue
- Backend: C# Asp.net Webapi
- Database: MySQL
- Docker


I will be utilising the Model-View-Controller Architectural pattern as this will seperate the logic into 3 interconnected parts. 


![MVCSolution](InterviewTask/MVCSolution.png)


***Why use docker?*** It isolates the environment during development, testing, and deployment. It is an overall Quality of development life improvement :)

It also aides development by isoloating the different endpoints locally.


## **Digest of task**
Client would like to interact with his customers data(policies) over the internet.

The basic functions that the client would like to include are(CRUD):
1. Add
2. Search
3. Edit 

The data will be stored in a DB while read/write queries will be handled via an API. 

The Frontend should mirror a policy list webpage - and the overall appeal and design of the webpage must look GOOD! :)



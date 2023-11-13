# Movie Collection API         BackEnd -> .Net 6.0, FrontEnd -> Angular 17,  Database -> PostGre
I have made an app that resembles netflix, apart from watching movies feature. Here, users can log in, have different account types and different needs and possibilities. For now, there are regular user and admin user. 
Regular users have their own movies collection, which they can update, they can also see all of the other users on the application and their collections also. 
For trying on your own computer, I recommend running back end through visual studio, front end through visual studio code and installing PgAdmin application, which will be used for database. On back end, go to package manager console, then update-database, it should update your postGre database accordingly. And change username and password for postGre if needed. I'm using a default one. 
On front end, open FE folder in vsc, then npm install so all the dependencies gets updated or installed on your pc. Then ng serve. Before ng serve, you must start Movie_Collection in visual studio. 

In FE and BE directory, there are Dockerfile for creating separate images -> 1 for front end and 1 for back end.

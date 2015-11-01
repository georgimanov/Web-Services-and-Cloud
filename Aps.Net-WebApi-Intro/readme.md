ASP.NET Web API Homework
========================

1. Using ASP.NET Web API create REST services for the Student System demo from Code First presentation in the Databases course.
	*	Use high-quality code
	*	Use Repository pattern
	*	Create services for all available models.
	*	Do not use scaffolding.
	
	## Entity Framework Code First
	### _Homework_

1.1.  Using c0de first approach, create database for student system with the following tables:
  * `Students`
    * fields: Id, Name, Number, etc.
  * `Courses`
    * fields: Name, Description, Materials, etc.
  * `StudentsInCourses`
    * many-to-many relationship
  * `Homework`
    * one-to-many relationship with students and courses
    * fields: Content, TimeSent
  * Annotate the data models with the appropriate attributes and enable code first migrations
1.1.  Write a console application that uses the data
1.1.  Seed the data with random values

2. Using ASP.NET Web API and Entity Framework (database first or code first) create a database and web services with full CRUD (create, read, update, delete) operations for hierarchy of following classes:
	*	Artists (Name, Country, DateOfBirth, etc.)
	*	Albums (Title, Year, Producer, etc.)
	*	Songs (Title, Year, Genre, etc.)
	*	Every album has a list of artists
	*	Every song has artist
	*	Every album has list of songs

3. Create console application and demonstrate the use of all service operations using the HttpClient class (with both JSON and XML)

4. (*) Create JavaScript-based single page application and consume the service to display user interface for:
	*	Creating, updating and deleting artists, songs and albums (with cascade deleting)
	*	Show pageable, sortable and filterable artists, songs and albums using OData






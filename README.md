# MovieAPI
This Web API gives access to data from a download of a large Movies data csv (mymoviedb.csv) from here [Movies csv](https://www.kaggle.com/datasets/disham993/9000-movies-dataset?resource=download)
It was built on Windows 11 Pro using Visual Studio 2022 IDE

## Functionality
You can call this API using a RestAPI 
There are 4 API calls which can be made:
- api/GetMoviesByTitleWithPagination
  - This returns a Json document with Pagintation root and Movie Children.
  Consumer user request parameters are:
  - 'Title/Name', which will be searched for occurence anywhere in the Title column.
  - 'SortColumn' (Defaults to Title but can also be 'Release_Date', both of which should be placed in an Enum in the calling App for strength).
- api/GetMoviesByGenreWithPagination
  This has the same Sort Parameters as the previous call but uses the 'Genre' parameter, instead of the 'Title' parameter.
- api/GetMoviesByTitle
  - Parameters are SortColumn ('Title' or 'Release_Date') and Title to be searched for
- api/GetMoviesByGenre
  - Parameters are SortColumn ('Title' or 'Release_Date') and Title to be searched for

## Dependencies
- Docker.DotNET 3.125.15
- RestSharp 112.1.0
- FluentAssertions 8.2.0
- Microsoft.AspNetCore.OpenApi 8.0.11
- Microsoft.Data.SqlClient 6.0.2
- Microsoft.VisualStudio.Azure.Containers.Tools.Targets 1.21.0
- Microsoft.VisualStudio.Web.CodeGeneration.Design 8.0.7
- Swashbuckle.AspNetCore 6.9.0

## Database and csv Import
The database used is SQL Server 2022 Express
The csv data was imported via MS Excel and the SSMS Import Data Wizard. The most likely candidate column for Primary Key (Title) was not unique, so an autoincremenet ID was added to the Movies table as the PK, rather than a Compound of Title/Release_Date.
As well as the ID Culstered Indedx, Indexes were added against the Title & Release_Date columns.
Scripts used are kept in the 'MovieAPI/SqlScripts' Folder

## Unit Tests
A Tests Project was added (MovieAPITests) and a single simple Unit Test added using NUnit, which checks the HTTP Status for a request using parameters for pagination, filtering and sorting. The test was passed when running the MovieAPI Test fromm MovieAPI while it was runniong in a separate process.

## Containerisation
As of 23/05/2025, the Docker functionality is problematic. The target was set to Linux64 but from WSL2 in Windows this caused issues with Docker Desktop. It would be easier to use Docker from within Linux itself for easier config.

## To do
- Add descending Sort Ordering. All sorts are ascending currently
- Tidy up Docker and create images
- Create more unit tests and then functional tests to reproduce Client actions





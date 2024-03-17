# RestSharpProject Project

- This repository contains the RestSharpProject project, which is a demonstration API for a media store. Follow the instructions below to set up and run the project.

## Prerequisites

- Visual Studio
- .NET SDK

1. Open the solution file (`MediaStore.Demo.API.sln`) in Visual Studio. 
You can run the project from the command line with `dotnet run` in the project directory.After that, you can run the tests.

## The project is organized into the following folders:

1. Flurl
2. HttpClient
3. RestSharp
4.Adapter
5.AssertonExtensions
6.JsonSchema
7.Models.


## Flurl, HttpClient and RestSharp folders contains the following subfolders:

- `BaseClass`: Contains base classes for API requests.
- `Endpoints`: Contains endpoint configurations.
- `Test`: Contains test classes for API endpoints, further organized into folders based on endpoint types.

    - `GetAlbum`: Tests for GET requests related to albums.
    - `PostAlbum`: Tests for POST requests related to albums.
    - `DeleteAlbum`: Tests for DELETE requests related to albums.
    - `PutAlbum`: Tests for PUT requests related to albums.
    
    - `GetArtists`: Tests for GET requests related to artists.
    - `PostArtist`: Tests for POST requests related to artists.
    - `DeleteArtist`: Tests for DELETE requests related to artists.
    - `PutArtist`: Tests for PUT requests related to artists.
    
    - `GetGenres`: Tests for GET requests related to genres.
    - `PostGenres`: Tests for POST requests related to genres.
    - `DeleteGenres`: Tests for DELETE requests related to genres.
    - `PutGenres`: Tests for PUT requests related to genres.
    
    - `GetTracks`: Tests for GET requests related to tracks.
    - `PostTracks`: Tests for POST requests related to tracks.
    - `DeleteTracks`: Tests for DELETE requests related to tracks.
    - `PutTracks`: Tests for PUT requests related to tracks.
	
	

# JSON Schema Definitions

This folder contains JSON schema definitions for various entities used in the RestSharpProject project. JSON schema definitions are used to describe the structure and constraints of JSON data.

	
## API Testing Utilities

The `RestSharpProject.AssertExtensions` namespace provides a set of assertion extension methods for testing REST API responses. These methods help in asserting various aspects of API responses, including content, status codes, headers, and schema validation for both JSON and XML responses.

### Usage

You can use these assertion methods in your test classes to validate the behavior of your API endpoints. Here's an overview of the available assertion methods:

- `AssertContentContains`: Asserts that the response content contains a specific substring.
- `AssertContentNotContains`: Asserts that the response content does not contain a specific substring.
- `AssertContentEquals`: Asserts that the response content is equal to a specified value.
- `AssertContentNotEquals`: Asserts that the response content is not equal to a specified value.
- `AssertResultEquals`: Asserts that the deserialized response data is equal to a specified value.
- `AssertResultNotEquals`: Asserts that the deserialized response data is not equal to a specified value.
- `AssertSuccessStatusCode`: Asserts that the response status code indicates success (2xx).
- `AssertStatusCode`: Asserts that the response status code matches a specified value.
- `AssertResponseHeader`: Asserts the value of a specific response header.
- `AssertContentType`: Asserts the content type of the response.
- `AssertCookieExists`: Asserts the presence of a specific cookie in the response.
- `AssertCookie`: Asserts the value of a specific cookie in the response.
- `AssertSchema`: Asserts the JSON or XML schema of the response content.
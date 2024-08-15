# ASP.NET Web API - Announcement CRUD Operations

## Overview

This project is an ASP.NET Core Web API that implements CRUD (Create, Read, Update, Delete) operations for managing `Announcement` entities. 
The API allows you to add, edit, delete, and retrieve announcements; also it gives the top 3 similar announcements when requesting a certain announcement details.

## Application URL 

Base url is `https://localhost:7015` (from launchSettings.json file).

## Database Connection

The database connection string is stored in the `appsettings.json` file:

```json
{
  "ConnectionStrings": {
    "TestTaskConnectionString": "Server=.\\SQLExpress;Database=TestTaskDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}



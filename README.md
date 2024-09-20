# Entity Repositry Package

## Table of Contents
1. [Introduction](#introduction)
2. [Getting Started](#getting-start)
3. [Usage Guide](#usage-guide)
4. [Links](#links)

### Introduction
***
This package is aimed at simplifying and speeding up connection to Databse. Provides utility methods for performing basic CRUD operations on your database objects.

## Getting Started
***
Download the package ```Entity.Repositry```. All your database models must inherit the ```BaseEntity``` abstract class.
Setup and register your context class as required.

## Usage Guide
***
In your repository class, inherit the ```EntityRepository``` class and pass in the model class and the context type as the generic type paramters.
Inject the context into your repository class constructor and pass it to the base class.
You can then start calling methods from the base class for your own implementations.
The base class contains methods for inserting, updating, getting deleting,getting counts, and checking if an item exists
Example usage:
```
    public sealed class MyClassRepository : EntityRepository<MyClass, ApplicationDbContext>, IMyClassRepository
    {
        public MyClassRepository(ApplicationDbContext context)
            : base(context) { }

        public async Task InsertOneAsync(MyClass entity, bool saveNow = true) =>
            await InsertAsync(entity, saveNow);

        // Removed for brevity
    }
```

## Links
***
To view the source code or get in touch:
* [Github Repository Link](https://github.com/ojotobar/EntityRepository)
* [Send Me A Mail](mailto:ojotobar@gmail.com)

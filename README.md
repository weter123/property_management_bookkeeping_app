# Bookkeeping App
A BookKeeping desktop app designed for small property managment firm.

## Functional Requirments
  - [X] User able to use the application without Internet Connection (Offline)
  - [X] User able to view list of transactions
  - [X] able te view total of trnasactions.
  - [X] User able to view list of properties.
  - [X] Able view list of payments from a single property.
  - [ ] Able to query payments based on property or renter name.
  - [ ] Able to modify property information.
  - [ ] Able to modify transactions.


## Development Log
2024-03-04: Over the past month, I have been learning how to use .NET Maui and applied what I learned to this project. I have implemented MVVM Pattern to the project and fixed issue with page navigation. the current goal will be to modify the current features with better UI options and setup unit testing before adding new features. 

2024-03-10: since last log update, only small updates were made to the project. this is because I tired to introduce unit testing to the project using XUnit. however, I could not progress far into it because I had limited knowlege on Unit Test development. Currently, I am taking a course on how to use xUnit and research how to devlop unit test for Commands that call SQL Databases.

2024-03-17: this week, I added Property Details page that can be navigated to by clicking on a specific property in the property list page. Property details page display the selected property's info and list all the payments made by the property. Additionally, i added more validtion on all the tasks with arguments and view total of transactions on the main page.

# CustomerEntryApp

## Project Overview

**CustomerEntryApp** is a simple ASP.NET Core MVC application designed for managing customer details. The application enables users to add and edit customer records via a clean and user-friendly interface, utilising in-memory data storage and full input validation.

## Features
-View a list of existing customers
-Add a new customer via a form page
-Edit an existing customer's details
-Validates input before allowing submission
-In-memory storage, no databases
-Responsive UI with some CSS
-Unit tests for validation and controller actions

## Validation Rules


| Property  | Type   | Validation                                        |
|-----------|--------|---------------------------------------------------|
| Name      | String | Required, max length: 50 characters               |
| Age       | Int    | Required, range: 0 to 110                         |
| Postcode  | String | Required, must contain both letters and numbers   |
| Height    | Double | Required, range: 0.0 to 2.50, max 2 decimal places|

## User Interface
-The main page shows a list of customers in a container
-Add and edit buttons trigger a customer details form

## Testing
Unit Tests are included in the CustomerEntryApp.Tests project using xUnit. Tests cover:
-Validation of individual fields
-Controller logic

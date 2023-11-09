# API Automation Project

This is a sample API automation project that demonstrates how to automate API tests using C#, RestSharp, and NUnit. It includes test cases for interacting with a Pet Store API.

## Prerequisites

Before running the tests, make sure you have the following prerequisites installed:

- .NET Core SDK (version X.X or higher)
- Visual Studio or any code editor of your choice
- NUnit Test Adapter (if you're using Visual Studio)

## Project Structure

The project is organized as follows:

- `APIAutomationPOC`: This folder contains the core project code, including the API client class and model classes.
- `Tests`: This folder contains the NUnit test classes.

## Running the Tests

1. Clone or download this repository to your local machine.

2. Open the project in Visual Studio or your preferred code editor.

3. Build the project to ensure all dependencies are resolved.

4. Open the Test Explorer in Visual Studio.

5. Run the tests by selecting them in the Test Explorer and clicking the "Run" button.

## Test Cases

The project includes the following test cases:

1. **TestAddNewPet**: Verifies the functionality of adding a new pet to the store and then finding it by ID.

2. **TestUpdatePet**: Verifies the functionality of updating an existing pet.

3. **TestFindPetById**: Verifies the functionality of finding a pet by its ID.

## Customizing Test Data

To customize test data, you can modify the data in the test methods or load it from external sources, such as JSON files or a database

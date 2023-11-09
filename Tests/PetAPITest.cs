using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

[TestFixture]
public class PetApiTests
{
    private PetStoreApiClient _apiClient;

    [SetUp]
    public void Setup()
    {
        // Initialize the API client with the base URL of your API
        _apiClient = new PetStoreApiClient("https://petstore.swagger.io/v2/");
    }

    [Test]
    [Description("Verifies the functionality of adding a new pet to the store and then finding it by ID.")]
    public void TestAddNewPet()
    {
        // Arrange: Create a new pet with the required data
        var newPet = new PetModel
        {
            Category = new Category { Id = 0, Name = "string" },
            Name = "doggie",
            PhotoUrls = new List<string> { "string" },
            Tags = new List<Tag> { new Tag { Id = 0, Name = "string" } },
            Status = "available"
        };

        // Act: Send a POST request to add a new pet
        var addResponse = _apiClient.AddNewPet<PetModel>(newPet);

        // Assert: Verify the response
        Assert.AreEqual(HttpStatusCode.OK, addResponse.StatusCode, "The response status code is not 'OK'");
        var addedPet = addResponse.Content;
        Assert.IsNotNull(addedPet, "No pet data returned in the response.");

        // Act: Find the newly added pet by its ID
        long id = addResponse.Data.Id;
        long petId = id; // Assuming the response contains the ID of the newly added pet
        var findResponse = _apiClient.FindPetById<PetModel>(petId);

        // Assert: Verify that the response contains the expected pet and its details
        Assert.IsTrue(findResponse.IsSuccessful, "The request to find the pet by ID was not successful.");
        Assert.AreEqual(200, (int)findResponse.StatusCode, "Unexpected status code for finding the pet by ID.");

        // Assert: Validate the pet details in the response
        var foundPet = findResponse.Data;
        Assert.IsNotNull(foundPet, "No pet data returned in the response.");
        Assert.AreEqual(petId, foundPet.Id, "The retrieved pet's ID does not match the expected ID.");
        Assert.AreEqual(newPet.Name, foundPet.Name, "The retrieved pet's name does not match the expected name.");
        // Add additional assertions to validate other pet details.
    }

    [Test]
    [Description("Verifies the functionality of updating an existing pet.")]
    public void TestUpdatePet()
    {
        // Arrange: Create a new pet with the required data
        var pet = new PetModel
        {
            Category = new Category { Id = 0, Name = "string" },
            Name = "doggie",
            PhotoUrls = new List<string> { "string" },
            Tags = new List<Tag> { new Tag { Id = 0, Name = "string" } },
            Status = "available"
        };

        // Act: Send a POST request to add a new pet
        var addResponse = _apiClient.AddNewPet<PetModel>(pet);

        // Arrange: Update the pet details
        var updatedName = "Tiger";
        var updatedStatus = "pending";
        pet.Name = updatedName;
        pet.Status = updatedStatus;
        pet.Id = addResponse.Data.Id;

        // Act: Send a PUT request to update the pet
        var updateResponse = _apiClient.UpdatePet<PetModel>(pet);

        // Assert: Verify the response
        Assert.AreEqual(HttpStatusCode.OK, updateResponse.StatusCode, "The response status code is not 'OK'");
        var updatedPet = updateResponse.Data;
        Assert.IsNotNull(updatedPet, "No pet data returned in the response.");

        // Assert: Validate the updated pet's details
        Assert.AreEqual(updatedName, updatedPet.Name, "The updated pet's name does not match the expected name.");
        Assert.AreEqual(updatedStatus, updatedPet.Status, "The updated pet's status does not match the expected status.");
    }

    [Test]
    [Description("Verifies the functionality of finding a pet by its ID.")]
    public void TestFindPetById()
    {
        // Arrange: Create a new pet with the required data
        var pet = new PetModel
        {
            Category = new Category { Id = 0, Name = "string" },
            Name = "doggie",
            PhotoUrls = new List<string> { "string" },
            Tags = new List<Tag> { new Tag { Id = 0, Name = "string" } },
            Status = "available"
        };

        // Act: Send a POST request to add a new pet
        var addResponse = _apiClient.AddNewPet<PetModel>(pet);

        // Act: Send a GET request to find the pet by its ID
        var findResponse = _apiClient.FindPetById<PetModel>(addResponse.Data.Id);

        // Assert: Verify the response
        Assert.IsTrue(findResponse.IsSuccessful, "The request to find the pet by ID was not successful.");
        Assert.AreEqual(200, (int)findResponse.StatusCode, "Unexpected status code for finding the pet by ID.");

        // Assert: Validate the details of the found pet
        Assert.AreEqual(addResponse.Data.Name, findResponse.Data.Name, "The retrieved pet's name does not match the expected name.");
    }
}

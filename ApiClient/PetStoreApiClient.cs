using RestSharp;

public class PetStoreApiClient
{
    private readonly RestClient _client;
    private readonly string _baseUrl;

    public PetStoreApiClient(string baseUrl)
    {
        _baseUrl = baseUrl;
        _client = new RestClient(baseUrl);
    }

    // Method to send a POST request to add a new pet to the store
    public RestResponse<T> AddNewPet<T>(PetModel pet)
    {
        var request = new RestRequest("/pet", Method.Post);
        request.AddJsonBody(pet);

        return _client.Execute<T>(request);
    }

    // Method to send a PUT request to update an existing pet
    public RestResponse<T> UpdatePet<T>(PetModel pet)
    {
        var request = new RestRequest("/pet", Method.Put);
        request.AddJsonBody(pet);

        return _client.Execute<T>(request);
    }

    // Method to send a GET request to find pets by status
    public RestResponse<T> FindPetsByStatus<T>(string status)
    {
        var request = new RestRequest("/pet/findByStatus", Method.Get);
        request.AddParameter("status", status);

        return _client.Execute<T>(request);
    }

    // Method to send a GET request to find pets by tags
    public RestResponse<T> FindPetsByTags<T>(params string[] tags)
    {
        var request = new RestRequest("/pet/findByTags", Method.Get);
        request.AddParameter("tags", string.Join(",", tags));

        return _client.Execute<T>(request);
    }

    // Method to send a GET request to find a pet by ID
    public RestResponse<T> FindPetById<T>(long petId)
    {
        var request = new RestRequest($"/pet/{petId}", Method.Get);

        return _client.Execute<T>(request);
    }
}

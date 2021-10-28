using System.Threading.Tasks;
using RestSharp;

namespace MessageBoardApp.Models
{
  class ApiHelper
  {
    public static async Task<string> GetMessages()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"messages", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetPersons()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"persons", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetGroups()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"groups", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetMessage(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"messages/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetPerson(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"persons/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetCurrentUser()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"currentuser/1", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetGroup(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"groups/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task PostMessage(string newMessage)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"messages", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMessage);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task PostPerson(string newPerson)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"persons", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPerson);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task PostGroup(string newGroup)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"groups", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newGroup);
      var response = await client.ExecuteTaskAsync(request);
    }
        public static async Task PatchMessage(int id, string newMessage)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"messages/{id}", Method.PATCH);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMessage);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task PatchPerson(int id, string newPerson)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"persons/{id}", Method.PATCH);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPerson);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task PatchCurrentUser(int id, string newCurrentUser)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"currentuser/{id}", Method.PATCH);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newCurrentUser);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task PatchGroup(int id, string newGroup)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"groups/{id}", Method.PATCH);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newGroup);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeleteMessage(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"messages/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeletePerson(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"persons/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeleteGroup(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"Groups/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

  }
}